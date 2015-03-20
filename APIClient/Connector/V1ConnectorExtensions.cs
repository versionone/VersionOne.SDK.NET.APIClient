using System;
using System.IO;
using System.Net;
using System.Xml;

namespace VersionOne.SDK.APIClient
{
    /// <summary>
    /// 
    /// </summary>
    public static class V1ConnectorExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static QueryResult Retrieve(this V1Connector connector, Query query)
        {
            QueryResult result = null;
            var doc = new XmlDocument();
            try
            {
                if (query.IsHistorical)
                {
                    connector.UseHistoryApi();
                }
                else
                {
                    connector.UseDataApi();
                }

                using (var stream = connector.GetData(new QueryURLBuilder(query, true).ToString()))
                {
                    doc.Load(stream);
                }

                result = ParsingServices.ParseQueryResult(doc.DocumentElement, query, connector.MetaModel);
            }
            catch (WebException ex)
            {
                //if we get a 404, return an empty query result otherwise throw the exception
                if (ex.Response is HttpWebResponse &&
                    ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    result = ParsingServices.GetEmptyQueryResult(query);
                }
                else
                {
                    throw;
                }

            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="asset"></param>
        /// <param name="comment"></param>
        /// <exception cref="ConnectionException"></exception>
        /// <exception cref="APIException"></exception>
        public static void Save(this V1Connector connector, Asset asset, string comment = "")
        {
            if (asset.HasChanged || asset.Oid.IsNull)
            {
                var doc = new XmlDocument();
                var stringWriter = new StringWriter();
                var writer = new XmlApiWriter(stringWriter, true);
                writer.WriteAsset(asset);
                var data = stringWriter.ToString();
                var path = asset.AssetType.Token;

                if (!asset.Oid.IsNull)
                {
                    path += "/" + asset.Oid.Key;
                }
                if (!string.IsNullOrWhiteSpace(comment))
                {
                    path += string.Format("?Comment='{0}'", System.Web.HttpUtility.UrlEncode(comment));
                }

                try
                {
                    connector.UseDataApi();
                    using (var stream = connector.SendData(path, data))
                    {
                        doc.Load(stream);
                    }

                    ParsingServices.ParseSaveAssetNode(doc.DocumentElement, asset, connector.MetaModel);
                }
                catch (WebException ex)
                {
                    if (ex.Response == null)
                    {
                        throw new ConnectionException("Error writing to output stream", ex);
                    }

                    using (var stream = ex.Response.GetResponseStream())
                    {
                        doc.Load(stream);
                    }

                    var message = doc.DocumentElement.SelectSingleNode("Message").InnerText;
                    throw new APIException(message, asset.Oid.Token, ex);
                }
                catch (Exception ex)
                {
                    throw new APIException("Failed to save", asset.Oid.Token, ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="assetList"></param>
        public static void Save(this V1Connector connector, AssetList assetList)
        {
            foreach (var asset in assetList)
            {
                connector.Save(asset);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="assetType"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Asset New(this V1Connector connector, IAssetType assetType, Oid context)
        {
            var doc = new XmlDocument();
            var path = assetType.Token;

            if (context != null && !context.IsNull)
            {
                path += "?ctx=" + context.Token;
            }

            try
            {
                connector.UseNewApi();
                using (var stream = connector.GetData(path))
                {
                    doc.Load(stream);
                }

                return ParsingServices.ParseNewAssetNode(doc.DocumentElement, assetType);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to get new asset!", assetType.Token, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="op"></param>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Oid ExecuteOperation(this V1Connector connector, IOperation op, Oid oid)
        {
            return connector.ExecuteOperation(op.Name, oid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="operationToken"></param>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Oid ExecuteOperation(this V1Connector connector, string operationToken, Oid oid)
        {
            var doc = new XmlDocument();
            try
            {
                var op = connector.MetaModel.GetOperation(operationToken);
                var path = oid.AssetType.Token + "/" + oid.Key + "?op=" + op.Name;

                connector.UseDataApi();
                using (var stream = connector.SendData(path, string.Empty))
                {
                    doc.Load(stream);
                }

                var asset = ParsingServices.ParseAssetNode(doc.DocumentElement, connector.MetaModel);

                return asset.Oid;
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                {
                    doc.Load(stream);
                }

                var message = doc.DocumentElement.SelectSingleNode("Message").InnerText;
                throw new APIException(message, oid.Token, ex);
            }
            catch (Exception ex)
            {
                throw new APIException("Failed to execute", oid.Token, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Oid GetOid(this V1Connector connector, string token)
        {
            return Oid.FromToken(token, connector.MetaModel);
        }
    }
}