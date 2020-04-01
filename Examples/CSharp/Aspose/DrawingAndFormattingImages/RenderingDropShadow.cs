using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

				Assert.AreEqual(Color.Black, shadowEffect.Color);
				Assert.AreEqual(255, shadowEffect.Opacity);
				Assert.AreEqual(3, shadowEffect.Distance);
				Assert.AreEqual(7, shadowEffect.Size);
				Assert.AreEqual(true, shadowEffect.UseGlobalLight);
				Assert.AreEqual(90, shadowEffect.Angle);
				Assert.AreEqual(0, shadowEffect.Spread);
				Assert.AreEqual(0, shadowEffect.Noise);

				// Save PNG
				var saveOptions = new PngOptions();
				saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
				im.Save(pngExportPath, saveOptions);
			}
		}
		//ExEnd:RenderingDropShadow
	}
}