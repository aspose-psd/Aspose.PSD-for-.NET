using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPDFWithClippingMask
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:PSDToPDFWithClippingMask

            using (PsdImage image = (PsdImage)Image.Load(dataDir + "clip.psd"))
            {
                image.Save(dataDir + "output.pdf", new PdfOptions());
            }

            //ExEnd:PSDToPDFWithClippingMask
        }
    }
}
