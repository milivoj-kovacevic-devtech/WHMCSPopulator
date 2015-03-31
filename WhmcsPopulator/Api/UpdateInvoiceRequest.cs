using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	public class UpdateInvoiceRequest : WhmcsBaseRequest
	{
		[ApiParamName("invoiceid")]
		public string InvoiceId;
		[ApiParamName("status")]
		public string Status = "Paid";

		public UpdateInvoiceRequest(string invoiceId)
		{
			InvoiceId = invoiceId;
			ApiAction = WhmcsApi.UpdateInvoice;
		}
	}
}
