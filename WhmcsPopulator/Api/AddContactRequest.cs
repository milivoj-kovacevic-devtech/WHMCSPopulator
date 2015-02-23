using FileHelpers;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
    class AddContactRequest : WhmcsBaseRequest
    {
        // Required parameters
        [FieldIgnored]
		[MandatoryParameter]
        [ApiParamName("clientid")]
        public string ClientId;

        // Optional parameters
        [ApiParamName("firstname")]
        public string FirstName;
        [ApiParamName("lastname")]
        public string LastName;
        [ApiParamName("companyname")]
        public string CompanyName;
        [ApiParamName("email")]
        public string Email;
        [ApiParamName("address1")]
        public string Address1;
        [ApiParamName("address2")]
        public string Address2;
        [ApiParamName("city")]
        public string City;
        [ApiParamName("state")]
        public string State;
        [ApiParamName("postcode")]
        public string PostCode;
        [ApiParamName("country")]
        public string Country; // Two letter ISO country code
        [ApiParamName("phonenumber")]
        public string PhoneNumber;
        [ApiParamName("password2")]
        public string Password; // If creating sub-account
        [ApiParamName("permissions")]
        public string Permissions; // Can specify sub-account permissions eg manageproducts,managedomains
        [ApiParamName("generalemails")]
        public string GeneralEmails; // Set true to receive general email types
        [ApiParamName("productemails")]
        public string ProductEmails; // Set true to receive product related emails
        [ApiParamName("domainemails")]
        public string DomainEmails; // Set true to receive domain related emails
        [ApiParamName("invoiceemails")]
        public string InvoiceEmails; // Set true to receive billing related emails
        [ApiParamName("supportemails")]
        public string SupportEmails; // Set true to receive support ticket related emails

        public AddContactRequest() 
            : base()
        {
            ApiAction = WhmcsApi.AddContact;
        }
    }
}
