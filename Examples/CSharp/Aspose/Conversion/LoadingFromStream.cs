using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class LoadingFromStream
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:LoadingFromStream

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + "result.png";

            FileStream fStream = new FileStream(sourceFile, FileMode.Open);
            fStream.Position = 0;

            // load PSD image and replace the non found fonts.
            using (Image image = Image.Load(fStream))
            {
                PsdImage psdImage = (PsdImage)image;
                MemoryStream stream = new MemoryStream();
                psdImage.Save(stream, new PngOptions());
            }

            //ExEnd:LoadingFromStream

        }
    }
}
