using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Shared.Api
{
    class AddContactRequest : WhmcsBaseRequest
    {
        // Required parameters
        [ApiParamName("clientid")]
        public string ClientId { get; set; }

        // Optional parameters
        [ApiParamName("firstname")]
        public string FirstName { get; set; }
        [ApiParamName("lastname")]
        public string LastName { get; set; }
        [ApiParamName("companyname")]
        public string CompanyName { get; set; }
        [ApiParamName("email")]
        public string Email { get; set; }
        [ApiParamName("address1")]
        public string Address1 { get; set; }
        [ApiParamName("address2")]
        public string Address2 { get; set; }
        [ApiParamName("city")]
        public string City { get; set; }
        [ApiParamName("state")]
        public string State { get; set; }
        [ApiParamName("postcode")]
        public string PostCode { get; set; }
        [ApiParamName("country")]
        public string Country { get; set; } // Two letter ISO country code
        [ApiParamName("phonenumber")]
        public string PhoneNumber { get; set; }
        [ApiParamName("password2")]
        public string Password { get; set; } // If creating sub-account
        [ApiParamName("permissions")]
        public string Permissions { get; set; } // Can specify sub-account permissions eg manageproducts,managedomains
        [ApiParamName("generalemails")]
        public string GeneralEmails { get; set; } // Set true to receive general email types
        [ApiParamName("productemails")]
        public string ProductEmails { get; set; } // Set true to receive product related emails
        [ApiParamName("domainemails")]
        public string DomainEmails { get; set; } // Set true to receive domain related emails
        [ApiParamName("invoiceemails")]
        public string InvoiceEmails { get; set; } // Set true to receive billing related emails
        [ApiParamName("supportemails")]
        public string SupportEmails { get; set; } // Set true to receive support ticket related emails

        // TODO Check if something is missing and process response
        public AddContactRequest() 
            : base()
        {
            ApiAction = WhmcsApi.AddContact;
        }
    }
}
