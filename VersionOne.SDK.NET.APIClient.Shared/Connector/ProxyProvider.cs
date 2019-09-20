﻿using System;
using System.Net;

namespace VersionOne.SDK.APIClient 
{
    public class ProxyProvider
    {
        public readonly Uri Path;
        public readonly string Username;
        public readonly string Password;
        public readonly string Domain;

        private IWebProxy proxy;

        public ProxyProvider(Uri path, string username, string password, string domain = null) 
        {
            Path = path;
            Username = username;
            Password = password;
            Domain = domain;
        }

        private NetworkCredential GetCredential() 
        {
            if (string.IsNullOrEmpty(Username))
            {
                return (NetworkCredential) CredentialCache.DefaultCredentials;
            }

            NetworkCredential credential = new NetworkCredential(Username, Password);
            
            if (Domain != null) 
            {
                credential.Domain = Domain;
            }

            return credential;
        }

        internal IWebProxy CreateWebProxy() 
        {
            if (proxy == null) 
            {
                proxy = new WebProxy(Path, false, new string[0], GetCredential());
            }

            return proxy;
        }
    }
}
