using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    [DelimitedRecord(",")]
	public class Contact
	{
		// Required attributes

		public string ClientId { get; set; }

		// Optional attributes

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		public string Email { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostCode { get; set; }
		public string Country { get; set; } // Two letter ISO country code
		public string PhoneNumber { get; set; }
		public string Password { get; set; } // If creating sub-account
		public string Permissions { get; set; } // Can specify sub-account permissions eg manageproducts,managedomains
		public string GeneralEmails { get; set; } // Set true to receive general email types
		public string ProductEmails { get; set; } // Set true to receive product related emails
		public string DomainEmails { get; set; } // Set true to receive domain related emails
		public string InvoiceEmails { get; set; } // Set true to receive billing related emails
		public string SupportEmails { get; set; } // Set true to receive support ticket related emails
	}
}
