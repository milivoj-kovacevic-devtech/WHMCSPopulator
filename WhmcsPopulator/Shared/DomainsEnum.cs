using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhmcsPopulator.Shared
{
	public enum Domains
	{
		[FullDomain("bulkcloudmigrations.com")]
		Domain1,
		[FullDomain("cloudmigrationservice.net")]
		Domain2,
		[FullDomain("cloudteleporter.com")]
		Domain3,
		[FullDomain("fullyautomatedservices.com")]
		Domain4
	}
}
