using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPDF
    {
        public static void Run() {

            //ExStart:PSDToPDF
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Add support of PSD export to PDF
            string[] sourcesFiles = new string[]
            {
              @"1.psd",
              @"little.psb",
              @"psb3.psb",
              @"inRgb16.psd",
              @"ALotOfElementTypes.psd",
              @"ColorOverlayAndShadowAndMask.psd",
              @"ThreeRegularLayersSemiTransparent.psd"
            };
            for (int i = 0; i < sourcesFiles.Length; i++)
            {
                string sourceFileName = sourcesFiles[i];
                using (PsdImage image = (PsdImage)Image.Load(dataDir + sourceFileName))
                {
                    string outFileName = "PsdToPdf" + i + ".pdf";
                    image.Save(dataDir + outFileName, new PdfOptions());
                }
            }


            //ExEnd:PSDToPDF


        }
    }
}
