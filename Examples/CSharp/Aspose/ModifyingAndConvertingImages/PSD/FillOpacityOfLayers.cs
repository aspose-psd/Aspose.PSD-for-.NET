using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class FillOpacityOfLayers
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:FillOpacityOfLayers

            // Change the Fill Opacity property
            string sourceFileName = dataDir + "FillOpacitySample.psd";
            string exportPath = dataDir + "FillOpacitySampleChanged.psd";

            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                var layer = im.Layers[2];
                layer.FillOpacity = 5;
                im.Save(exportPath);
            }

            //ExEnd:FillOpacityOfLayers

        }

    }
}
