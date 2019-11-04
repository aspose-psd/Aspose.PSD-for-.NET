using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPDFWithAdjustmentLayers
    {
        public static void Run()
        {

            //ExStart:PSDToPDFWithAdjustmentLayers
            // Add color overlay layer effect at runtime
            string dataDir = RunExamples.GetDataDir_PSD();


            using (PsdImage image = (PsdImage)Image.Load(dataDir + "example.psd"))
            {
                image.Save(dataDir+ "document.pdf", new PdfOptions());
            }
            //ExEnd:PSDToPDFWithAdjustmentLayers


        }
    }
}
