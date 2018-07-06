using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class CroppingbyShifts
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:CroppingbyShifts

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"CroppingByShifts_out.jpg";

            // Load an existing image into an instance of RasterImage class
            using (RasterImage rasterImage = (RasterImage)Image.Load(sourceFile))
            {
                // Before cropping, the image should be cached for better performance
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                // Define shift values for all four sides
                int leftShift = 10;
                int rightShift = 10;
                int topShift = 10;
                int bottomShift = 10;

                // Based on the shift values, apply the cropping on image Crop method will shift the image bounds toward the center of image and Save the results to disk
                rasterImage.Crop(leftShift, rightShift, topShift, bottomShift);
                rasterImage.Save(destName, new JpegOptions());
            }

            //ExEnd:CroppingbyShifts

        }
    }
}
