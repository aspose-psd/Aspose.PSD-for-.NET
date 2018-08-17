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
    class ManageBrightnessContrastAdjustmentLayer
    {
        public static void Run()
        {
            //ExStart:ManageBrightnessContrastAdjustmentLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Brightness/Contrast layer editing
            string sourceFileName = dataDir+"BrightnessContrastModern.psd";
            string psdPathAfterChange = dataDir + "BrightnessContrastModernChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is BrightnessContrastLayer)
                    {
                        var brightnessContrastLayer = (BrightnessContrastLayer)layer;
                        brightnessContrastLayer.Brightness = 50;
                        brightnessContrastLayer.Contrast = 50;
                    }
                }

                // Save PSD
                im.Save(psdPathAfterChange);
            }
            //ExEnd:ManageBrightnessContrastAdjustmentLayer

        }

    }
}
