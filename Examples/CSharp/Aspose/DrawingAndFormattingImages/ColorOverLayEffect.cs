using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
	class ColorOverLayEffect
	{
		public static void Run()
		{
			// The path to the documents directory.
			string dataDir = RunExamples.GetDataDir_PSD();

			//ExStart:ColorOverLayEffect

			// ColorOverlay effect editing
			string sourceFileName = dataDir+"ColorOverlay.psd";
			string psdPathAfterChange =dataDir+ "ColorOverlayChanged.psd";

			var loadOptions = new PsdLoadOptions()
			{
				LoadEffectsResource = true
			};

			using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
			{

				var colorOverlay = (ColorOverlayEffect)(im.Layers[1].BlendingOptions.Effects[0]);
				Assert.AreEqual(Color.Red, colorOverlay.Color);
				Assert.AreEqual(153, colorOverlay.Opacity);

				colorOverlay.Color = Color.Green;
				colorOverlay.Opacity = 128;

				im.Save(psdPathAfterChange);
			}
			//ExEnd:ColorOverLayEffect
		}
	}
}