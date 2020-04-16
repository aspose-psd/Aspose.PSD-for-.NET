using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.PSD.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.lic";		
		
		///<Summary>
		/// SetAsposePSDLicense method to Aspose.ThreeD License
		///</Summary>
		public static void SetAsposePSDLicense()
		{
			try
			{

				Aspose.PSD.License lic = new Aspose.PSD.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}	
		
	}
}
