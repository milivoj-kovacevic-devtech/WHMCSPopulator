using System.Configuration;

namespace WhmcsPopulator.Shared
{
    public static class ConfigManager
    {
        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        public static string AdminUsername = ConfigurationManager.AppSettings["WhmcsAdmin"];
        public static string AdminPassword = Md5Hasher.CreateMd5Hash(ConfigurationManager.AppSettings["WhmcsAdminPassword"]);
    }
}
