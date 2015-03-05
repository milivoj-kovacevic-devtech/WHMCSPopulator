using FileHelpers;
using System;
using System.Collections.Generic;
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
		public string DomainName; // TODO Ignore this field, assing value randomized
		[MandatoryParameter]
		[FieldIgnored]
		[ApiParamName("billingcycle")] // onetime, monthly, quarterly, semiannually, etc...
		public string BillingCycle = "monthly";
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
		[FieldIgnored]
		[ApiParamName("paymentmethod")] // paypal, authorize, etc...
		public string PaymentMethod = "paypal";

		// Optional parameters
		[FieldIgnored]
		[ApiParamName("noinvoiceemail")]
		public string NoInvoiceEmail = "true";
		[FieldIgnored]
		[ApiParamName("noemail")]
		public string NoEmail = "true";

		[FieldIgnored]
		private List<string> Domains = new List<string>() { "bulkcloudmigrations.com", "cloudmigrationservice.net", "cloudteleporter.com", "fullyautomatedservices.com" };
		[FieldIgnored]
		private List<string> Products = new List<string>() { "430", "433", "434", "435" };

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
