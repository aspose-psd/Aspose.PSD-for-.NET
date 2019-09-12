using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSB
{
    class PSBToPDF
    {
        public static void Run() {

            //ExStart:PSBToPDF
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSB();

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
