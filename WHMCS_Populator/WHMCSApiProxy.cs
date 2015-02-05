using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMCS_Populator
{
    class WHMCSApiProxy
    {
        internal struct WHMCSApi
        {
            public const string AddClient = "addclient";
            public const string GetClients = "getclients";
            public const string AddContact = "addcontact";

            public const string ModuleCreate = "modulecreate";
        }
    }
}
