using FileHelpers;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	[DelimitedRecord(",")]
    public class AddOrderRequest : WhmcsBaseRequest
    {
        // Required parameters
        [MandatoryParameter]
		[FieldIgnored]
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
		[FieldIgnored]
        [ApiParamName("domaintype")] // set for domain registration - register or transfer
        public string DomainType = string.Empty;
        [MandatoryParameter]
		[FieldIgnored]
        [ApiParamName("regperiod")] // 1,2,3,etc...
        public string RegPeriod = string.Empty;
        [MandatoryParameter]
		[FieldIgnored]
        [ApiParamName("eppcode")] // if domain transfer
        public string EppCode = string.Empty;
        [MandatoryParameter]
		[FieldIgnored]
        [ApiParamName("nameserver1")] // first nameserver (req for domain reg only)
        public string Nameserver1 = string.Empty;
        [MandatoryParameter]
        [ApiParamName("paymentmethod")] // paypal, authorize, etc...
        public string PaymentMethod;

        // Optional parameters
		[FieldIgnored]
		[ApiParamName("noinvoiceemail")]
		public string NoInvoiceEmail = "true";
		[FieldIgnored]
		[ApiParamName("noemail")]
		public string NoEmail = "true";
        // for domain reg only
		//[ApiParamName("contactid")]
		//public string ContactId;
		[FieldIgnored]
        [ApiParamName("dnsmanagement")] // true to enable
        public string DnsManagement = string.Empty;
		//[ApiParamName("domainfields")] // a base64 encoded serialized array of the TLD specific field values
		//public string DomainFields;
		[FieldIgnored]
        [ApiParamName("emailforwarding")] // true to enable
        public string EmailForwarding = "true";
		//[ApiParamName("idprotection")] // true to enable
		//public string IdProtection;
		//[ApiParamName("nameserver2")] // second nameserver
		//public string Nameserver2;
		//[ApiParamName("nameserver3")] // third nameserver
		//public string Nameserver3;
		//[ApiParamName("nameserver4")] // fourth nameserver
		//public string Nameserver4;

        public AddOrderRequest()
        {
            ApiAction = WhmcsApi.AddOrder;
        }
    }
}
