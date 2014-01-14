using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using OAuth2Client;

namespace VersionOne.SDK.APIClient
{
	public class V1OAuth2APIConnector : V1APIConnector
	{
		public V1OAuth2APIConnector(string urlPrefix, IStorage storage = null, ProxyProvider proxy = null)
			: base(urlPrefix, storage: storage, proxy: proxy) { }
	}
}
