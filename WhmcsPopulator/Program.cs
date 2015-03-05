using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using WhmcsPopulator.Api;
using WhmcsPopulator.Shared;

namespace WhmcsPopulator
{
	class MainClass
	{
		private static readonly ApiController ApiController = new ApiController();
		private static readonly ILog Log = LogManager.GetLogger(typeof(MainClass));

		static void Main(string[] args)
		{
			XmlConfigurator.Configure();
			Log.Info("Main program init...");

			Log.Debug("Parsing clients csv file...");
			var clients = CsvCollector.Parse<AddClientRequest>(@"D:\clients.csv");
			Log.Debug("Parsing contacts csv file...");
			var contacts = new List<AddContactRequest>(CsvCollector.Parse<AddContactRequest>(@"D:\contacts.csv"));
			var rnd = new Random();
			Log.Debug("Parsing done.");

			foreach (var client in clients)
			{
				Log.Info("Adding clients, contacts and orders loop start.");
				string clientId;
				if (!ApiController.InsertClient(client, out clientId)) continue;
				// adding contacts
				var numOfContacts = rnd.Next(4);
				if (numOfContacts == 0)
				{
					var contactWithNoData = new AddContactRequest();
					if (!ApiController.InsertContact(contactWithNoData, clientId)) continue;
				}
				else
				{
					for (var i = 0; i <= numOfContacts; i++)
					{
						if (contacts.Count == 0) continue; // if there are no more contacts in list
						var contact = contacts[0];
						contacts.RemoveAt(0);
						if (!ApiController.InsertContact(contact, clientId)) continue;
					}
				}
				// adding orders
				if (!ApiController.InsertOrder(clientId)) continue;
				if (!ApiController.ActivateSubscriptions(clientId)) continue;
				Log.Info("Adding clients, contacts and orders loop end.");
			}

			//ApiController.ActivateSubscriptions("80");
			Log.Info("Main program end.");
		}
	}
}
