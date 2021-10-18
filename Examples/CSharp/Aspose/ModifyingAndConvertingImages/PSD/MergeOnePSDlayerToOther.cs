using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class MergeOnePSDlayerToOther
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:MergeOnePSDlayerToOther

            var sourceFile1 = dataDir + "FillOpacitySample.psd";
            var sourceFile2 = dataDir + "ThreeRegularLayersSemiTransparent.psd";
            var exportPath = dataDir + "MergedLayersFromTwoDifferentPsd.psd";

            using (var im1 = (PsdImage)(Image.Load(sourceFile1)))
            {
                var layer1 = im1.Layers[1];

                using (var im2 = (PsdImage)(Image.Load(sourceFile2)))
                {
                    var layer2 = im2.Layers[0];

                    layer1.MergeLayerTo(layer2);
                    im2.Save(exportPath);
                }
            }

            //ExEnd:MergeOnePSDlayerToOther
        }
    }
}
