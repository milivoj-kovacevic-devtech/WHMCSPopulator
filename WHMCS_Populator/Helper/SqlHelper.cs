using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WHMCS_Populator.Helper
{
    // This class might not be needed eventualy
    public class SqlHelper
    {

        public static MySqlConnection WhmcsConnection(string connectionString)
        {
            // TODO Should change this to more dinamic solution
            return new MySqlConnection(connectionString);
        }
}
