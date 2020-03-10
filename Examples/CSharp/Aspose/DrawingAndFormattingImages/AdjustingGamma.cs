using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class AdjustingGamma
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AdjustingGamma

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"AdjustGamma_out.tiff";

            // Load an existing image into an instance of RasterImage class
            using (var image = Image.Load(sourceFile))
            {
                // Cast object of Image to RasterImage
                RasterImage rasterImage = (RasterImage)image;

                // Check if RasterImage is cached and Cache RasterImage for better performance
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                // Adjust the gamma
                rasterImage.AdjustGamma(2.2f, 2.2f, 2.2f);

                // Create an instance of TiffOptions for the resultant image,  Set various properties for the object of TiffOptions and Save the resultant image to TIFF format
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                rasterImage.Save(destName, tiffOptions);

            }

            //ExEnd:AdjustingGamma

        }

    }
}
