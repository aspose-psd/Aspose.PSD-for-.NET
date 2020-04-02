using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
	class RenderingDropShadow
	{
		public static void Run()
		{
			string dataDir = RunExamples.GetDataDir_PSD();

			//ExStart:RenderingDropShadow
			string sourceFileName = dataDir + "Shadow.psd";
			string pngExportPath = dataDir + "Shadowchanged1.png";
			var loadOptions = new PsdLoadOptions()
			{
				LoadEffectsResource = true
			};

			using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))

			{
				var shadowEffect = (DropShadowEffect)(im.Layers[1].BlendingOptions.Effects[0]);

				if ((shadowEffect.Color != Color.Black) ||
					(shadowEffect.Opacity != 255) ||
					(shadowEffect.Distance != 3) ||
					(shadowEffect.Size != 7) ||
					(shadowEffect.UseGlobalLight != true) ||
					(shadowEffect.Angle != 90) ||
					(shadowEffect.Spread != 0) ||
					(shadowEffect.Noise != 0))
				{
					throw new Exception("Shadow Effect properties were read wrong");
				}

				// Save PNG
				var saveOptions = new PngOptions();
				saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
				im.Save(pngExportPath, saveOptions);
			}
		}
		//ExEnd:RenderingDropShadow
	}
}