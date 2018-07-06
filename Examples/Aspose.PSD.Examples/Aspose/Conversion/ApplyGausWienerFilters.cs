using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageFilters.FilterOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class ApplyGausWienerFilters
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ApplyGausWienerFilters

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"gauss_wiener_out.gif";

            // Load the noisy image 
            using (Image image = Image.Load(sourceFile))
            {
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    return;
                }

                // Create an instance of GaussWienerFilterOptions class and set the radius size and smooth value.
                GaussWienerFilterOptions options = new GaussWienerFilterOptions(12, 3);
                options.Grayscale = true;

                // Apply MedianFilterOptions filter to RasterImage object and Save the resultant image
                rasterImage.Filter(image.Bounds, options);
                image.Save(destName, new GifOptions());

            }
            //ExEnd:ApplyGausWienerFilters

        }
    }
}
