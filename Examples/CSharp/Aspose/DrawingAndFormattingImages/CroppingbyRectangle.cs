using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class CroppingbyRectangle
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:CroppingbyRectangle

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"CroppingByRectangle_out.jpg";

            // Load an existing image into an instance of RasterImage class
            using (RasterImage rasterImage = (RasterImage)Image.Load(sourceFile))
            {
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                // Create an instance of Rectangle class with desired size, 
                //Perform the crop operation on object of Rectangle class and Save the results to disk
                Rectangle rectangle = new Rectangle(20, 20, 20, 20);

                rasterImage.Crop(rectangle);
                rasterImage.Save(destName, new JpegOptions());
            }

            //ExEnd:CroppingbyRectangle

        }

    }
}
