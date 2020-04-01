using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class DitheringforRasterImages
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DitheringforRasterImages

            string sourceFile = dataDir + @"sample.psd";
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
