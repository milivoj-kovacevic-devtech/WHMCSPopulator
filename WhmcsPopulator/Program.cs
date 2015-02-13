using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;
using WhmcsPopulator.Shared.Models;

namespace WhmcsPopulator
{
    class MainClass
    {
        static void Main(string[] args)
        {
            // TODO Implement error handling in whole solution

            ApiCredentials credentials = new ApiCredentials();
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

            CsvCollector collector = new CsvCollector(@"D:/test.csv");

            //collector.ReadCsvFile();

            //foreach (var row in collector.AllRows)
            //{
            //    foreach (var s in row)
            //    {
            //        Console.Write(s + " ");
            //    }
            //    Console.WriteLine();
            //}

            //var results = new List<Client>();

            //var results = collector.ReadWithFileHelper<Client>();
            
            //Type type = typeof(Client);
            //PropertyInfo[] properties = type.GetProperties();

            //foreach (var res in results)
            //{
            //    foreach (var property in properties)
            //    {
            //        Console.WriteLine("{0} = {1}", property.Name, property.GetValue(res, null));
            //    }
            //}

            var baseReq = new WhmcsBaseRequest();
            baseReq.UserName = credentials.UserName;
            baseReq.Password = credentials.Password;
            baseReq.ApiAction = "getclients";
            baseReq.ResponseType = "json";

            Type type = typeof(WhmcsBaseRequest);
            var attrs = type.GetCustomAttributes(true);

            foreach (var attr in attrs)
            {

                var a = (ApiParamNameAttribute)attr;
                Console.WriteLine(String.Format(a.Name));
            }
        }
    }
}
