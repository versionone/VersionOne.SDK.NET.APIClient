using System;
using System.Collections.Generic;

namespace VersionOne.SDK.APIClient.vNext
{
	public class FluentQueryBuilder : IFluentQueryBuilder
	{
		private object _querySource;
		private Func<string, IList<dynamic>> _executor;

		public FluentQueryBuilder(object querySource, Func<string, IList<dynamic>> executor)
		{
			_querySource = querySource ?? throw new ArgumentNullException(nameof(querySource));
			_executor = executor ?? throw new ArgumentNullException(nameof(executor));
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
	}
}
