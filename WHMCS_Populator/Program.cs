using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WHMCS_Populator
{
    class Program
    {
        static void Main(string[] args)
        {
			var userName = "zoran.prole";
			var password = "cc03e747a6afbbcbf8be7668acfebee5";

			WebRequest request = WebRequest.Create("http://178.248.110.214/whmcs/includes/api.php");
			request.Credentials = new NetworkCredential(userName, password);

			((HttpWebRequest)request).UserAgent = ".Net Framework Test";
			request.Method = "POST";
			request.ContentLength = 92;
			request.ContentType = "application/x-www-form-urlencoded";

			Stream dataStream = request.GetRequestStream();
			// TODO Implement

			WebResponse response = request.GetResponse();
        }
    }
}
