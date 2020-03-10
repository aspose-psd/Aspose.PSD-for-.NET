using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class RotatinganImageonaSpecificAngle
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:RotatinganImageonaSpecificAngle

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"RotatingImageOnSpecificAngle_out.jpg";

            // Load an image to be rotated in an instance of RasterImage
            using (RasterImage image = (RasterImage)Image.Load(sourceFile))
            {
                // Before rotation, the image should be cached for better performance
                if (!image.IsCached)
                {
                    image.CacheData();
                }
                // Perform the rotation on 20 degree while keeping the image size proportional with red background color and Save the result to a new file
                image.Rotate(20f, true, Color.Red);
                image.Save(destName, new JpegOptions());
            }

            //ExEnd:RotatinganImageonaSpecificAngle

        }

    }
}
