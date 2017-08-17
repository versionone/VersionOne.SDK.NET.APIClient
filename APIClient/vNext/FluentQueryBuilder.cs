using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VersionOne.SDK.APIClient.vNext
{
	public class FluentQueryBuilder : IFluentQueryBuilder
	{
		private object _querySource;
		private Func<string, IList<dynamic>> _executor;

		public FluentQueryBuilder(object querySource, Func<string, IList<dynamic>> executor)
		{
			//_querySource = (querySource ?? throw new ArgumentNullException(nameof(querySource)));

			if (querySource != null) {
				_querySource = querySource;
			}
			else {
				throw new ArgumentException(nameof(querySource));
			}

			//_executor = executor ?? throw new ArgumentNullException(nameof(executor));
			if (executor != null) {
				_executor = executor;
			}
			else { 
				throw new ArgumentException(nameof(executor));
			}
		}

		public IList<object> Retrieve() => _executor(this.ToString());

		public override string ToString()
		{
			if (_querySource is string)
			{
				var source = _querySource as string;
				return source.Replace(':', '/');
			}

			throw new InvalidOperationException("querySource must be of type string for now...");
		}
		public IList<object> Select(object [] selections)
		{
			IList<object> selectList = new List<object>(null);
			return selectList;
		}
	}
}
