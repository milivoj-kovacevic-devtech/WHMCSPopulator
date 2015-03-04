using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Newtonsoft.Json.Linq;
using RestSharp;
using WhmcsPopulator.Api;

namespace WhmcsPopulator.Shared
{
	public class ApiController
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(ApiController));
		private RestClient _restClient;

		public ApiController()
		{
			_restClient = new RestClient(ConfigManager.ApiUrl);
		}

		public bool InsertClient(AddClientRequest client, out string clientId)
		{
			Log.Info("InsertClient init...");

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
				Log.Debug("Client with ID " + clientId + " added to WHMCS.");
			}
			catch (Exception ex)
			{
				Log.Error("Client not added due to error: " + ex.Message);
				success = false;
			}
			Log.Info("InsertClient end.");
			return success;
		}

		public bool InsertContact(AddContactRequest contact, string clientId)
		{
			Log.Info("InsertContact init...");
			Log.Debug("Adding contact for client id " + clientId);
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
				Log.Error("Contact not added due to error: " + ex.Message);
				success = false;
			}
			Log.Info("InsertContact end.");
			return success;
		}

		public bool InsertOrder(AddOrderRequest order, string clientId)
		{
			Log.Info("InsertOrder init...");
			Log.Debug("Adding order for client id " + clientId);
			var success = true;
			order.ClientId = clientId;
			try
			{
				var request = ResolveRequest(order);
				var response = _restClient.Execute(request) as RestResponse;
				dynamic processedResponse = ProcessResponse(response);

				if (!IsSuccess(processedResponse)) throw new Exception("API returns error.");
				if (!AcceptOrder(processedResponse.orderid.ToString())) throw new Exception("Unable to accept order.");
			}
			catch (Exception ex)
			{
				Log.Error("Order not added due to error: " + ex.Message);
				success = false;
			}
			Log.Info("InsertOrder end.");
			return success;
		}

		private bool AcceptOrder(string orderId)
		{
			Log.Info("AcceptOrder init...");
			Log.Debug("Accepting order with id " + orderId);
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
				Log.Error("Order not accepted due to error: " + ex.Message);
				success = false;
			}
			Log.Info("AcceptOrder end.");
			return success;
		}

		public bool ActivateSubscriptions(string clientId) // calls modulecreate API method
		{
			Log.Info("ActivateSubscription init...");
			Log.Debug("Activating subscriptions for client id " + clientId);
			var success = true;
		    try
			{
			    List<string> subscriptionIds;
			    if (!GetSubsriptions(clientId, out subscriptionIds)) throw new Exception("Error getting subscriptions.");
			    if ((from subscriptionId in subscriptionIds select new ModuleCreateRequest(subscriptionId) into moduleCreate select ResolveRequest(moduleCreate) into request select _restClient.Execute(request) as RestResponse into response select ProcessResponse(response)).Any(processedResponse => !IsSuccess((dynamic) processedResponse)))
			    {
			        throw new Exception("API returns error");
			    }
			}
			catch (Exception ex)
			{
				Log.Error("Module not activated: " + ex.Message);
				success = false;
			}
			Log.Info("ActivateSubscription end.");
			return success;
		}

		private bool GetSubsriptions(string clientId, out List<string> subscriptionIds)
		{
			Log.Info("GetSubscriptions init...");
			Log.Debug("Getting subscriptions for client id " + clientId);
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
					subscriptionIds.Add(prod.id.ToString());
					Log.Debug("Product with id " + prod.id + "found.");
				}
			}
			catch (Exception ex)
			{
				Log.Error("Error getting products for client " + clientId + ": " + ex.Message);
				success = false;
			}

			Log.Info("GetSubscriptions end.");
			return success;
		}

		private RestRequest ResolveRequest(object data)
		{
			Log.Info("ResolveRequest init...");
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
			Log.Info("ResolveRequest end.");
			return request;
		}

		private JToken ProcessResponse(RestResponse response)
		{
			Log.Info("ProcessResponse init...");
			var content = response.Content;
			Log.Debug("Full API response: " + content);
			var responseJson = JValue.Parse(content);

			Log.Info("ProcessResponse end.");
			return responseJson;
		}

		private bool IsSuccess(dynamic responseJson)
		{
			return responseJson.result == "success";
		}

	}
}
