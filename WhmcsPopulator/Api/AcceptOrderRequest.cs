using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    public class AcceptOrderRequest : WhmcsBaseRequest
    {
        // Required parameters
        [MandatoryParameter]
        [ApiParamName("orderid")]
        public string OrderId;

        // Optional parameters
        [ApiParamName("serverid")]
        public string ServerId;
        [ApiParamName("serviceusername")] // the Username to assign for provisioning, overrides default
        public string ServiceUserName;
        [ApiParamName("servicepassword")] // the Password to assign for products being provisioned, overrides auto generation
        public string ServicePassword;
        [ApiParamName("registrar")] // the domain registrar module to assign any domains to
        public string Registrar;
        [ApiParamName("autosetup")] // true/false - determines whether product provisioning is performed
        public string AutoSetup;
        [ApiParamName("sendregistrar")] // true/false determines whether domain automation is performed
        public string SendRegistrar;
        [ApiParamName("sendemail")] // true/false - sets if welcome emails for products and registration confirmation emails for domains should be sent
        public string SendEmail;

        public AcceptOrderRequest()
            : base()
        {
            ApiAction = WhmcsApi.AcceptOrder;
        }
    }
}
