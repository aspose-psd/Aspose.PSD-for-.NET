using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPDFWithSelectableText
    {
        public static void Run() {

            //ExStart:PSDToPDFWithSelectableText

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir+ "text.psd";
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                string outFileName = dataDir + "text.pdf";
                image.Save(outFileName, new PdfOptions());
            }
            //ExEnd:PSDToPDFWithSelectableText

        }
    }
}
