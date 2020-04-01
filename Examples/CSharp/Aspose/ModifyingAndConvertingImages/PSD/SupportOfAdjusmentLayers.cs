using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfAdjusmentLayers
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfAdjusmentLayers

            // Channel Mixer Adjustment Layer
            string sourceFileName1 = dataDir + "ChannelMixerAdjustmentLayer.psd";
            string exportPath1 = dataDir + "ChannelMixerAdjustmentLayerChanged.psd";

            using (var im = (PsdImage)(Image.Load(sourceFileName1)))
            {
                for (int i = 0; i < im.Layers.Length; i++)
                {
                    var adjustmentLayer = im.Layers[i] as AdjustmentLayer;

                    if (adjustmentLayer != null)
                    {
                        adjustmentLayer.MergeLayerTo(im.Layers[0]);
                    }
                }

                // Save PSD
                im.Save(exportPath1);
            }

            // Levels adjustment layer
            var sourceFileName2 = dataDir + "LevelsAdjustmentLayerRgb.psd";
            var exportPath2 = dataDir + "LevelsAdjustmentLayerRgbChanged.psd";

            using (var im = (PsdImage)(Image.Load(sourceFileName2)))
            {
                for (int i = 0; i < im.Layers.Length; i++)
                {
                    var adjustmentLayer = im.Layers[i] as AdjustmentLayer;

                    if (adjustmentLayer != null)
                    {
                        adjustmentLayer.MergeLayerTo(im.Layers[0]);
                    }
                }

                // Save PSD
                im.Save(exportPath2);
            }
            //ExEnd:SupportOfAdjusmentLayers

        }
    }
}
