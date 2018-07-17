using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class GrayScaleSupportForAlpha
    {
        public static void Run()
        {
            //ExStart:GrayScaleSupportForAlpha
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                // Create an instance of PngOptions class
                PngOptions pngOptions = new PngOptions();
                pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
                psdImage.Save(dataDir+ "GrayScaleSupportForAlpha_out.png", pngOptions);
            }

            //ExEnd:GrayScaleSupportForAlpha
        }
    }
}
