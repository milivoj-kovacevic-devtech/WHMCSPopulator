using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Shared.Api
{
    public class GetClientsProductsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("clientid")]
        public string ClientId { get; set; }

        public GetClientsProductsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetClientsProducts;
        }

        // TODO Process response and check what is missing
    }
}
