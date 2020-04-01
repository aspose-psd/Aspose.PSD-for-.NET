using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    class AIToJPG
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_AI();

            //ExStart:AIToJPG
            string[] sourcesFiles = new string[]
            {
                @"34992OStroke",
                @"rect2_color",
            };

            for (int i = 0; i < sourcesFiles.Length; i++)
            {
                string name = sourcesFiles[i];
                string sourceFileName = dataDir + name + ".ai";
                string outFileName = dataDir + name + ".jpg";


                using (AiImage image = (AiImage)Image.Load(sourceFileName))
                {

                    ImageOptionsBase options = new JpegOptions() { Quality = 85 };
                    image.Save(outFileName, options);

                }
            }

            //ExEnd:AIToJPG
        }
    }
}
