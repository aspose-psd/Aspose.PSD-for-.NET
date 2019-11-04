using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPDFWithClippingMask
    {
        public static void Run()
        {

            //ExStart:PSDToPDFWithClippingMask
            // Add color overlay layer effect at runtime
            string dataDir = RunExamples.GetDataDir_PSD();


            using (PsdImage image = (PsdImage)Image.Load(dataDir + "clip.psd"))
            {
                image.Save(dataDir + "output.pdf", new PdfOptions());
            }
            //ExEnd:PSDToPDFWithClippingMask


        }
    }
}
