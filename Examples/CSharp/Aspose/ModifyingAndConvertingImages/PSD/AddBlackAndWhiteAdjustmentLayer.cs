using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddBlackAndWhiteAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddBlackAndWhiteAdjustmentLayer
            //ExSummary:The following example demonstrates how you can add the black white adjustment layer at runtime in Aspose.PSD
            string sourceFileName = dataDir + "Stripes.psd";
            string outputFileName = dataDir + "OutputStripes.psd";
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                BlackWhiteAdjustmentLayer newLayer = image.AddBlackWhiteAdjustmentLayer();
                newLayer.Name = "BlackWhiteAdjustmentLayer";
                newLayer.Reds = 22;
                newLayer.Yellows = 92;
                newLayer.Greens = 70;
                newLayer.Cyans = 79;
                newLayer.Blues = 7;
                newLayer.Magentas = 28;

                image.Save(outputFileName, new PsdOptions());
            }

            //ExEnd:AddBlackAndWhiteAdjustmentLayer
        }
    }
}
