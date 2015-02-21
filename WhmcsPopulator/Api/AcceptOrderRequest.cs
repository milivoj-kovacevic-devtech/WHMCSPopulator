namespace WhmcsPopulator.Api
{
    public class AcceptOrderRequest : WhmcsBaseRequest
    {
        // Required parameters
        [ApiParamName("orderid")]
        public string OrderId { get; set; }

        // Optional parameters
        [ApiParamName("serverid")]
        public string ServerId { get; set; }
        [ApiParamName("serviceusername")] // the Username to assign for provisioning, overrides default
        public string ServiceUserName { get; set; }
        [ApiParamName("servicepassword")] // the Password to assign for products being provisioned, overrides auto generation
        public string ServicePassword { get; set; }
        [ApiParamName("registrar")] // the domain registrar module to assign any domains to
        public string Registrar { get; set; }
        [ApiParamName("autosetup")] // true/false - determines whether product provisioning is performed
        public string AutoSetup { get; set; }
        [ApiParamName("sendregistrar")] // true/false determines whether domain automation is performed
        public string SendRegistrar { get; set; }
        [ApiParamName("sendemail")] // true/false - sets if welcome emails for products and registration confirmation emails for domains should be sent
        public string SendEmail { get; set; }

        public AcceptOrderRequest()
            : base()
        {
            ApiAction = WhmcsApi.AcceptOrder;
        }

        // TODO Process response
    }
}
