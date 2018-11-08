using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
	class AddEffectAtRunTime
	{
		public static void Run()
		{
			//ExStart:AddEffectAtRunTime
			// Add color overlay layer effect at runtime
			string dataDir = RunExamples.GetDataDir_PSD();
			string sourceFileName =dataDir+"ThreeRegularLayers.psd";
			string exportPath = dataDir+"ThreeRegularLayersChanged.psd";

			var loadOptions = new PsdLoadOptions()
			{
				LoadEffectsResource = true
			};

			using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
			{
				var effect = im.Layers[1].BlendingOptions.AddColorOverlay();
				effect.Color = Color.Green;
				effect.Opacity = 128;
				effect.BlendMode = BlendMode.Normal;

				im.Save(exportPath);
			}
			//ExEnd:AddEffectAtRunTime
		}
	}
}
