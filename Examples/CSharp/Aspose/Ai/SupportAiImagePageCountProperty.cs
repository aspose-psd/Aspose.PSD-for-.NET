using System;
using System.IO;
using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Ai
{
    public class SupportAiImagePageCountProperty
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportAiImagePageCountProperty
            //ExSummary:The following code demonstrates support of AiImage property for number of pages AiImage.PageCount.
            
            string sourceFile = Path.Combine(baseDir, "2241.ai");
            string[] outputFiles = new string[3]
            {
                Path.Combine(outputDir, "2241_pageNumber_0.png"),
                Path.Combine(outputDir, "2241_pageNumber_1.png"),
                Path.Combine(outputDir, "2241_pageNumber_2.png"),
            };

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }

            using (AiImage image = (AiImage)Image.Load(sourceFile))
            {
                AssertAreEqual(image.PageCount, 3);

                for (int i = 0; i < image.PageCount; i++)
                {
                    image.ActivePageIndex = i;
                    image.Save(outputFiles[i], new PngOptions());
                }
            }
            
            //ExEnd:SupportAiImagePageCountProperty

            Console.WriteLine("SupportAiImagePageCountProperty executed successfully");

            for (int i = 0; i < outputFiles.Length; i++)
            {
                File.Delete(outputFiles[i]);   
            }
        }
    }
}