using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    public static class ConfigManager
    {
        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        public static string AdminUsername = ConfigurationManager.AppSettings["WhmcsAdmin"];
        public static string AdminPassword = Md5Hasher.CreateMD5Hash(ConfigurationManager.AppSettings["WhmcsAdminPassword"]);
    }
}
