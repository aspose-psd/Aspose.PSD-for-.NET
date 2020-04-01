using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
	class RenderingColorEffect
	{
		public static void Run()
		{
			string dataDir = RunExamples.GetDataDir_PSD();

			//ExStart:RenderingColorEffect
			string sourceFileName = dataDir + "ColorOverlay.psd";
			string pngExportPath = dataDir + "ColorOverlayresult.png";
			var loadOptions = new PsdLoadOptions()
			{
				LoadEffectsResource = true
			};

			using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
			//using (var im = (PsdImage)Image.Load(sourceFileName))
			{
				var colorOverlay = (ColorOverlayEffect)(im.Layers[1].BlendingOptions.Effects[0]);

				Assert.AreEqual(Color.Red, colorOverlay.Color);
				Assert.AreEqual(153, colorOverlay.Opacity);

				// Save PNG
				var saveOptions = new PngOptions();
				saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
				im.Save(pngExportPath, saveOptions);
			}
		}
		//ExEnd:RenderingColorEffect
	}
}