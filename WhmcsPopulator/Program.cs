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
			var rnd = new Random();

			//foreach (var client in clients)
			//{
			//	string clientId;
			//	if (!ApiController.InsertClient(client, out clientId)) continue;
			//	// adding contacts
			//	var numOfContacts = rnd.Next(4);
			//	if (numOfContacts == 0)
			//	{
			//		var contactWithNoData = new AddContactRequest();
			//		if (!ApiController.InsertContact(contactWithNoData, clientId)) continue;
			//	}
			//	else
			//	{
			//		for (var i = 0; i <= numOfContacts; i++)
			//		{
			//			if (contacts.Count == 0) continue; // if there are no more contacts in list
			//			var contact = contacts[0];
			//			contacts.RemoveAt(0);
			//			if (!ApiController.InsertContact(contact, clientId)) continue;
			//		}
			//	}
			//	// adding orders
			//	var order = new AddOrderRequest(); // TODO Create csv for orders and get orders from file
			//	if (!ApiController.InsertOrder(order, clientId)) continue;
			//	if (!ApiController.ActivateSubscriptions(clientId)) continue;
			//}

			ApiController.ActivateSubscriptions("80");
		}
	}
}
