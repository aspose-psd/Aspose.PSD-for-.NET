using System;
using System.IO;
using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.FileFormats.Pdf;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    public class AIToPDFA1a
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:AIToPDFA1a
            string sourceFileName = Path.Combine(baseDir, "rect2_color.ai");
            string outFileNamePdfA1a = Path.Combine(outputDir, "rect2_color.pdf");

            var pdfOptionsPdfA1a = new PdfOptions();
            pdfOptionsPdfA1a.PdfCoreOptions = new PdfCoreOptions();
            pdfOptionsPdfA1a.PdfCoreOptions.PdfCompliance = PdfComplianceVersion.PdfA1a;
            
            using (AiImage image = (AiImage)Image.Load(sourceFileName))
            {
                image.Save(outFileNamePdfA1a, pdfOptionsPdfA1a);
            }
            //ExEnd:AIToPDFA1a

            File.Delete(outFileNamePdfA1a);

            Console.WriteLine("AIToPDFA1a executed successfully");
        }
    }
}