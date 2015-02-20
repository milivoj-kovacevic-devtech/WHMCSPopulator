using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Helpers
{
	public class ApiController
	{
		private RestClient _restClient;

		public ApiController()
		{
			_restClient = new RestClient(ApiCredentials.Url);
		}

		public bool InsertClient(AddClientRequest client, out string clientId)
		{
			var success = true;
			clientId = string.Empty;
			try
			{
				var penis = ResolveRequest(client);
				var response = _restClient.Execute(penis);
				if (response.Content == "penis") throw new Exception("api fail");
				clientId = response.Content;
			}
			catch (Exception ex)
			{
				//logujMe(ex.Message)
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
			RestRequest request = new RestSharp.RestRequest();
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
	}
}
