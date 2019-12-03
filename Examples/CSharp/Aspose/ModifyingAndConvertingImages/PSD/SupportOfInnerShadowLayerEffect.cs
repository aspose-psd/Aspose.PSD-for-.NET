using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfInnerShadowLayerEffect
    {
        public static void Run() {

            //ExStart:SupportOfInnerShadowLayerEffect

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFile = dataDir + "innershadow.psd";
            string destName   = dataDir+ "innershadow_out.psd";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            // Load an existing image into an instance of PsdImage class
            using (var image = (PsdImage)Image.Load(sourceFile, loadOptions))
            {
                var layer = image.Layers[image.Layers.Length - 1];
                var shadowEffect = (IShadowEffect)layer.BlendingOptions.Effects[0];

                shadowEffect.Color = Color.Green;
                shadowEffect.Opacity = 128;
                shadowEffect.Distance = 1;
                shadowEffect.UseGlobalLight = false;
                shadowEffect.Size = 2;
                shadowEffect.Angle = 45;
                shadowEffect.Spread = 50;
                shadowEffect.Noise = 5;

                image.Save(destName, new PsdOptions(image));
            }

            //ExEnd:SupportOfInnerShadowLayerEffect

        }
    }
}
