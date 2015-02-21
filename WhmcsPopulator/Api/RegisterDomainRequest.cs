using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    public class RegisterDomainRequest : WhmcsBaseRequest
    {
        // TODO Decide which of these fields will be used for registering domains (if used at all)
        // Required attributes. One of these should be used, no need for both
        [MandatoryParameter]
        [ApiParamName("domainid")]
        public string DomainId;
        [MandatoryParameter]
        [ApiParamName("domain")]
        public string DomainName { get; set; }

        public RegisterDomainRequest()
            : base()
        {
            ApiAction = WhmcsApi.RegisterDomain;
        }
    }
}
