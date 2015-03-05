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
		[FieldIgnored]
        [ApiParamName("password2")]
        public string Password2 = "test123";
        
        // Optional parameters
		[ApiParamName("companyname")]
		public string CompanyName;

		public AddClientRequest()
        {
            ApiAction = WhmcsApi.AddClient;
        }
    }
}
