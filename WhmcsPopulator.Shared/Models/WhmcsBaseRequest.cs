using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Shared.Models
{
    public class WhmcsBaseRequest
    {

        [ApiParamName("username")]
        public string UserName { get; set; }
        [ApiParamName("password")]
        public string Password { get; set; }
        [ApiParamName("action")]
        public string ApiAction { get; set; }
        [ApiParamName("responsetype")]
        public string ResponseType { get; set; }

        public string Response { get; set; }

        public void Send()
        {
            Type type = this.GetType();
            var properties = type.GetProperties();

            var request = new RestRequest(Method.POST);
            foreach (var prop in properties)
            {   
                var attr = prop.GetCustomAttributes(true);
                request.AddParameter(attr.ToString(), prop);                
            }
        }
    }
}
