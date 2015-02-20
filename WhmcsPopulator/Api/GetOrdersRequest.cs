using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    public class GetOrdersRequest : WhmcsBaseRequest
    {
        // Optional attributes
        [ApiParamName("id")] // to get a specific order id only
        public string Id { get; set; }
        [ApiParamName("userid")] // to get all orders for a specific client id
        public string UserId { get; set; }
        [ApiParamName("status")] // to get all orders in a specific status
        public string Status { get; set; }

        public GetOrdersRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetOrders;
        }

         // TODO Process response
    }
}
