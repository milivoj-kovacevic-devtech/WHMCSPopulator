using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FileHelpers;
using Newtonsoft.Json.Linq;

namespace WhmcsPopulator.Shared.Api
{
    public class WhmcsBaseRequest
    {
        // TODO Implement methods for sending request here and in subclasses

        [FieldIgnored]
        public string UserName;
        [FieldIgnored]
        public string Password;
        [FieldIgnored]
        public string ResponseType;

        [FieldIgnored]
        [ApiParamName("action")]
        public string ApiAction;

        [FieldIgnored]
        public RestClient ApiRestClient; // TODO Check if this should be here
        [FieldIgnored]
        public RestResponse Response;

        public WhmcsBaseRequest()
        {
            UserName = ApiCredentials.UserName;
            Password = ApiCredentials.Password;
            ResponseType = "json";

            ApiRestClient = new RestClient(ApiCredentials.Url);
        }

        public void Send()
        {
            var request = InitializeRequest();

            SetParameters(request);

            Response = ApiRestClient.Execute(request) as RestResponse;
        }

        protected void SetParameters(RestRequest request)
        {
            // TODO Check if this is needed
            Type type = this.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                // TODO Resolve attributes and use it to send request
                var attr = prop.GetCustomAttributes(true);
                request.AddParameter(attr.ToString(), prop);
            }
        }

        protected RestRequest InitializeRequest()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("responsetype", ResponseType);
            request.AddParameter("username", UserName);
            request.AddParameter("password", Password);

            return request;
        }

        public bool IsSuccess(RestResponse response)
        {
            var content = response.Content;
            dynamic responseJson = JValue.Parse(content);
            
            if (responseJson.result == "error")
                return false;
            return true;
        }

        internal struct WhmcsApi
        {
            public const string GetClients = "getclients";
            public const string AddClient = "addclient";
            public const string AddContact = "addcontact";
            public const string GetClientsProducts = "getclientsproducts";
            public const string GetClientsDomains = "getclientsdomains";
            public const string RegisterDomain = "registerdomain";

            public const string AddOrder = "addorder";
            public const string GetOrders = "getorders";
            public const string AddProduct = "addproduct";
            public const string GetProducts = "getproducts";
            public const string GetOrderStatuses = "getorderstatuses";
            public const string AcceptOrder = "acceptorder";
        }
    }
}
