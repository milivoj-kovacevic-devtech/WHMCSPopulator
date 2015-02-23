using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	public class ModuleCreateRequest : WhmcsBaseRequest
	{
		[ApiParamName("accountid")]
		public string AccountId;

		public ModuleCreateRequest(string accountId)
		{
			ApiAction = WhmcsApi.ModuleCreate;
			AccountId = accountId;
		}
	}
}
