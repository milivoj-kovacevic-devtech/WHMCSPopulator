using RestSharp;
using System;
using FileHelpers;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator
{
    public class WhmcsBaseRequest
    {
        [FieldIgnored]
        [MandatoryParameter]
		[ApiParamName("username")]
        public string UserName;
        [FieldIgnored]
        [MandatoryParameter]
		[ApiParamName("password")]
        public string Password;
        [FieldIgnored]
        [MandatoryParameter]
		[ApiParamName("responsetype")]
        public string ResponseType;

        [FieldIgnored]
        [MandatoryParameter]
        [ApiParamName("action")]
        public string ApiAction;

        [FieldIgnored]
        public RestResponse Response;

        public WhmcsBaseRequest()
        {
            UserName = ConfigManager.AdminUsername;
            Password = ConfigManager.AdminPassword;
            ResponseType = "json";
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
			public const string ModuleCreate = "modulecreate";
        }
    }
}
