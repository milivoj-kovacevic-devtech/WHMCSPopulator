using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhmcsPopulator.Shared.Models
{
    public class ApiParamNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ApiParamNameAttribute(string name)
        {
            Name = name;
        }
    }
}
