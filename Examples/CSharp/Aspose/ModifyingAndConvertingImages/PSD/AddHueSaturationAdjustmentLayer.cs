using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddHueSaturationAdjustmentLayer
    {
        public static void Run()
        {
            //ExStart:AddHueSaturationAdjustmentLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Hue/Saturation layer editing
            string sourceFileName = dataDir+"HueSaturationAdjustmentLayer.psd";
            string psdPathAfterChange = dataDir+ "HueSaturationAdjustmentLayerChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is HueSaturationLayer)
                    {
                        var hueLayer = (HueSaturationLayer)layer;
                        hueLayer.Hue = -25;
                        hueLayer.Saturation = -12;
                        hueLayer.Lightness = 67;

                        var colorRange = hueLayer.GetRange(2);
                        colorRange.Hue = -40;
                        colorRange.Saturation = 50;
                        colorRange.Lightness = -20;
                        colorRange.MostLeftBorder = 300;
                    }
                }

                im.Save(psdPathAfterChange);
            }

            // Hue/Saturation layer adding
            sourceFileName = dataDir + "PhotoExample.psd";
            psdPathAfterChange = dataDir + "PhotoExampleAddedHueSaturation.psd";

            using (PsdImage im = (PsdImage)Image.Load (sourceFileName))
            {
                //this.SaveForVisualTest(im, this.OutputPath, prefix + file, "before");
                var hueLayer = im.AddHueSaturationAdjustmentLayer();
                hueLayer.Hue = -25;
                hueLayer.Saturation = -12;
                hueLayer.Lightness = 67;

                var colorRange = hueLayer.GetRange(2);
                colorRange.Hue = -160;
                colorRange.Saturation = 100;
                colorRange.Lightness = 20;
                colorRange.MostLeftBorder = 300;

                im.Save(psdPathAfterChange);
            }
            //ExEnd:AddHueSaturationAdjustmentLayer

        }

    }
}
