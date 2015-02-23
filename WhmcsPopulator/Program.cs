using System.Collections.Generic;
using WhmcsPopulator.Api;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator
{
	class MainClass
	{
		private static readonly ApiController ApiController = new ApiController();

		static void Main(string[] args)
		{
			var clients = CsvCollector.Parse<AddClientRequest>(@"D:\test.csv");
			var contacts = CsvCollector.Parse<AddContactRequest>(@"\contacts.csv") as List<AddContactRequest>; // TODO Create csv with contacts and resolve file path
		    var controller = new ApiController();

			foreach (var client in clients)
			{
				string clientId;
				if (!controller.InsertClient(client, out clientId)) continue;

                // steps to be implemented are below

				// foreach parser.getcontacts || for random number of contacts (between 1 and 3/5)
				var contact = new AddContactRequest(); // TODO Get first and remove it from collection.
				if (!controller.InsertContact(contact, clientId)) continue;
				// foreach parser.getorders
				// insert order
				// accept order
			}
		}
	}
}
