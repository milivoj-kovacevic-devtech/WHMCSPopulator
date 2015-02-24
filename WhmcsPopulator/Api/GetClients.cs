namespace WhmcsPopulator.Api
{
    public class GetClientsRequest : WhmcsBaseRequest
    {
        public GetClientsRequest()
        {
            ApiAction = WhmcsApi.GetClients;
        }
    }
}
