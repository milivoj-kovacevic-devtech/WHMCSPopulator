using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator
{
    public class GetOrderStatuses : WhmcsBaseRequest
    {
        public GetOrderStatuses()
            : base()
        {
            ApiAction = WhmcsApi.GetOrderStatuses;
        }
    }
}
