using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class AdjustingBrightness
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AdjustingBrightness

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"AdjustBrightness_out.tiff";

            using (var image = (PsdImage)Image.Load(sourceFile))
            {
                RasterCachedImage rasterImage = image;

                // Set the brightness value. The accepted values of brightness are in the range [-255, 255].
                rasterImage.AdjustBrightness(-50);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                rasterImage.Save(destName, tiffOptions);
            }

            //ExEnd:AdjustingBrightness

        }
    }
}
