using System;
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
				var penis = ResolveRequest(client);
				var response = _restClient.Execute(penis) as RestResponse;
				if (!IsSuccess(response)) throw new Exception("API returns error.");
				clientId = response.Content; // TODO Change to id from response
			}
			catch (Exception ex)
			{
			    Log.Error("Client not added due to error: " + ex.Message);
				success = false;
			}
			return success;
		}

		public void InsertContact(string clientId)
		{
			// inserting one contact
		}

		public void InsertOrder(string clientId)
		{
			// inserting one order
		}

		public void AcceptOrder(string orderId)
		{
			// accept previosly added order
		}

		private RestRequest ResolveRequest(object data)
		{
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

			foreach (var prop in data.GetType().GetFields())
			{
				var attr = prop.GetCustomAttributes(typeof(ApiParamNameAttribute), true).FirstOrDefault();
				if (attr == null) continue;
				var key = ((ApiParamNameAttribute)attr).Name;

				var mandatory = prop.GetCustomAttributes(typeof(MandatoryParameterAttribute), true).FirstOrDefault() != null;
				var value = prop.GetValue(data);
				if (mandatory && value == null) throw new Exception("Mandatory field cannot be null.");
				
				request.AddParameter(key, value);
			}
			return request;
		}

	    private bool IsSuccess(RestResponse response)
        {
            // TODO Create method which will do the json deserialization
            var content = response.Content;
            dynamic responseJson = JValue.Parse(content);

            if (responseJson.result == "error")
                return false;
            return true;
        }

	}
}
