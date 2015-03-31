using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	public class AddInvoicePaymentRequest : WhmcsBaseRequest
	{
		[MandatoryParameter]
		[ApiParamName("invoiceid")]
		public string InvoiceId;
		[MandatoryParameter]
		[ApiParamName("transid")]
		public string TransactionId = "";
		[MandatoryParameter]
		[ApiParamName("gateway")]
		public string Gateway = "paypal";

		public AddInvoicePaymentRequest(string invoiceId)
		{
			InvoiceId = invoiceId;
			ApiAction = WhmcsApi.AddInvoicePayment;
		}
	}
}
