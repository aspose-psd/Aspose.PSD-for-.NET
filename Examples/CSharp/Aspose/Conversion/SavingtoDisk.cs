using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class SavingtoDisk
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SavingtoDisk

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + "result.png";

            // load PSD image and replace the non found fonts.
            using (Image image = Image.Load(sourceFile))
            {
                PsdImage psdImage = (PsdImage)image;
                psdImage.Save(destName, new PngOptions());
            }

            //ExEnd:SavingtoDisk

        }
    }
}
