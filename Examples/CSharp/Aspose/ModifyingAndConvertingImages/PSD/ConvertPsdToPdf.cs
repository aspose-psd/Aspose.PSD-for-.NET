using Aspose.PSD.FileFormats.Pdf;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ConvertPsdToPdf
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ConvertPsdToPdf

            string inputFile = dataDir + "PsdConvertToPdfExample.psd";

            using (var psdImage = (PsdImage)Image.Load(inputFile, new PsdLoadOptions()))
            {
                psdImage.Save(dataDir + "PsdConvertedToPdf.pdf",
                    new PdfOptions() { 
                        PdfDocumentInfo = new PdfDocumentInfo()
                    {
                        Author = "Aspose.PSD", 
                        Keywords = "Convert,Psd,Pdf,Online,HowTo", 
                        Subject = "PSD Conversion to PDF",
                        Title = "Pdf From Psd",
                    },
                        ResolutionSettings = new ResolutionSetting(5, 6)
                    });
            }

            //ExEnd:ConvertPsdToPdf
        }
    }
}