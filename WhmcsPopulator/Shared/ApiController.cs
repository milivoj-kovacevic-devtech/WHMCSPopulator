﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using log4net;
using Newtonsoft.Json.Linq;
using RestSharp;
using WhmcsPopulator.Api;

namespace WhmcsPopulator.Shared
{
	public class ApiController
	{
		private static readonly ILog _log = LogManager.GetLogger(typeof(ApiController));
		private RestClient _restClient;

		public ApiController()
		{
			_restClient = new RestClient(ConfigManager.ApiUrl);
		}

		public bool InsertClient(AddClientRequest client, out string clientId)
		{
			var success = true;
			clientId = string.Empty;
			try
			{
				var request = ResolveRequest(client);
				var response = _restClient.Execute(request) as RestResponse;
				dynamic processedResponse = ProcessResponse(response);

				if (!IsSuccess(processedResponse)) throw new Exception("API returns error.");
				clientId = processedResponse.clientid;
				Console.WriteLine("Client with ID " + clientId + " added to WHMCS.");
			}
			catch (Exception ex)
			{
				_log.Error("Client not added due to error: " + ex.Message);
				success = false;
			}
			return success;
		}

		public bool InsertContact(AddContactRequest contact, string clientId)
		{
			var success = true;
			contact.ClientId = clientId;
			try
			{
				var request = ResolveRequest(contact);
				var response = _restClient.Execute(request) as RestResponse;
				dynamic processedResponse = ProcessResponse(response);

				if (!IsSuccess(processedResponse)) throw new Exception("API returns error.");
			}
			catch (Exception ex)
			{
				_log.Error("Contact not added due to error: " + ex.Message);
				success = false;
			}
			return success;
		}

		public bool InsertOrder(AddOrderRequest order, string clientId)
		{
			var success = true;
			order.ClientId = clientId;
			try
			{
				var request = ResolveRequest(order);
				var response = _restClient.Execute(request) as RestResponse;
				dynamic processedResponse = ProcessResponse(response);

				if (!IsSuccess(processedResponse)) throw new Exception("API returns error.");
				if (AcceptOrder(processedResponse.orderid)) throw new Exception("Unable to accept order.");
			}
			catch (Exception ex)
			{
				_log.Error("Order not added due to error: " + ex.Message);
				success = false;
			}
			return success;
		}

		private bool AcceptOrder(string orderId)
		{
			var order = new AcceptOrderRequest(orderId);
			var success = true;
			try
			{
				var request = ResolveRequest(order);
				var response = _restClient.Execute(request) as RestResponse;
				dynamic processedResponse = ProcessResponse(response);

				if (!IsSuccess(processedResponse)) throw new Exception("API returns error.");
			}
			catch (Exception ex)
			{
				_log.Error("Order not accepted due to error: " + ex.Message);
				success = false;
			}
			return success;
		}

		public bool ActivateSubscriptions(string clientId) // calls modulecreate API method
		{
			var success = true;
			List<string> subscriptionIds;
			try
			{
				if (!GetSubsriptions(clientId, out subscriptionIds)) throw new Exception("Error getting subscriptions.");
				foreach (var subscriptionId in subscriptionIds)
				{
					var moduleCreate = new ModuleCreateRequest(subscriptionId);
					var request = ResolveRequest(moduleCreate);
					var response = _restClient.Execute(request) as RestResponse;
					dynamic processedResponse = ProcessResponse(response);

					if (!IsSuccess(processedResponse)) throw new Exception("API returns error");
				}
			}
			catch (Exception ex)
			{
				_log.Error("Module not activated: " + ex.Message);
				success = false;
			}
			return success;
		}

		private bool GetSubsriptions(string clientId, out List<string> subscriptionIds)
		{
			var success = true;
			subscriptionIds = new List<string>();
			var clientsProducts = new GetClientsProductsRequest(clientId);
			try
			{
				var request = ResolveRequest(clientsProducts);
				var response = _restClient.Execute(request) as RestResponse;
				dynamic processedResponse = ProcessResponse(response);

				if (!IsSuccess(processedResponse)) throw new Exception("API returns error.");
				foreach (var prod in processedResponse.products.product)
				{
					subscriptionIds.Add(prod.id as string);
				}
			}
			catch (Exception ex)
			{
				_log.Error("Error getting products for client " + clientId + ": " + ex.Message);
				success = false;
			}

			return success;
		}

		private RestRequest ResolveRequest(object data)
		{
			var request = new RestRequest(Method.POST);
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

			foreach (var field in data.GetType().GetFields())
			{
				var attr = field.GetCustomAttributes(typeof(ApiParamNameAttribute), true).FirstOrDefault();
				if (attr == null) continue;
				var key = ((ApiParamNameAttribute)attr).Name;

				var mandatory = field.GetCustomAttributes(typeof(MandatoryParameterAttribute), true).FirstOrDefault() != null;
				var value = field.GetValue(data);
				if (mandatory && value == null) throw new Exception("Mandatory field cannot be null.");

				request.AddParameter(key, value);
			}
			return request;
		}

		private JToken ProcessResponse(RestResponse response)
		{
			var content = response.Content;
			var responseJson = JValue.Parse(content);

			return responseJson;
		}

		private bool IsSuccess(dynamic responseJson)
		{
			return responseJson.result == "success";
		}

	}
}
