using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    public class GetClientsDomainsRequest : WhmcsBaseRequest
    {
        // Optional parameters
        [ApiParamName("clientid")]
        public string ClientId { get; set; }

        public GetClientsDomainsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetClientsDomains;
        }

        // TODO Process request and check if something is missing
    }
}
