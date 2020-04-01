using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class Garysacling
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:Garysacling

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"Grayscaling_out.jpg";

            // Load an image in an instance of Image
            using (Image image = Image.Load(sourceFile))
            {
                // Cast the image to RasterCachedImage and Check if image is cached
                RasterCachedImage rasterCachedImage = (RasterCachedImage)image;
                if (!rasterCachedImage.IsCached)
                {
                    // Cache image if not already cached
                    rasterCachedImage.CacheData();
                }

                // Transform image to its grayscale representation and Save the resultant image
                rasterCachedImage.Grayscale();
                rasterCachedImage.Save(destName, new JpegOptions());
            }


            //ExEnd:Garysacling

        }
    }
}
