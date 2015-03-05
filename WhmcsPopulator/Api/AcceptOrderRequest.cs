using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    public class AcceptOrderRequest : WhmcsBaseRequest
    {
        // Required parameters
        [MandatoryParameter]
        [ApiParamName("orderid")]
        public string OrderId;

        public AcceptOrderRequest(string orderId)
        {
            ApiAction = WhmcsApi.AcceptOrder;
			OrderId = orderId;
        }
    }
}
