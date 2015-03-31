using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	public class GetInvoicesRequest : WhmcsBaseRequest
	{
		[ApiParamName("status")]
		public string Status = "Overdue"; // TODO Change if other types of invoices are needed
		[ApiParamName("limitnum")]
		public string LimitNum = "4000"; // Set to limit the number of invoices to get

		public GetInvoicesRequest()
		{
			ApiAction = WhmcsApi.GetInvoices;
		}
	}
}
