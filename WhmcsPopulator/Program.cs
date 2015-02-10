using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WhmcsPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
			// TODO Implement error handling

			ApiCredentials credentials = new ApiCredentials();
			WhmcsApiProxy api = new WhmcsApiProxy(credentials);

			var ids = api.GetClientsIds();
			Console.WriteLine("Client ids: " + ids);

			//WhmcsClient whmcsClient = new WhmcsClient()
			//{
			//	FirstName = "Test",
			//	LastName = "User",
			//	Email = "demo@whmcs.com",
			//	Address1 = "123 Demo Street",
			//	City = "Demo",
			//	State = "Florida",
			//	PostCode = "AB123",
			//	Country = "US",
			//	PhoneNumber = "123456789",
			//	Password = "demo"
			//};

			//api.AddClient(whmcsClient);
        }
    }
}
