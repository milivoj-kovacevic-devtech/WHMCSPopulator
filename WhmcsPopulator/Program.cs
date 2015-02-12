using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator
{
    class MainClass
    {
        static void Main(string[] args)
        {
            // TODO Implement error handling in whole solution

            //ApiCredentials credentials = new ApiCredentials();
            //WhmcsApiProxy api = new WhmcsApiProxy(credentials);

            //var ids = api.GetClientsIds();

            //foreach (var s in ids)
            //{
            //    Console.WriteLine("Client id: {0}", s);
            //}

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

            CsvCollector collector = new CsvCollector("D:/test.csv");

            collector.ReadCsvFile();

            foreach (var row in collector.CsvRows)
            {
                Console.WriteLine(row.ElementAt(0));
            }
        }
    }
}
