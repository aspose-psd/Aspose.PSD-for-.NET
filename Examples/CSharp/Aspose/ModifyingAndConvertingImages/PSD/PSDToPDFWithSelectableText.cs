using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPDFWithSelectableText
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:PSDToPDFWithSelectableText

            string sourceFileName = dataDir + "text.psd";
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                string outFileName = dataDir + "text.pdf";
                image.Save(outFileName, new PdfOptions());
            }

            //ExEnd:PSDToPDFWithSelectableText

        }
    }
}
