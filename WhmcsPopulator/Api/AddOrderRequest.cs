using System;
using System.Collections.Generic;
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
		public string BillingCycle = "monthly";
		[MandatoryParameter]
		[ApiParamName("domaintype")] // set for domain registration - register or transfer
		public string DomainType = string.Empty;
		[MandatoryParameter]
		[ApiParamName("regperiod")] // 1,2,3,etc...
		public string RegPeriod = string.Empty;
		[MandatoryParameter]
		[ApiParamName("eppcode")] // if domain transfer
		public string EppCode = string.Empty;
		[MandatoryParameter]
		[ApiParamName("nameserver1")] // first nameserver (req for domain reg only)
		public string Nameserver1 = string.Empty;
		[MandatoryParameter]
		[ApiParamName("paymentmethod")] // paypal, authorize, etc...
		public string PaymentMethod = "paypal";

		// Optional parameters
		[ApiParamName("noinvoiceemail")]
		public string NoInvoiceEmail = "true";
		[ApiParamName("noemail")]
		public string NoEmail = "true";

		private List<string> Domains = ConfigManager.GetConfigList("domains");
		private List<string> Products = ConfigManager.GetConfigList("products");

		public AddOrderRequest(string clientId)
		{
			var rnd = new Random(); 
			
			ApiAction = WhmcsApi.AddOrder;
			ClientId = clientId;
			ProductId = Products[rnd.Next(Products.Count)];
			DomainName = clientId + "." + Domains[rnd.Next(Domains.Count)];
		}
	}
}
