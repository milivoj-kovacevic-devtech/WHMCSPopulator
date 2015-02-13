using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared.Helpers;
using FileHelpers;
using System.Collections;

namespace WhmcsPopulator.Shared
{
    public class CsvCollector
    {
        public List<CsvRow> AllRows { get; set; }
        public string FileLocation { get; set; }

        public CsvCollector(string fileLocation)
        {
            FileLocation = fileLocation;
        }

        public void ReadCsvFile()
        {
            using (CsvFileReader reader = new CsvFileReader(FileLocation))
            {
                AllRows = new List<CsvRow>();
                var row = new CsvRow();

                Console.WriteLine("Start processing csv file...");

                while (reader.ReadRow(row))
                {
                    Console.WriteLine(row.ElementAt(0));
                    AllRows.Add(row);

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

        //public void ReadCsvFile()
        //{
        //    var reader = new StreamReader(File.OpenRead(FileLocation));

        //    CsvRows = new List<CsvRow>();
        //    var row = new CsvRow();

        //    while(!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(',');

        //        foreach (var val in values)
        //        {
        //            row.Add(val);
        //        }
        //        CsvRows.Add(row);
        //    }

        //}

        public IEnumerable<T> ReadWithFileHelper<T>()
        {
            var engine = new FileHelperEngine<T>();
            T[] res = engine.ReadFile(FileLocation);

            for (var i = 0; i < res.Length; i += 1)
            {
                //clients.Add(res[i]);
                yield return res[i];
            }
        }
    }
}
