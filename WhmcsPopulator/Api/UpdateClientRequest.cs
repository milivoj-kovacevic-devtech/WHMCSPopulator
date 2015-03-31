using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	public class UpdateClientRequest : WhmcsBaseRequest
	{
		[MandatoryParameter]
		[ApiParamName("clientid")]
		public string ClientId;

		[ApiParamName("credit")]
		public string Credit = "10000";

		public UpdateClientRequest(string clientId)
		{
			ClientId = clientId;
			ApiAction = WhmcsApi.UpdateClient;
		}
	}
}
