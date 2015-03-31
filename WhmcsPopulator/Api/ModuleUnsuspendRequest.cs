using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	public class ModuleUnsuspendRequest : WhmcsBaseRequest
	{
		[ApiParamName("accountid")]
		public string AccountId;

		public ModuleUnsuspendRequest(string accountId)
		{
			ApiAction = WhmcsApi.ModuleUnsuspend;
			AccountId = accountId;
		}
	}
}
