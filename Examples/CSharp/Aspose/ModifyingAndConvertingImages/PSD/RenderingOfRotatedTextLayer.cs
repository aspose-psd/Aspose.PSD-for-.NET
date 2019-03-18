using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class RenderingOfRotatedTextLayer
    {
        public static void Run() {
            //ExStart:RenderingOfRotatedTextLayer

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir + "TransformedText.psd";
            string exportPath = dataDir + "TransformedTextExport.psd";
            string exportPathPng = dataDir + "TransformedTextExport.png";
            var im = (PsdImage)Image.Load(sourceFileName);
            using (im)
            {
                im.Save(exportPath);
                im.Save(exportPathPng, new PngOptions()
                {
                    ColorType = PngColorType.Grayscale
                });
            }
            //ExEnd:RenderingOfRotatedTextLayer


        }
    }
}
