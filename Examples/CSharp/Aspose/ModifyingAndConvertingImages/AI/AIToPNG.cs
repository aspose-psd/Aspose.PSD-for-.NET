using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    class AIToPNG
    {
        public static void Run()
        {

            //ExStart:AIToPNG
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_AI();

            string[] sourcesFiles = new string[]
            {
                @"34992OStroke",
                @"rect2_color",
            };

            for (int i = 0; i < sourcesFiles.Length; i++)
            {
                string name = sourcesFiles[i];
                string sourceFileName = dataDir + name + ".ai";
                string outFileName = dataDir + name + ".png";


                using (AiImage image = (AiImage)Image.Load(sourceFileName))
                {

                    ImageOptionsBase options = new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha };
                    image.Save(outFileName, options);

                }
            }

            //ExEnd:AIToPNG
        }
    }
}
