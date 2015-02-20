using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhmcsPopulator
{
    public class ApiParamNameAttribute : Attribute
    {
        private readonly string _name;

        public string Name 
        {
            get { return _name; }
        }

        public ApiParamNameAttribute(string name)
        {
            _name = name;
        }
    }
}
