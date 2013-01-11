using System.Diagnostics;

namespace VersionOne.SDK.APIClient
{
	internal class Config
	{
		private static DebugListener _listener;
		private static DebugListener Listener
		{
			get
			{
				if ( _listener == null )
					_listener = new DebugListener(System.Configuration.ConfigurationManager.AppSettings["DebugFileName"]);
				return _listener;
			}
		}

		public static bool IsDebugMode
		{
			get
			{
				bool res;
                bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["Debug"], out res);
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