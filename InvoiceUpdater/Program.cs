using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared;

namespace InvoiceUpdater
{
	class Program
	{
		private static readonly ApiController ApiController = new ApiController();

		static void Main(string[] args)
		{
			// Reading csv file with ids of suspended clients
			var reader = new StreamReader(File.OpenRead(@"D:\unpaid.csv"));
			var invoiceIds = new List<string>();
			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				invoiceIds.Add(line);
			}

			// Changing status to overdue
			foreach (var id in invoiceIds)
			{
				Console.WriteLine("Updating invoice payment: " + id);
				if (!ApiController.PayInvoice(id)) throw new Exception("Error updating invoice payment");
			}
	

			//// Getting and changing invoice status
			//var overdueInvoicesIds = new List<string>();

			//try
			//{
			//	if (!ApiController.GetInvoices(out overdueInvoicesIds)) throw new Exception("Error getting invoices.");
			//	foreach (var id in overdueInvoicesIds)
			//	{
			//		Console.WriteLine("Updating invoice: " + id);
			//		if (!ApiController.UpdateInvoice(id)) throw new Exception("Error updating invoice");
			//	}
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}

			// Manualy unsuspending domains (should not do it this way)
			//foreach (var id in accountIds)
			//{
			//	try
			//	{
			//		if (!ApiController.UnsuspendModule(id)) continue;
			//	}
			//	catch (Exception ex)
			//	{
			//		Console.WriteLine(ex.Message);
			//	}
			//}
		}
	}
}
