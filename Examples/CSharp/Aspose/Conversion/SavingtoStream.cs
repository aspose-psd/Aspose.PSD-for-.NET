using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class SavingtoStream
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SavingtoStream

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + "result.png";

            // load PSD image and replace the non found fonts.
            using (Image image = Image.Load(sourceFile))
            {
                PsdImage psdImage = (PsdImage)image;
                MemoryStream stream = new MemoryStream();
                psdImage.Save(stream, new PngOptions());
            }

            //ExEnd:SavingtoStream

        }
    }
}
