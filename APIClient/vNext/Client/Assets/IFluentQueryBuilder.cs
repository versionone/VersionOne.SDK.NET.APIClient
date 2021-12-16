using System.Collections.Generic;

namespace VersionOne.Assets
{
	public interface IFluentQueryBuilder
	{
		IFluentQueryBuilder Select(params object[] fields);
		IFluentQueryBuilder Where(params Term[] criteria);
		IFluentQueryBuilder Where(string attributeName, string matchValue);
		IFluentQueryBuilder Filter(string attributeName, string op, object filterValue);
		IFluentQueryBuilder Filter(string attributeName, ComparisonOperator op, object filterValue);
		IFluentQueryBuilder Filter(params Term[] criteria);
		IFluentQueryBuilder Paging(int pageSize, int pageStart = 0);
		IList<IAsset> Retrieve();
		IAsset RetrieveFirst();
	}
}