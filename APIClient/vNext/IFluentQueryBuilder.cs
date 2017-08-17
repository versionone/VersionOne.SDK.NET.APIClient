using System.Collections.Generic;

namespace VersionOne.SDK.APIClient.vNext
{
	public interface IFluentQueryBuilder
	{
		IList<dynamic> Retrieve();
		IList<dynamic> Select(params object[] selections);
	}
}