using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
namespace VersionOne.SDK.APIClient.vNext
{
	public class FluentQueryBuilder : IFluentQueryBuilder
	{
		private object _querySource;
		private Func<string, IList<dynamic>> _executor;
		public readonly List<object> SelectFields = new List<object>();
		public List<object> whereClauseElements = new List<object>();
		//StringBuilder currentQueryToken = new StringBuilder("?");
		private char currentQueryToken = '?';
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
//Set up serverUrl/rest-1.v1/Data/Asset
			
			if (!(source is string)) { 
				throw new InvalidOperationException("querySource must be of type string for now...");
			}
			else { 
				retObj.Append( source.Replace(':', '/') );
			}
//Set up  ?sel=attribute1, attribute 2, ...
			if (SelectFields.Count > 0) { 
				var selectFragment = String.Join(",", SelectFields);
				
				retObj.Append(currentQueryToken + "sel=" + Uri.EscapeDataString(selectFragment));
				currentQueryToken = '&';
			}

//Set up  Where( sel=attribute1, attribute 2, ...
			if (whereClauseElements.Count > 0) {
				StringBuilder tempWhere = new StringBuilder(); 
				StringBuilder finalClausArrangement = new StringBuilder();
				char[] delimiters = {'='};

				foreach (object piece in whereClauseElements) {
				// now parse the damn string
					//piece.Split(delimiters);
				}
				var finalClauseArrangement =  Convert.ToString(whereClauseElements[0]);
				retObj.Append(Uri.EscapeDataString(currentQueryToken + "where=" + finalClauseArrangement));
			}
			return retObj.ToString();
		}
//Set up

		public IFluentQueryBuilder Select(params object[] fields) {
			SelectFields.AddRange(fields);

			return this;
		}

		internal List <string> parseWhereClause(string singleExpression)
		{
			List<string> parsedList = new List<string>();

			return parsedList;
		}
		public IFluentQueryBuilder Where(params object[] pairs)
		{
			whereClauseElements.AddRange(pairs);
			return this;

		}
	}
}
