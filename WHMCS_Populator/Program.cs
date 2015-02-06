using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WHMCS_Populator
{
    class Program
    {
        static void Main(string[] args)
        {
			var userName = "zoran.prole";
			var password = "cc03e747a6afbbcbf8be7668acfebee5";

            var client = new RestClient("http://178.248.110.214/whmcs/includes/api.php");
			//client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var request = new RestRequest(Method.POST);
			request.AddParameter("username", userName);
			request.AddParameter("password", password);
            request.AddParameter("action", "getclients");
            request.AddParameter("responsetype", "json");

			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            var response = client.Execute(request) as RestResponse;
            var content = response.Content;

            Console.WriteLine(content);
        }
    }
}
