using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    class MainClass
    {
        static void Main(string[] args)
        {
            var clients = CsvCollector.Parse<AddClientRequest>(@"D:\test.csv");
        }
    }
}
