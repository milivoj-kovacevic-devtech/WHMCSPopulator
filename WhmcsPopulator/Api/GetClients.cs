namespace WhmcsPopulator.Api
{
    public class GetClientsRequest : WhmcsBaseRequest
    {
        public GetClientsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetClients;
        }
    }
}
