using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddLevelAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddLevelAdjustmentLayer

            string sourceFileName = dataDir + "LevelsAdjustmentLayer.psd";
            string psdPathAfterChange = dataDir + "LevelsAdjustmentLayerChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is LevelsLayer)
                    {
                        var levelsLayer = (LevelsLayer)layer;
                        var channel = levelsLayer.GetChannel(0);
                        channel.InputMidtoneLevel = 2.0f;
                        channel.InputShadowLevel = 10;
                        channel.InputHighlightLevel = 230;
                        channel.OutputShadowLevel = 20;
                        channel.OutputHighlightLevel = 200;
                    }
                }

                // Save PSD
                im.Save(psdPathAfterChange);
            }
            //ExEnd:AddLevelAdjustmentLayer

        }

    }
}
