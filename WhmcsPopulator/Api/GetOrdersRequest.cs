using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    public class GetOrdersRequest : WhmcsBaseRequest
    {
        // Optional attributes
        [ApiParamName("id")] // to get a specific order id only
        public string Id;
        [ApiParamName("userid")] // to get all orders for a specific client id
        public string UserId;
        [ApiParamName("status")] // to get all orders in a specific status
        public string Status;

        public GetOrdersRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetOrders;
        }
    }
}
