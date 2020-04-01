using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ExpandandCropImages
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_DrawingAndFormattingImages();

            //ExStart:ExpandandCropImages

            string sourceFile = dataDir + @"example1.psd";
            string destName = dataDir + @"jpeg_out.jpg";

            // Load an image in an instance of Image and Setting for image data to be cashed
            using (RasterImage rasterImage = (RasterImage)Image.Load(sourceFile))
            {
                rasterImage.CacheData();
                // Create an instance of Rectangle class and define X,Y and Width, height of the rectangle, and Save output image
                Rectangle destRect = new Rectangle { X = -200, Y = -200, Width = 300, Height = 300 };
                rasterImage.Save(destName, new JpegOptions(), destRect);
            }

            //ExEnd:ExpandandCropImages

        }
    }
}
