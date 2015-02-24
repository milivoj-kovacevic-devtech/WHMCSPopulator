using System;
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
			var clients = CsvCollector.Parse<AddClientRequest>(@"D:\clients.csv");
			var contacts = new List<AddContactRequest>(CsvCollector.Parse<AddContactRequest>(@"D:\contacts.csv"));
		    var controller = new ApiController();
			var rnd = new Random();

			foreach (var client in clients)
			{
				string clientId;
				if (!controller.InsertClient(client, out clientId)) continue;
				var numOfContacts = rnd.Next(4);
				if (numOfContacts == 0)
				{
					var contactWithNoData = new AddContactRequest();
					if (!controller.InsertContact(contactWithNoData, clientId)) continue;
				}
				else
				{
					for (var i = 0; i <= numOfContacts; i++)
					{
						if (contacts.Count == 0) continue; // if there are no more contacts in list
						var contact = contacts[0]; // TODO Get first and remove it from collection.
						contacts.RemoveAt(0);
						if (!controller.InsertContact(contact, clientId)) continue;
					}
				}
				// foreach parser.getcontacts || for random number of contacts (between 1 and 3/5)
				// foreach parser.getorders
				// insert order
				// accept order
			}
		}
	}
}
