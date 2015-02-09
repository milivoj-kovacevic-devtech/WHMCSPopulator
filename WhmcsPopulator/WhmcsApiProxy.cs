using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace WhmcsPopulator
{
    public class WhmcsApiProxy
    {
		private ApiCredentials Credentials { get; set; }
		private string ApiUrl = ConfigurationSettings.AppSettings["ApiUrl"]; // TODO Change to ConfigurationManager

		public WhmcsApiProxy(ApiCredentials credentials)
		{
			Credentials = credentials;
		}

		// Clients API methods

		// TODO This method should return list of ids
		public String GetClientsIds()
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.GetClients);

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;

			dynamic json = JValue.Parse(content);
			var clients = json.clients.client;

			// TODO Change this to be object
			string ids = "";

			foreach (var cl in clients)
			{
				ids += cl.id + ", ";
			}
			return ids;
		}

		public void AddClient(WhmcsClient whmcsClient)
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.AddClient);
			request.AddParameter("firstname", whmcsClient.FirstName);
			request.AddParameter("lastname", whmcsClient.LastName);
			request.AddParameter("email", whmcsClient.Email);
			request.AddParameter("address1", whmcsClient.Address1);
			request.AddParameter("city", whmcsClient.City);
			request.AddParameter("state", whmcsClient.State);
			request.AddParameter("postcode", whmcsClient.PostCode);
			request.AddParameter("country", whmcsClient.Country);
			request.AddParameter("phonenumber", whmcsClient.PhoneNumber);
			request.AddParameter("password2", whmcsClient.Password);

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;

			Console.WriteLine("Adding client response: " + content);
		}

		// Contacts API methods

		public void AddContact(WhmcsContact whmcsContact)
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.AddClient);
			request.AddParameter("firstname", whmcsContact.FirstName);

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;

			Console.WriteLine("Adding contact response: " + content);
		}

		// Helper methods

		private RestRequest InitializePostRequest(string apiAction)
		{
			var request = new RestRequest(Method.POST);
			request.AddParameter("username", Credentials.UserName);
			request.AddParameter("password", Credentials.Password);
			request.AddParameter("action", apiAction);
			request.AddParameter("responsetype", "json");

			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

			return request;
		}


        internal struct WhmcsApi
        {
			public const string GetClients = "getclients";

			public const string AddClient = "addclient";
            public const string AddContact = "addcontact";

            public const string ModuleCreate = "modulecreate";
        }
    }
}
