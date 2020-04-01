using Aspose.PSD.ImageFilters.FilterOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class ApplyGausWienerFiltersForColorImage
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ApplyGausWienerFiltersForColorImage

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"gauss_wiener_color_out.gif";

            // Load the noisy image 
            using (Image image = Image.Load(sourceFile))
            {
                // Cast the image into RasterImage
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    return;
                }

                // Create an instance of GaussWienerFilterOptions class and set the radius size and smooth value.
                GaussWienerFilterOptions options = new GaussWienerFilterOptions(5, 1.5);
                options.Brightness = 1;

                // Apply MedianFilterOptions filter to RasterImage object and Save the resultant image
                rasterImage.Filter(image.Bounds, options);
                image.Save(destName, new GifOptions());

            }
            //ExEnd:ApplyGausWienerFiltersForColorImage

        }
    }
}
