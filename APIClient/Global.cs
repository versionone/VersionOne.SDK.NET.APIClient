using System.Configuration;
using System.IO;
using VersionOne.SDK.APIClient;

namespace VersionOne.APIClient
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global
	{
		private static IMetaModel _meta;
		private static IServices _services;
		private static ILocalizer _localizer;
		private static Configuration _configuration;
		private static Settings _settings;

		public static IMetaModel Meta
		{
			get
			{
				if (_meta == null)
					_meta = new MetaModel(new V1APIConnector(Settings.ApplicationUrl + "meta.v1/"));

				return _meta;
			}
		}

		public static IServices Services
		{
			get
			{
				if (_services == null)
					_services = new Services(Meta, new V1APIConnector(Settings.ApplicationUrl, Settings.Username, Settings.Password));

				return _services;
			}
		}

		public static Configuration Configuration
		{
			get
			{
				if (_configuration == null)
				{
					FileStream configurationFile = File.OpenRead("configuration.xml");
					
					_configuration = Configuration.Load(configurationFile);
				}

				return _configuration;
			}
		}

		public static Settings Settings
		{
			get
			{
				try
				{
					FileStream settingsFile = File.OpenRead("settings.xml");
					_settings = Settings.Load(settingsFile);
				}
				catch(FileNotFoundException)
				{
					_settings = new Settings();
				}
				
				return _settings;
			}
		}

		public static ILocalizer Localizer
		{
			get
			{
				if (_localizer == null)
					_localizer = new Localizer(new V1APIConnector(Settings.ApplicationUrl + "loc.v1/"));

				return _localizer;
			}
		}

		public static Asset CurrentMember
		{
			get
			{
				IAssetType memberType = Meta.GetAssetType("Member");
				Query query = new Query(memberType);
				
				query.Filter.Include(memberType.GetAttributeDefinition("Nickname"), "Admin");

				QueryResult result = Services.Retrieve(query);

				return result.Assets[0];
			}
		}
	}
}