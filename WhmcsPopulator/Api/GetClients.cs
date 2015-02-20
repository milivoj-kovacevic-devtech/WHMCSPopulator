using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    public class GetClientsRequest : WhmcsBaseRequest
    {
        // TODO Check if something is missing and process response
        public GetClientsRequest()
            : base()
        {
            ApiAction = WhmcsApi.GetClients;
        }
    }
}
