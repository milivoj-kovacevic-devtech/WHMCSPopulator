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
