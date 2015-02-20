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
    public static class CsvCollector
    {
        public static IEnumerable<T> ReadWithFileHelper<T>(string fileLocation)
        {
            var engine = new FileHelperEngine<T>();
            T[] res = engine.ReadFile(fileLocation);

            for (var i = 0; i < res.Length; i += 1)
            {
                //clients.Add(res[i]);
                yield return res[i];
            }
        }
    }
}
