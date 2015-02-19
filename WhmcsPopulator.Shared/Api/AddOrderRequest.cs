using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Shared.Api
{
    public class AddOrderRequest : WhmcsBaseRequest
    {
        // Required parameters
        [ApiParamName("clientid")]
        public string ClientId { get; set; }
        [ApiParamName("pid")]
        public string ProductId { get; set; }
        [ApiParamName("domain")]
        public string DomainName { get; set; }
        [ApiParamName("billingcycle")] // onetime, monthly, quarterly, semiannually, etc...
        public string BillingCycle { get; set; }
        [ApiParamName("domaintype")] // set for domain registration - register or transfer
        public string DomainType { get; set; }
        [ApiParamName("regperiod")] // 1,2,3,etc...
        public string RegPeriod { get; set; }
        [ApiParamName("eppcode")] // if domain transfer
        public string EppCode { get; set; }
        [ApiParamName("nameserver1")] // first nameserver (req for domain reg only)
        public string Nameserver1 { get; set; }
        [ApiParamName("paymentmethod")] // paypal, authorize, etc...
        public string PaymentMethod { get; set; }

        // Optional parameters
        // for domain reg only
        [ApiParamName("contactid")]
        public string ContactId { get; set; }
        [ApiParamName("dnsmanagement")] // true to enable
        public string DnsManagement { get; set; }
        [ApiParamName("domainfields")] // a base64 encoded serialized array of the TLD specific field values
        public string DomainFields { get; set; }
        [ApiParamName("emailforwarding")] // true to enable
        public string EmailForwarding { get; set; }
        [ApiParamName("idprotection")] // true to enable
        public string IdProtection { get; set; }
        [ApiParamName("nameserver2")] // second nameserver
        public string Nameserver2 { get; set; }
        [ApiParamName("nameserver3")] // third nameserver
        public string Nameserver3 { get; set; }
        [ApiParamName("nameserver4")] // fourth nameserver
        public string Nameserver4 { get; set; }

        public AddOrderRequest()
            : base()
        {
            ApiAction = WhmcsApi.AddOrder;
        }
    }
}
