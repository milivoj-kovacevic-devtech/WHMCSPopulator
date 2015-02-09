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
			ApiCredentials credentials = new ApiCredentials();
			WhmcsApiProxy api = new WhmcsApiProxy(credentials);

			var ids = api.GetClientsIds();
			Console.WriteLine("Client ids: " + ids);	
		
			WhmcsClient whmcsClient = new WhmcsClient();
			whmcsClient.FirstName = "Test";
			whmcsClient.LastName = "User";
			whmcsClient.Email = "demo@whmcs.com";
			whmcsClient.Address1 = "123 Demo Street";
			whmcsClient.City = "Demo";
			whmcsClient.State = "Florida";
			whmcsClient.PostCode = "AB123";
			whmcsClient.Country = "US";
			whmcsClient.PhoneNumber = "123456789";
			whmcsClient.Password = "demo";

			api.AddClient(whmcsClient);
        }
    }
}
