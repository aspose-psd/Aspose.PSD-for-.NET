using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    class AIToPDF
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_AI();

            //ExStart:AIToPDF
            string[] sourcesFiles = new string[]
            {
                @"rect2_color",
            };

            for (int i = 0; i < sourcesFiles.Length; i++)
            {
                string name = sourcesFiles[i];
                string sourceFileName = dataDir + name + ".ai";
                string outFileName = dataDir + name + ".pdf";


                using (AiImage image = (AiImage)Image.Load(sourceFileName))
                {

                    ImageOptionsBase options = new PdfOptions();
                    image.Save(outFileName, options);
                }
            }

            //ExEnd:AIToPDF
        }
    }
}