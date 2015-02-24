using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    public class GetClientsProductsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("clientid")]
        public string ClientId;

        public GetClientsProductsRequest(string clientId)
            : base()
        {
			ClientId = clientId;
            ApiAction = WhmcsApi.GetClientsProducts;
        }
    }
}
