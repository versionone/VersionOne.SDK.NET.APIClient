using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;

namespace VersionOne.SDK.APIClient {

    public class V1APIConnector : V1CredsAPIConnector
    {
		public V1APIConnector(string urlPrefix, string username = null, string password = null, bool? integratedAuth = null, 
		                      ProxyProvider proxy = null, OAuth2Client.IStorage storage = null)
            : base(urlPrefix, new CredentialCache(), proxy)
		{
            var cache = _creds as CredentialCache;
            var uri = new Uri(urlPrefix);

            // Always attach the OAuth2 credential
            var oauth2storage = storage ?? OAuth2Client.Storage.JsonFileStorage.Default;
            cache.Add(uri,
                "Bearer",
                new OAuth2Client.OAuth2Credential(
                    "apiv1",
                    oauth2storage,
                    proxy != null ? proxy.CreateWebProxy() : null
                    )
                );

			if(username == null)
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