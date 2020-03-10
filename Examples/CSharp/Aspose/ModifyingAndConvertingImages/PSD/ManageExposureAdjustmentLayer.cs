using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ManageExposureAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ManageExposureAdjustmentLayer

            // Exposure layer editing
            string sourceFileName = dataDir + "ExposureAdjustmentLayer.psd";
            string psdPathAfterChange = dataDir + "ExposureAdjustmentLayerChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is ExposureLayer)
                    {
                        var expLayer = (ExposureLayer)layer;
                        expLayer.Exposure = 2;
                        expLayer.Offset = -0.25f;
                        expLayer.GammaCorrection = 0.5f;
                    }
                }
                im.Save(psdPathAfterChange);
            }

            // Exposure layer adding
            sourceFileName = dataDir + "PhotoExample.psd";
            psdPathAfterChange = dataDir + "PhotoExampleAddedExposure.psd";

            using (PsdImage im = (PsdImage)Image.Load(sourceFileName))
            {
                var newlayer = im.AddExposureAdjustmentLayer();
                newlayer.Exposure = 10;
                newlayer.Offset = -0.25f;
                newlayer.GammaCorrection = 2f;

                im.Save(psdPathAfterChange);
            }
            //ExEnd:ManageExposureAdjustmentLayer

        }

    }
}
