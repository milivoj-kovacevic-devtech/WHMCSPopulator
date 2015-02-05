using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WHMCS_Populator.Helper
{
    public class SqlHelper
    {

        public static MySqlConnection WhmcsConnection(string connectionString)
        {
            // TODO Should change this to more dinamic solution
            return new MySqlConnection(connectionString);
        }

        public static string SelectClientsIds()
        {
            var queryBuilder = new SelectQueryBuilder();
            string client = String.Empty; // TODO Change this to const with table name

            queryBuilder.SelectFromTable(client);
            queryBuilder.SelectColumns(client + ".id", client + ".parent_id"); // TODO Change this to match whmcs db
        }
    }
}
