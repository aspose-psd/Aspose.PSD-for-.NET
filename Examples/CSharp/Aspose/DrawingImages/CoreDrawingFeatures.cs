using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class CoreDrawingFeatures
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:CoreDrawingFeatures
            // Create an instance of BmpOptions and set its various properties
            string loadpath = dataDir + "sample.psd";
            string outpath = dataDir + "CoreDrawingFeatures.bmp";
            // Create an instance of Image
            using (PsdImage image = new PsdImage(loadpath))
            {
                // load pixels
                var pixels = image.LoadArgb32Pixels(new Rectangle(0, 0, 100, 10));

                for (int i = 0; i < pixels.Length; i++)
                {
                    // specify pixel color value (gradient in this case).
                    pixels[i] = i;
                }

                // save modified pixels.
                image.SaveArgb32Pixels(new Rectangle(0, 0, 100, 10), pixels);

                // export image to bmp file format.
                image.Save(outpath, new BmpOptions());
            }

            //ExEnd:CoreDrawingFeatures

        }
    }
}
