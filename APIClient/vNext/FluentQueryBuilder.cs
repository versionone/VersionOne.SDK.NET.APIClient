using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace VersionOne.SDK.APIClient.vNext
{
	public class FluentQueryBuilder : IFluentQueryBuilder
	{
		private object _querySource;
		private Func<string, IList<dynamic>> _executor;
		public readonly List<object> SelectFields = new List<object>();

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

		public override string ToString() {
			var source = _querySource as string;
			var retObj = new StringBuilder(); 
			var query = new StringBuilder();

			if (!(source is string)) { 
				throw new InvalidOperationException("querySource must be of type string for now...");
			}
			else { 
				retObj.Append( source.Replace(':', '/') );
			}
			if (SelectFields.Count > 0) { 
				var selectFragment = String.Join(",", SelectFields);
				retObj.Append("?sel=" + Uri.EscapeDataString(selectFragment));
			}
			return retObj.ToString();
		}
		public IFluentQueryBuilder Select(params object[] fields)
		{
			SelectFields.AddRange(fields);

			return this;
		}
	}
}
