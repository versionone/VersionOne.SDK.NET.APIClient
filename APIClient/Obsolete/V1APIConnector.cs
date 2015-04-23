using System;
using System.Net;

namespace VersionOne.SDK.APIClient
{
    [Obsolete("Use V1Connector instead.")]
    public class V1APIConnector : V1CredsAPIConnector
    {
        public V1APIConnector(string urlPrefix, string username = null, string password = null, bool? integratedAuth = null,
                              ProxyProvider proxy = null)
            : base(urlPrefix, new CredentialCache(), proxy)
        {
            var cache = _creds as CredentialCache;
            var uri = new Uri(urlPrefix);

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