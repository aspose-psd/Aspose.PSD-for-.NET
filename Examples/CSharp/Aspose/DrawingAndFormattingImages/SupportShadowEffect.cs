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
	class SupportShadowEffect
	{

		public static void Run()
		{
		
			//ExStart:SupportShadowEffect
			// The path to the documents directory.
			string dataDir = RunExamples.GetDataDir_PSD();
			string sourceFileName = dataDir+"Shadow.psd";
			string psdPathAfterChange = dataDir+"ShadowChanged.psd";
			var loadOptions = new PsdLoadOptions()
			{
				LoadEffectsResource = true
			};

			using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
		//using (var im = (PsdImage)Image.Load(sourceFileName))
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

				shadowEffect.Color = Color.Green;
				shadowEffect.Opacity = 128;
				shadowEffect.Distance = 11;
				shadowEffect.UseGlobalLight = false;
				shadowEffect.Size = 9;
				shadowEffect.Angle = 45;
				shadowEffect.Spread = 3;
				shadowEffect.Noise = 50;

				im.Save(psdPathAfterChange);
			}
		}
		//ExEnd:SupportShadowEffect
	}
}