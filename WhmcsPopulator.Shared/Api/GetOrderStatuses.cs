using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Shared.Api
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
