using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator
{
    [DelimitedRecord(",")]
    public class AddClientRequest : WhmcsBaseRequest
    {
        // Required parameters
        [FieldIgnored]
        public string ClientId;
        [MandatoryParameter]
        [ApiParamName("firstname")]
        public string FirstName;
        [MandatoryParameter]
        [ApiParamName("lastname")]
        public string LastName { get; set; }
        [MandatoryParameter]
        [ApiParamName("email")]
        public string Email { get; set; }
        [MandatoryParameter]
        [ApiParamName("address1")]
        public string Address1 { get; set; }
        [MandatoryParameter]
        [ApiParamName("city")]
        public string City { get; set; }
        [MandatoryParameter]
        [ApiParamName("state")]
        public string State { get; set; }
        [MandatoryParameter]
        [ApiParamName("postcode")]
        public string PostCode { get; set; }
        [MandatoryParameter]
        [ApiParamName("country")]
        public string Country { get; set; } // Two letter ISO country code
        [MandatoryParameter]
        [ApiParamName("phonenumber")]
        public string PhoneNumber { get; set; }
        [MandatoryParameter]
        [ApiParamName("password2")]
        public string Password2 { get; set; }
        
        // Optional parameters
        [ApiParamName("companyname")]
        public string CompanyName { get; set; }
        [ApiParamName("address2")]
        public string Address2 { get; set; }
        [ApiParamName("currency")]
        public string Currency { get; set; }
        [ApiParamName("clientip")]
        public string ClientIp { get; set; }
        [ApiParamName("language")]
        public string Language { get; set; }
        [ApiParamName("groupid")]
        public string GroupId { get; set; }
        [ApiParamName("securityqid")]
        public string SecurityQuestionId { get; set; }
        [ApiParamName("securityqans")]
        public string SecurityQuestionAnswer { get; set; }
        [ApiParamName("notes")]
        public string Notes { get; set; }
        [ApiParamName("cctype")]
        public string CreditCardType { get; set; }
        [ApiParamName("cardnum")]
        public string CardNumber { get; set; }
        [ApiParamName("expdate")]
        public string ExpDate { get; set; } // In the format MMYY
        [ApiParamName("startdate")]
        public string StartDate { get; set; }
        [ApiParamName("issuenumber")]
        public string IssueNumber { get; set; }
        [ApiParamName("customfields")]
        public string CustomFields { get; set; } // A base64 encoded serialized array of custom field values
        [ApiParamName("noemail")]
        public string NoEmail { get; set; } // Pass as true to surpress the client signup welcome email sending
        [ApiParamName("skipvalidation")]
        public string SkipValidation { get; set; } // Set true to not validate or check required fields

        public AddClientRequest()
            : base()
        {
            ApiAction = WhmcsApi.AddClient;
        }


    }
}
