using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageFilters.FilterOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class ApplyMotionWienerFilters
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ApplyMotionWienerFilters

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"motion_filter_out.gif";

            // Load the noisy image 
            using (Image image = Image.Load(sourceFile))
            {
                // Cast the image into RasterImage
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    return;
                }

                // Create an instance of MotionWienerFilterOptions class and set the length, smooth value and angle.
                MotionWienerFilterOptions options = new MotionWienerFilterOptions(50, 9, 90);
                options.Grayscale = true;

                // Apply MedianFilterOptions filter to RasterImage object and  Save the resultant image
                rasterImage.Filter(image.Bounds, options);
                image.Save(destName, new GifOptions());

            }
            //ExEnd:ApplyMotionWienerFilters

        }
    }
}
