using System;

namespace VersionOne.SDK.APIClient
{

    /// <summary>
    /// Named config settings that match those in the app.config file.
    /// </summary>
    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
    public static class Settings
    {
        public static string V1Url { get { return "V1Url"; } }
        public static string V1UserName { get { return "V1UserName"; } }
        public static string V1Password { get { return "V1Password";} }
        public static string ProxyUrl { get { return "ProxyUrl"; } }
        public static string ProxyUserName { get { return "ProxyUserName"; } }
        public static string ProxyPassword { get { return "ProxyPassword"; } }
        public static string MetaUrl { get { return "MetaUrl"; } }
        public static string DataUrl { get { return "DataUrl"; } }
        public static string ConfigUrl { get { return "ConfigUrl"; } }
        public static string DebugFileName { get { return "DebugFileName"; } }
        public static string Debug { get { return "Debug"; } }
        public static string UseWindowsIntegratedAuth { get { return "UseWindowsIntegratedAuth"; } }
    }

    [Obsolete("This class has been deprecated. Please use V1Connector instead.")]
    public static class V1ConfigurationManager
    {
        public static TPrimativeType GetValue<TPrimativeType>(string key, TPrimativeType defaultValue)
        {
            if (String.IsNullOrEmpty(key)) return defaultValue;
            var tmp = System.Configuration.ConfigurationManager.AppSettings[key];
            if (tmp == null) return defaultValue;
            var type = typeof (TPrimativeType);
            return (TPrimativeType) Convert.ChangeType(tmp, type);
        }
    }
}
