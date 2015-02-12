using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared.Helpers;

namespace WhmcsPopulator.Shared
{
    public class CsvCollector
    {
        public List<CsvRow> CsvRows { get; set; }
        public string FileLocation { get; set; }

        public CsvCollector(string fileLocation)
        {
            FileLocation = fileLocation;
        }

        public void ReadCsvFile()
        {
            using (CsvFileReader reader = new CsvFileReader(FileLocation)) 
            {
                CsvRows = new List<CsvRow>();
                CsvRow row = new CsvRow();

                Console.WriteLine("Start processing csv file...");

                while (reader.ReadRow(row))
                {
                    Console.WriteLine(row.ElementAt(0));
                    CsvRows.Add(row);

                    row = new CsvRow();
                    //// test
                    //foreach (string s in row)
                    //{
                    //    Console.Write(s + " ");
                    //}
                    //// go to new line
                    //Console.WriteLine();
                }
                Console.WriteLine("Csv file processed.");
            }
        }

            /*
        public void ReadCsvFile()
        {

             
             * CsvRows = new List<CsvRow>();
             * var row = new CsvRow();
             * 
             * while(reader.read())
             * {
             * row = GetRow()
             * CsvRows.Add(row);
             * }
            
        } */
    }
}
