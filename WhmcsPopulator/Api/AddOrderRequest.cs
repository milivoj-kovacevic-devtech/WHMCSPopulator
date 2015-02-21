using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    public class AddOrderRequest : WhmcsBaseRequest
    {
        // Required parameters
        [MandatoryParameter]
        [ApiParamName("clientid")]
        public string ClientId;
        [MandatoryParameter]
        [ApiParamName("pid")]
        public string ProductId;
        [MandatoryParameter]
        [ApiParamName("domain")]
        public string DomainName;
        [MandatoryParameter]
        [ApiParamName("billingcycle")] // onetime, monthly, quarterly, semiannually, etc...
        public string BillingCycle;
        [MandatoryParameter]
        [ApiParamName("domaintype")] // set for domain registration - register or transfer
        public string DomainType;
        [MandatoryParameter]
        [ApiParamName("regperiod")] // 1,2,3,etc...
        public string RegPeriod;
        [MandatoryParameter]
        [ApiParamName("eppcode")] // if domain transfer
        public string EppCode;
        [MandatoryParameter]
        [ApiParamName("nameserver1")] // first nameserver (req for domain reg only)
        public string Nameserver1;
        [MandatoryParameter]
        [ApiParamName("paymentmethod")] // paypal, authorize, etc...
        public string PaymentMethod;

        // Optional parameters
        // for domain reg only
        [ApiParamName("contactid")]
        public string ContactId;
        [ApiParamName("dnsmanagement")] // true to enable
        public string DnsManagement;
        [ApiParamName("domainfields")] // a base64 encoded serialized array of the TLD specific field values
        public string DomainFields;
        [ApiParamName("emailforwarding")] // true to enable
        public string EmailForwarding;
        [ApiParamName("idprotection")] // true to enable
        public string IdProtection;
        [ApiParamName("nameserver2")] // second nameserver
        public string Nameserver2;
        [ApiParamName("nameserver3")] // third nameserver
        public string Nameserver3;
        [ApiParamName("nameserver4")] // fourth nameserver
        public string Nameserver4;

        public AddOrderRequest()
            : base()
        {
            ApiAction = WhmcsApi.AddOrder;
        }
    }
}
