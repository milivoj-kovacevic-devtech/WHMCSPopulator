using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    public class GetClientsDomainsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("clientid")]
        public string ClientId;

        public GetClientsDomainsRequest()
        {
            ApiAction = WhmcsApi.GetClientsDomains;
        }
    }
}
