using System.Diagnostics;
using System;


namespace VersionOne.SDK.APIClient
{
    [Obsolete("This class has been deprecated.")]
    internal class Config
    {
        private static DebugListener _listener;
        private static DebugListener Listener
        {
            get
            {
                if (_listener == null)
                    _listener = new DebugListener(V1ConfigurationManager.GetValue(Settings.DebugFileName, @"C:\VersionOneAPIClientDebug.txt"));
                return _listener;
            }
        }

        public static bool IsDebugMode
        {
            get
            {
                bool res;
                bool.TryParse(V1ConfigurationManager.GetValue(Settings.Debug, "False"), out res);
                if (res && !Debug.Listeners.Contains(Listener))
                    Debug.Listeners.Add(Listener);
                else if (!res && Debug.Listeners.Contains(Listener))
                    Debug.Listeners.Remove(Listener);
                return res;
            }
        }

        private class DebugListener : DefaultTraceListener
        {
            public DebugListener(string logfile)
            {
                LogFileName = logfile;
            }
        }
    }
}