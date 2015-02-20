using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    public class RegisterDomainRequest : WhmcsBaseRequest
    {
        // Required attributes. One of these should be used, no need for both
        [ApiParamName("domainid")]
        public string DomainId { get; set; }
        [ApiParamName("domain")]
        public string DomainName { get; set; }

        public RegisterDomainRequest()
            : base()
        {
            ApiAction = WhmcsApi.RegisterDomain;
        }

        // TODO Process response and check missing stuff
    }
}
