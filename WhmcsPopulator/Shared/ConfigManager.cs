using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace WhmcsPopulator.Shared
{
    public static class ConfigManager
    {
        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        public static string AdminUsername = ConfigurationManager.AppSettings["WhmcsAdmin"];
        public static string AdminPassword = Md5Hasher.CreateMd5Hash(ConfigurationManager.AppSettings["WhmcsAdminPassword"]);

		public static string ClientsCsv = ConfigurationManager.AppSettings["clients"];
		public static string ContactsCsv = ConfigurationManager.AppSettings["contacts"];

		public static List<string> GetConfigList(string sectionName)
		{
			var elementsList = new List<string>();
			var elements = ConfigurationManager.GetSection(sectionName) as NameValueCollection;
			if (elements != null)
			{
				foreach (var key in elements.AllKeys)
				{
					var elementValue = elements.GetValues(key).FirstOrDefault();
					elementsList.Add(elementValue);
				}
			}
			return elementsList;
		}
    }
}
