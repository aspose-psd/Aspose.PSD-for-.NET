using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for Configuration
/// </summary>
namespace Aspose.PSD.Live.Demos.UI.Config
{
	public static class Configuration
	{		
		private static string _appName = ConfigurationManager.AppSettings["AppName"].ToString();
		private static string _asposePSDLiveDemosPath = ConfigurationManager.AppSettings["AsposePSDLiveDemosPath"].ToString();
		private static string _resourceFileSessionName = ConfigurationManager.AppSettings["ResourceFileSessionName"];	      
		private static string _fileViewLink = ConfigurationManager.AppSettings["FileViewLink"];		
		private static string _asposePSDAppsAssetURL = ConfigurationManager.AppSettings["AsposePSDAppsAssetURL"];

		public static string ResourceFileSessionName
		{
			get { return _resourceFileSessionName; }
		}
		/// <summary>
		/// Get Working Directory
		/// </summary>
		public static string WorkingDirectory
		{
			get {
				string sourceFilespath = HttpContext.Current.Server.MapPath("~/Assets/SourceFiles/");
				if ( ! System.IO.Directory.Exists(sourceFilespath))
				{
					System.IO.Directory.CreateDirectory(sourceFilespath);
				}

				return sourceFilespath;
			}
		}

		/// <summary>
		/// Get Working Directory
		/// </summary>
		public static string OutputDirectory
		{
			get
			{
				string OutputFilespath = HttpContext.Current.Server.MapPath("~/Assets/OutputFiles/");
				if (!System.IO.Directory.Exists(OutputFilespath))
				{
					System.IO.Directory.CreateDirectory(OutputFilespath);
				}

				return OutputFilespath;
			}
		}		
		public static string AsposePSDAppsAssetURL
		{
			get { return _asposePSDAppsAssetURL; }
		}	
		
		public static string AppName
        {
            get { return _appName; }
        }
        public static string AsposePSDLiveDemosPath
        {
            get { return _asposePSDLiveDemosPath; }
        }
        
		public static string FileViewLink
		{
			get { return _fileViewLink; }
		}
	}
}
