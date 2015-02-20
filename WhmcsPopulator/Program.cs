using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Helpers;

namespace WhmcsPopulator
{
	class MainClass
	{
		private static readonly ApiController ApiController = new ApiController();

		static void Main(string[] args)
		{
			var clients = CsvCollector.Parse<AddClientRequest>(@"D:\test.csv");


			foreach (var client in clients)
			{
				string clientId;
				if (!ApiController.InsertClient(client, out clientId)) continue;

				// option 2
				clientId = ApiController.InsertClient(client);
				if (string.IsNullOrEmpty(clientId)) continue;

				// foreach parser.getcontacts
				// insert contact
				// foreach parser.getorders
				// insert order
				// accept order
			}
		}
	}
}
