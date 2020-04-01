using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    class AIToTIFF
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_AI();

            //ExStart:AIToTIFF

            string[] sourcesFiles = new string[]
            {
                @"34992OStroke",
                @"rect2_color",
            };

            for (int i = 0; i < sourcesFiles.Length; i++)
            {
                string name = sourcesFiles[i];
                string sourceFileName = dataDir + name + ".ai";
                string outFileName = dataDir + name + ".tif";


                using (AiImage image = (AiImage)Image.Load(sourceFileName))
                {

                    ImageOptionsBase options = new TiffOptions(TiffExpectedFormat.TiffDeflateRgba);
                    image.Save(outFileName, options);

                }
            }

            //ExEnd:AIToTIFF
        }
    }
}
