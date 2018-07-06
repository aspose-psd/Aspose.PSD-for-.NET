using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class BinarizationWithFixedThreshold
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:BinarizationWithFixedThreshold

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"BinarizationWithFixedThreshold_out.jpg";

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

                // Binarize image with predefined fixed threshold and Save the resultant image
                rasterCachedImage.BinarizeFixed(100);
                rasterCachedImage.Save(destName, new JpegOptions());
            }

            //ExEnd:BinarizationWithFixedThreshold

        }
    }
}
