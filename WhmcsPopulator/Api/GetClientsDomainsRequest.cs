namespace WhmcsPopulator.Api
{
    public class GetClientsDomainsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("clientid")]
        public string ClientId;

        public GetClientsDomainsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetClientsDomains;
        }
    }
}
