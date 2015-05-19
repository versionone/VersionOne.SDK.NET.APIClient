using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace VersionOne.SDK.APIClient.Tests
{
    internal delegate string ResolveDelegate(XmlNode node);

    internal abstract class ResponseConnector : IAPIConnector
    {
        private IDictionary _data = new Hashtable();
        private string _prefix = string.Empty;

        public ResponseConnector(string datafile, string prefix, string keys, ResolveDelegate resolver)
        {
            _prefix = prefix;

            if (keys == null || keys == string.Empty)
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(GetResource(datafile));

            string[] parts = keys.Split(';');

            foreach (string part in parts)
            {
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("Test[@name='" + part + "']");
                if (nodes.Count == 0)
                    continue;
                XmlNode node = nodes[0];
                XmlNodeList responses = node.SelectNodes("Response");
                foreach (XmlElement response in responses)
                    _data[response.GetAttribute("path")] = resolver(response);
            }
        }

        private string _upstreamUserAgent = string.Empty;

        public void SetUpstreamUserAgent(string userAgent)
        {
            _upstreamUserAgent = userAgent;
        }
        public Stream GetResource(string datafile)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string ns = this.GetType().Namespace;
            return assembly.GetManifestResourceStream(ns + "." + datafile);
        }

        public Stream GetData()
        {
            OnBeforeGetData(string.Empty);
            return FindData(string.Empty);
        }

        public Stream GetData(string path)
        {
            OnBeforeGetData(path);
            return FindData(path);
        }


        public Stream SendData(string path, string data)
        {
            OnBeforeSendData(path, data);
            return FindData(path);
        }

        public Stream BeginRequest(string path)
        {
            throw new NotImplementedException();
        }

        public Stream EndRequest(string path, string contentType)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> CustomHttpHeaders
        {
            get { throw new NotImplementedException(); }
        }

        private bool _instrument = false;
        public bool Instrument
        {
            get { return false; }
            set { _instrument = value; }
        }

        private Stream FindData(string path)
        {
            string data = (string)_data[_prefix + path];
            if (data == null)
                throw new ApplicationException("Response Connector missing data for path: " + _prefix + path);
            return new MemoryStream(Encoding.ASCII.GetBytes(data));
        }

        internal delegate void OnDataHandler(object sender, DataRequestEventArgs e);

        private void OnBeforeGetData(string path)
        {
            if (_beforeGetData != null)
                _beforeGetData(this, new DataRequestEventArgs(path));
        }

        private event OnDataHandler _beforeGetData;
        internal event OnDataHandler BeforeGetData
        {
            add { _beforeGetData += value; }
            remove { _beforeGetData -= value; }
        }

        private void OnBeforeSendData(string path, string data)
        {
            if (_beforeSendData != null)
                _beforeSendData(this, new DataRequestEventArgs(path, data));
        }

        private event OnDataHandler _beforeSendData;
        internal event OnDataHandler BeforeSendData
        {
            add { _beforeSendData += value; }
            remove { _beforeSendData -= value; }
        }
    }

    internal class XmlResponseConnector : ResponseConnector
    {
        public XmlResponseConnector(string datafile, string prefix, string keys) : base(datafile, prefix, keys, new ResolveDelegate(ResolveContent)) { }
        private static string ResolveContent(XmlNode node)
        {
            return node.InnerXml;
        }
    }

    internal class TextResponseConnector : ResponseConnector
    {
        public TextResponseConnector(string datafile, string prefix, string keys) : base(datafile, prefix, keys, new ResolveDelegate(ResolveContent)) { }
        private static string ResolveContent(XmlNode node)
        {
            return node.InnerText;
        }
    }

    internal class DataRequestEventArgs
    {
        private readonly string _path;
        private readonly string _data;
        internal DataRequestEventArgs(string path) : this(path, string.Empty) { }

        internal DataRequestEventArgs(string path, string data)
        {
            _path = path;
            _data = data;
            ;
        }

        internal string Path
        {
            get { return _path; }
        }

        internal string Data
        {
            get { return _data; }
        }
    }
}
