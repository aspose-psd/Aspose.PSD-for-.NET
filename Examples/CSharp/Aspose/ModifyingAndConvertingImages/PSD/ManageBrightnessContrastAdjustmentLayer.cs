using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ManageBrightnessContrastAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ManageBrightnessContrastAdjustmentLayer

            // Brightness/Contrast layer editing
            string sourceFileName = dataDir + "BrightnessContrastModern.psd";
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
