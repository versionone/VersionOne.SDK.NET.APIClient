using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;

namespace VersionOne.SDK.APIClient
{
	[Obsolete("Use VersionOneAPIConnector instead.")]
	public class V1APIConnector : V1CredsAPIConnector
	{
		public V1APIConnector(string urlPrefix, string username = null, string password = null, bool? integratedAuth = null,
							  ProxyProvider proxy = null, OAuth2Client.IStorage storage = null)
			: base(urlPrefix, new CredentialCache(), proxy)
		{
			var cache = _creds as CredentialCache;
			var uri = new Uri(urlPrefix);

			// Try the OAuth2 credential
			OAuth2Client.IStorage oauth2storage = null;
			if (storage != null)
			{
				oauth2storage = storage;
			}
			else
			{
				try
				{
					var s = OAuth2Client.Storage.JsonFileStorage.Default as OAuth2Client.IStorage;
					s.GetSecrets();
					oauth2storage = s;
				}
				catch (System.IO.FileNotFoundException ex)
				{
					// swallowed - meaning no oauth2 secrets configured.
				}
			}
			if (oauth2storage != null)
			{
				cache.Add(uri,
					"Bearer",
					new OAuth2Client.OAuth2Credential(
						"apiv1",
						oauth2storage,
						proxy != null ? proxy.CreateWebProxy() : null
						)
					);
			}

			if (username == null)
			{
				if (integratedAuth.GetValueOrDefault(true))
				{ // no constructor args - so use default integrated identity unless they say no.
					cache.Add(uri, "NTLM", CredentialCache.DefaultNetworkCredentials);
					cache.Add(uri, "Negotiate", CredentialCache.DefaultNetworkCredentials);
				}
			}
			else
			{
				var userPassCred = new NetworkCredential(username, password);
				cache.Add(uri, "Basic", userPassCred);

				if (!integratedAuth.GetValueOrDefault(false))
				{ // If there's a username, we'll assume the user doesn't want Windows Auth unless they ask.
					cache.Add(uri, "NTLM", userPassCred);
					cache.Add(uri, "Negotiate", userPassCred);
				}
			}
		}
	}
}