using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;
using Microsoft.Win32;

namespace VersionOne.SDK.APIClient
{
	/// <summary>
	/// Provides a method to determine a file's MIME type based on its filename
	/// </summary>
	public static class MimeType
	{
		private static readonly IDictionary _extensionMimetypes;

		static MimeType()
		{
			_extensionMimetypes = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
			FillMapFromMimeTypeCatalog(_extensionMimetypes);
			FillMapFromExtensionsCatalog(_extensionMimetypes);
			_extensionMimetypes = LoadEmbeddedConfig(_extensionMimetypes);
			OverrideMapFromAppConfig(_extensionMimetypes);
		}

		/// <summary>
		/// There is a minimal list of basic extensions/MIME types stored in a resource in this assembly.
		/// </summary>
		private static IDictionary LoadEmbeddedConfig(IDictionary map)
		{
			XmlNode section = LoadXml("VersionOne.SDK.APIClient.MimeTypes.config");
			return (IDictionary)new MimeTypesSectionHandler().Create(map, null, section);
		}

		private static XmlNode LoadXml(string resourcename)
		{
			Assembly asm = Assembly.GetCallingAssembly();
			using (Stream stream = asm.GetManifestResourceStream(resourcename))
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(stream);
				return doc.DocumentElement;
			}
		}

		/// <summary>
		/// There is a catalog of MIME types found in the registry at HKCR\Mime\Database\Content Type.
		/// </summary>
		private static void FillMapFromMimeTypeCatalog(IDictionary map)
		{
			using (RegistryKey topKey = Registry.ClassesRoot.OpenSubKey(@"Mime\Database\Content Type"))
			{
				foreach (string mimetype in topKey.GetSubKeyNames())
				{
					using (RegistryKey subkey = topKey.OpenSubKey(mimetype))
					{
						if (subkey == null) continue;

						string extension = (string)subkey.GetValue("Extension");
						if (string.IsNullOrEmpty(extension)) continue;

						// if this extension has multiple MIME types, use the shortest one
						if (map.Contains(extension) && ((string)map[extension]).Length <= mimetype.Length)
							continue;

						map[extension] = mimetype;
					}
				}
			}
		}

		/// <summary>
		/// HKCR lists known extensions, many of which have a corresponding MIME type.
		/// </summary>
		private static void FillMapFromExtensionsCatalog(IDictionary map)
		{
			foreach (string extension in Registry.ClassesRoot.GetSubKeyNames())
			{
				// there are a lot of subkeys under HKCR.  Only look in those that look like extensions
				if (extension[0] != '.') continue;

				using (RegistryKey subkey = Registry.ClassesRoot.OpenSubKey(extension))
				{
					if (subkey == null) continue;

					string mimetype = (string)subkey.GetValue("Content Type");
					if (string.IsNullOrEmpty(mimetype)) continue;

					map[extension] = mimetype;
				}
			}
		}

		/// <summary>
		/// The client application can override or add to the MIME type catalog in its config.
		/// </summary>
		private static void OverrideMapFromAppConfig(IDictionary map)
		{
            IDictionary config = (IDictionary)System.Configuration.ConfigurationManager.GetSection("VersionOne.SDK.APIClient.MimeTypes");
			if (config == null) return;
			foreach (DictionaryEntry entry in config)
			{
				map[entry.Key] = entry.Value;
			}
		}

/*
 *	This is how IE does its ContentType sniffing.
 * It's pretty useless for our purpose because it has many special cases which 
 * change between versions.
 
		[DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
		private static extern UInt32 FindMimeFromData(
			UInt32 pBC,
			[MarshalAs(UnmanagedType.LPStr)] String pwzUrl,
			[MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
			UInt32 cbSize,
			[MarshalAs(UnmanagedType.LPStr)] String pwzMimeProposed,
			UInt32 dwMimeFlags,
			out UInt32 ppwzMimeOut,
			UInt32 dwReserved);

		private static string FindMimeFromData (string filePath, byte[] buffer)
		{
			UInt32 mimeTypeLp;
			UInt32 returnValue = FindMimeFromData(0, filePath, buffer, (UInt32)buffer.Length, null, 3, out mimeTypeLp, 0);
			IntPtr mimeTypePointer = new IntPtr(mimeTypeLp);
			string mimetype = Marshal.PtrToStringUni(mimeTypePointer);
			Marshal.FreeCoTaskMem(mimeTypePointer);
			return mimetype;
		}
*/

		/// <summary>
		/// Return the file's MIME type, based on it's name.
		/// </summary>
		/// <param name="filename">Name of the file</param>
		/// <returns>MIME type</returns>
		public static string Resolve(string filename)
		{
			string extension = Path.GetExtension(filename);
			return (string)_extensionMimetypes[extension] ?? "application/octet-stream";
		}
	}

	public class MimeTypesSectionHandler : DictionarySectionHandler
	{
		protected override string KeyAttributeName
		{
			get { return "extension"; }
		}

		protected override string ValueAttributeName
		{
			get { return "mimetype"; }
		}
	}
}