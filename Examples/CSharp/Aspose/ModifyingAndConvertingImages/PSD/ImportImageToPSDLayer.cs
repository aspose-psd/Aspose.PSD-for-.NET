using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ImportImageToPSDLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ImportImageToPSDLayer

            // Load a PSD file as an image and caste it into PsdImage
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                //Extract a layer from PSDImage
                Layer layer = image.Layers[1];

                // Create an image that is needed to be imported into the PSD file.
                using (PsdImage drawImage = new PsdImage(200, 200))
                {
                    // Fill image surface as needed.
                    Graphics g = new Graphics(drawImage);
                    g.Clear(Color.Yellow);

                    // Call DrawImage method of the Layer class and pass the image instance.
                    layer.DrawImage(new Point(10, 10), drawImage);
                }

                // Save the results to output path.
                image.Save(dataDir + "ImportImageToPSDLayer_out.psd");
            }

            //ExEnd:ImportImageToPSDLayer

        }
    }
}
