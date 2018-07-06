using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class BinarizationWithOtsuThreshold
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:BinarizationWithOtsuThreshold

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"BinarizationWithOtsuThreshold_out.jpg";

            // Load an image
            using (Image image = Image.Load(sourceFile))
            {
                // Cast the image to RasterCachedImage and Check if image is cached
                RasterCachedImage rasterCachedImage = (RasterCachedImage)image;
                if (!rasterCachedImage.IsCached)
                {
                    // Cache image if not already cached
                    rasterCachedImage.CacheData();
                }

                // Binarize image with Otsu Thresholding and Save the resultant image                
                rasterCachedImage.BinarizeOtsu();

                rasterCachedImage.Save(destName, new JpegOptions());
            }

            //ExEnd:BinarizationWithOtsuThreshold

        }
    }
}
