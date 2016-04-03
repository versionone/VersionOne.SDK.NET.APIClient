using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiVNext;
using VersionOne.SDK.APIClient;

namespace GettingStarted.ApiVNext
{
	public static class ServicesExtensions
	{
		public static FluentQuery Query(this IServices services, string assetTypeName)
		{
			return new FluentQuery(assetTypeName, services.Meta);
		}
	}
}
