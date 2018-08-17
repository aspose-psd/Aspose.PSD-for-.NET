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
    class AddLevelAdjustmentLayer
    {
        public static void Run()
        {
            //ExStart:AddLevelAdjustmentLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir +"LevelsAdjustmentLayer.psd";
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
