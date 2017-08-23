using System.Collections.Generic;

namespace VersionOne.SDK.APIClient.vNext
{
	public interface IFluentQueryBuilder
	{
		IList<dynamic> Retrieve();
		IFluentQueryBuilder Select(params object[] fields);
		//IFluentQueryBuilder Where(params object[] pairs);
		IFluentQueryBuilder Where(string attributeName, string stringAttributeValue);
	}
}