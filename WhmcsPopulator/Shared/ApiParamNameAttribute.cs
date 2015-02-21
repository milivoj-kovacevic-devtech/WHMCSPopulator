using System;

namespace WhmcsPopulator.Shared
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
