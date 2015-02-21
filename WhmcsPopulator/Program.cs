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


			foreach (var client in clients)
			{
				string clientId;
				if (!ApiController.InsertClient(client, out clientId)) continue;

				// option 2 (maybe to use instead of 2 lines above)
                //clientId = ApiController.InsertClient(client);
                //if (string.IsNullOrEmpty(clientId)) continue;

                // steps to be implemented are below

				// foreach parser.getcontacts
				// insert contact
				// foreach parser.getorders
				// insert order
				// accept order
			}
		}
	}
}
