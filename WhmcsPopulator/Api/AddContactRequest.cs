using FileHelpers;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator.Api
{
	[DelimitedRecord(",")]
	public class AddContactRequest : WhmcsBaseRequest
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
		[ApiParamName("email")]
		public string Email;
		[ApiParamName("address1")]
		public string Address1;
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
		[FieldIgnored]
		[ApiParamName("password2")]
		public string Password2 = "test123"; // If creating sub-account
		[ApiParamName("companyname")]
		public string CompanyName;

		public AddContactRequest()
		{
			ApiAction = WhmcsApi.AddContact;
		}
	}
}
