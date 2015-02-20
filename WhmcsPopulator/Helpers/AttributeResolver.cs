using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WhmcsPopulator.Shared.Api;

namespace WhmcsPopulator
{
    public static class AttributeResolver
    {
        private static ApiParamNameAttribute GetAttribute(IEnumerable<object> attributes)
        {
            return attributes.OfType<ApiParamNameAttribute>().First();
        }

        private static bool HasAttribute(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(true);
            return attributes.OfType<ApiParamNameAttribute>().Any();
        }


    }
}
