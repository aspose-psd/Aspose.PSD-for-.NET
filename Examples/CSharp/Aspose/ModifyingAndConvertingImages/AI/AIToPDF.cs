using System;
using System.IO;
using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    class AIToPDF
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:AIToPDF
            string sourceFileName = Path.Combine(baseDir, "rect2_color.ai");
            string outFileName = Path.Combine(outputDir, "rect2_color.pdf");

            ImageOptionsBase pdfOptions = new PdfOptions();
            
            using (AiImage image = (AiImage)Image.Load(sourceFileName))
            {
                image.Save(outFileName, pdfOptions);
            }
            //ExEnd:AIToPDF

            File.Delete(outFileName);

            Console.WriteLine("AIToPDF executed successfully");
        }
    }
}