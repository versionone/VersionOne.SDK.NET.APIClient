using System;
using System.Collections.Generic;
using System.IO;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("This class has been deprecated.")]
	public class Localizer : ILocalizer
	{
		private readonly IDictionary<string,string> _map = new Dictionary<string,string>();
		private readonly IAPIConnector _connector;

		public Localizer(IAPIConnector connector)
		{
			_connector = connector;
		}

		public string Resolve(string key)
		{
			string result;
			if (!_map.TryGetValue(key, out result))
			{
				try
				{
					using (StreamReader reader = new StreamReader(_connector.GetData("?" + key)))
						result = _map[key] = reader.ReadToEnd();
				}
				catch
				{
					return key;
				}
			}
			return result;
		}
	}
}