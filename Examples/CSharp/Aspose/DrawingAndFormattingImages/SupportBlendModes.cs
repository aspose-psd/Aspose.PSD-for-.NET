using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
	class SupportBlendModes
	{

		public static void Run()
		{
			// The path to the documents directory.
			string dataDir = RunExamples.GetDataDir_PSD();

			//ExStart:SupportBlendModes
			var files = new string[]
	  {
	       "Normal",
	       "Dissolve",
	       "Darken",
	       "Multiply",
	       "ColorBurn",
	       "LinearBurn",
	       "DarkerColor",
	       "Lighten",
	       "Screen",
	       "ColorDodge",
	       "LinearDodgeAdd",
	       "LightenColor",
	       "Overlay",
	       "SoftLight",
	       "HardLight",
	       "VividLight",
	       "LinearLight",
	       "PinLight",
	       "HardMix",
	       "Difference",
	       "Exclusion",
	       "Subtract",
	       "Divide",
	        "Hue",
	       "Saturation",
	        "Color",
	       "Luminosity",
			};

			foreach (var fileName in files)
			{

				using (var im = (PsdImage)Image.Load(fileName + ".psd"))
				{
					// Export to PNG
					var saveOptions = new PngOptions();
					saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
					var pngExportPath100 = "BlendMode" + fileName + "_Test100.png";
					im.Save(pngExportPath100, saveOptions);

					// Set opacity 50%
					im.Layers[1].Opacity = 127;
					var pngExportPath50 = "BlendMode" + fileName + "_Test50.png";
					im.Save(pngExportPath50, saveOptions);
				}
			}
		}
		//ExEnd:SupportBlendModes

	}
}