using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    public class GetProductsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("pid")]
        public string ProductId { get; set; }
        [ApiParamName("gid")]
        public string GroupId { get; set; }
        [ApiParamName("module")] // can be passed to just retrieve products assigned to a specific module
        public string Module { get; set; }

        public GetProductsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetProducts;
        }

        // TODO Process response
    }
}
