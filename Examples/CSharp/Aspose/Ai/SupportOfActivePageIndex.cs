using System;
using System.IO;
using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Ai
{
    public class SupportOfActivePageIndex
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportOfActivePageIndex
            //ExSummary:The following code demonstrates support of ability to change active page in Ai images.
            
            string sourceFile = Path.Combine(baseDir, "threePages.ai");
            string firstPageOutputPng = Path.Combine(outputDir, "firstPageOutput.png");
            string secondPageOutputPng = Path.Combine(outputDir, "secondPageOutput.png");
            string thirdPageOutputPng = Path.Combine(outputDir, "thirdPageOutput.png");

            // Load the AI image.
            using (AiImage image = (AiImage)Image.Load(sourceFile))
            {
                // By default, the ActivePageIndex is 0.
                // So if you save the AI image without changing this property, the first page will be rendered and saved.
                image.Save(firstPageOutputPng, new PngOptions());

                // Change the active page index to the second page.
                image.ActivePageIndex = 1;

                // Save the second page of the AI image as a PNG image.
                image.Save(secondPageOutputPng, new PngOptions());

                // Change the active page index to the third page.
                image.ActivePageIndex = 2;

                // Save the third page of the AI image as a PNG image.
                image.Save(thirdPageOutputPng, new PngOptions());
            }

            //ExEnd:SupportOfActivePageIndex
            
            File.Delete(firstPageOutputPng);
            File.Delete(secondPageOutputPng);
            File.Delete(thirdPageOutputPng);

            Console.WriteLine("SupportOfActivePageIndex executed successfully");
        }
    }
}