using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Shared
{
	public class FullDomainAttribute : Attribute
	{
		private readonly string _name;

		public string Name
		{
			get { return _name; }
		}

		public FullDomainAttribute(string name)
		{
			_name = name;
		}
	}
}
