namespace WhmcsPopulator.Api
{
    public class GetClientsProductsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("clientid")]
        public string ClientId;

        public GetClientsProductsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetClientsProducts;
        }
    }
}
