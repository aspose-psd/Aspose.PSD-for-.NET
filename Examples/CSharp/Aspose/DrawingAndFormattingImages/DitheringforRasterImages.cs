using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class DitheringforRasterImages
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DitheringforRasterImages

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"SampleImage_out.bmp";

            // Load an existing image into an instance of RasterImage class
            using (var image = (PsdImage)Image.Load(sourceFile))
            {
                // Peform Floyd Steinberg dithering on the current image and Save the resultant image
                image.Dither(DitheringMethod.ThresholdDithering, 4);
                image.Save(destName, new BmpOptions());
            }

            //ExEnd:DitheringforRasterImages

        }

    }
}
