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
		private string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

		public WhmcsApiProxy(ApiCredentials credentials)
		{
			Credentials = credentials;
		}

		// Clients API methods

		public List<string> GetClientsIds()
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.GetClients);

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;

			dynamic json = JValue.Parse(content);
            // TODO Add error handling. If response is error, it should be processed. If there are no clients, it should be processed as well.
			var clients = json.clients.client;

            List<string> ids = new List<string>();
            try
            {
                foreach (var cl in clients)
                {
                    ids.Add((String)cl.id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting WHMCS clients: " + ex);
            }

			return ids;
		}

		public void AddClient(Client whmcsClient)
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

		public void AddContact(Contact whmcsContact)
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.AddClient);
			request.AddParameter("firstname", whmcsContact.FirstName);

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;

			Console.WriteLine("Adding contact response: " + content);
		}

		// Products/orders API methods

		// TODO Change this to return some kind of object
		public String GetProducts(string productGroupId)
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.GetProducts);

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;

			dynamic json = JValue.Parse(content);
			var products = json.products.product;

			// TODO Change this to be object
			string ids = "";

			foreach (var prod in products)
			{
				ids += prod.pid + ", ";
			}
			return ids;
		}

		public void AddOrder()
		{
			// TODO Check options for implementing this
			// http://docs.whmcs.com/API:Add_Order
		}

		public void AcceptOrder()
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.AcceptOrder);
			request.AddParameter("orderid", ""); // TODO Change empty string to order id

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;
		}

		// TODO Change this to return object
		public string GetOrderStatuses()
		{
			var client = new RestClient(ApiUrl);
			var request = InitializePostRequest(WhmcsApi.GetOrderStatuses);

			var response = client.Execute(request) as RestResponse;
			var content = response.Content;

			dynamic json = JValue.Parse(content);
			var statuses = json.statuses.status;

			// TODO Change this to be object
			string titles = "";

			foreach (var st in statuses)
			{
				titles += st.id + ", ";
			}
			return titles;

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

			public const string GetProducts = "getproducts";
			public const string GetOrderStatuses = "getorderstatuses";

            public const string ModuleCreate = "modulecreate";
			public const string AcceptOrder = "acceptorder";
        }
    }
}
