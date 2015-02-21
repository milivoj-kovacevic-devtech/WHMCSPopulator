using FileHelpers;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
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
        public string LastName;
        [MandatoryParameter]
        [ApiParamName("email")]
        public string Email;
        [MandatoryParameter]
        [ApiParamName("address1")]
        public string Address1;
        [MandatoryParameter]
        [ApiParamName("city")]
        public string City;
        [MandatoryParameter]
        [ApiParamName("state")]
        public string State;
        [MandatoryParameter]
        [ApiParamName("postcode")]
        public string PostCode;
        [MandatoryParameter]
        [ApiParamName("country")]
        public string Country; // Two letter ISO country code
        [MandatoryParameter]
        [ApiParamName("phonenumber")]
        public string PhoneNumber;
        [MandatoryParameter]
        [ApiParamName("password2")]
        public string Password2;
        
        // Optional parameters
        [ApiParamName("companyname")]
        public string CompanyName;
        [ApiParamName("address2")]
        public string Address2;
        [ApiParamName("currency")]
        public string Currency;
        [ApiParamName("clientip")]
        public string ClientIp;
        [ApiParamName("language")]
        public string Language;
        [ApiParamName("groupid")]
        public string GroupId;
        [ApiParamName("securityqid")]
        public string SecurityQuestionId;
        [ApiParamName("securityqans")]
        public string SecurityQuestionAnswer;
        [ApiParamName("notes")]
        public string Notes;
        [ApiParamName("cctype")]
        public string CreditCardType;
        [ApiParamName("cardnum")]
        public string CardNumber;
        [ApiParamName("expdate")]
        public string ExpDate; // In the format MMYY
        [ApiParamName("startdate")]
        public string StartDate;
        [ApiParamName("issuenumber")]
        public string IssueNumber;
        [ApiParamName("customfields")]
        public string CustomFields; // A base64 encoded serialized array of custom field values
        [ApiParamName("noemail")]
        public string NoEmail; // Pass as true to surpress the client signup welcome email sending
        [ApiParamName("skipvalidation")]
        public string SkipValidation; // Set true to not validate or check required fields

        public AddClientRequest()
            : base()
        {
            ApiAction = WhmcsApi.AddClient;
        }
    }
}
