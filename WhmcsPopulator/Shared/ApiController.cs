using System;
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
        private static readonly ILog Log = LogManager.GetLogger(typeof(ApiController));

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
			    Log.Error("Client not added due to error: " + ex.Message);
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
				Log.Error("Contact not added due to error: " + ex.Message);
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
			}
			catch (Exception ex)
			{
				Log.Error("Order not added due to error: " + ex.Message);
				success = false;
			}
			return success;
		}

		// maybe to call it inside insertorder()?
		public bool AcceptOrder(string orderId)
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
				Log.Error("Order not accepted due to error: " + ex.Message);
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
