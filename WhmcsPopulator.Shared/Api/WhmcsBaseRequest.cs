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


        [ApiParamName("username")]
        public string UserName { get; set; }
        [ApiParamName("password")]
        public string Password { get; set; }
        [ApiParamName("action")]
        public string ApiAction { get; set; }
        [ApiParamName("responsetype")]
        public string ResponseType { get; set; }

        public string Response { get; set; }

        public WhmcsBaseRequest()
        {
            UserName = ApiCredentials.UserName;
            Password = ApiCredentials.Password;
            ResponseType = "json";
        }

        public void Send()
        {
            var client = new RestClient(ApiCredentials.Url);

            Type type = this.GetType();
            var properties = type.GetProperties();

            var request = new RestRequest(Method.POST);
            foreach (var prop in properties)
            {   
                // TODO Resolve attributes and use it to send request
                var attr = prop.GetCustomAttributes(true);
                request.AddParameter(attr.ToString(), prop);                
            }

            var response = client.Execute(request) as RestResponse;
            ProcessResponse(response); // TODO TODO TODO TODO TODO TODO
        }

        protected string ProcessResponse(RestResponse response)
        {
            var content = response.Content;

            dynamic responseJson = JValue.Parse(content);
            
            if (responseJson.result == "error")
                return "Error sending request: " + responseJson.message;

            // TODO Resolve success
            return responseJson.result;

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
