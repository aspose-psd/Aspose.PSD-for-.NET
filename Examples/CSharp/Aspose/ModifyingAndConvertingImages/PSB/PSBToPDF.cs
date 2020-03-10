using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSB
{
    class PSBToPDF
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSB();

            //ExStart:PSBToPDF

            string sourceFileName = dataDir + "Simple.psb";
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                string outFileName = dataDir + "Simple.pdf";
                image.Save(outFileName, new PdfOptions());
            }
            //ExEnd:PSBToPDF

        }
    }
}