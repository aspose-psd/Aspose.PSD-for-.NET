using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddSignatureToImage
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddSignatureToImage

            // Create an instance of Image and load the primary image
            using (Image canvas = Image.Load(dataDir + "layers.psd"))
            {
                // Create another instance of Image and load the secondary image containing the signature graphics
                using (Image signature = Image.Load(dataDir + "sample.psd"))
                {
                    // Create an instance of Graphics class and initialize it using the object of the primary image
                    Graphics graphics = new Graphics(canvas);

                    // Call the DrawImage method while passing the instance of secondary image and appropriate location. The following snippet tries to draw the secondary image at the right bottom of the primary image
                    graphics.DrawImage(signature, new Point(canvas.Height - signature.Height, canvas.Width - signature.Width));
                    canvas.Save(dataDir + "AddSignatureToImage_out.png", new PngOptions());
                }
            }

            //ExEnd:AddSignatureToImage
        }
    }
}
