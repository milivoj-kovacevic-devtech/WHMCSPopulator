using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhmcsPopulator
{
	public class WhmcsClient
	{
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

		// TODO Create constructor which will take data from file (or something like that)
	}
}
