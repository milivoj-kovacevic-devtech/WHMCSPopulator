using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhmcsPopulator
{
	public class WhmcsClient
	{
		// Required attributes

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Address1 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostCode { get; set; }
		public string Country { get; set; } // Two letter ISO country code
		public string PhoneNumber { get; set; }
		public string Password { get; set; }

		// Optional attributes

		public string CompanyName { get; set; }
		public string Address2 { get; set; }
		public string Currency { get; set; }
		public string ClientIp { get; set; }
		public string Language { get; set; }
		public string GroupId { get; set; }
		public string SecurityQuestionId { get; set; }
		public string Notes { get; set; }
		public string CreditCardType { get; set; }
		public string CardNumber { get; set; }
		public string ExpDate { get; set; } // In the format MMYY
		public string StartDate { get; set; }
		public string IssueNumber { get; set; }
		public string CustomFields { get; set; } // A base64 encoded serialized array of custom field values
		public string NoEmail { get; set; } // Pass as true to surpress the client signup welcome email sending
		public string SkipValidation { get; set; } // Set true to not validate or check required fields
	}
}
