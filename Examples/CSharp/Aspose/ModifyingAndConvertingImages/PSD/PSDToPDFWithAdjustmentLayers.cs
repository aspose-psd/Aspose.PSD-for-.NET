using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPDFWithAdjustmentLayers
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:PSDToPDFWithAdjustmentLayers

            using (PsdImage image = (PsdImage)Image.Load(dataDir + "example.psd"))
            {
                image.Save(dataDir + "document.pdf", new PdfOptions());
            }

            //ExEnd:PSDToPDFWithAdjustmentLayers
        }
    }
}
