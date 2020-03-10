using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddTextLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddTextLayer
            string sourceFileName = dataDir + "OneLayer.psd";
            string outFileName = dataDir + "OneLayerWithAddedText.psd";

            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                image.AddTextLayer("Some text", new Rectangle(50, 50, 100, 100));
                PsdOptions options = new PsdOptions(image);
                image.Save(outFileName, options);
            }

            //ExEnd:AddTextLayer
        }
    }
}
