using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class UncompressedImageUsingFile
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:UncompressedImageUsingFile

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            {
                PsdOptions saveOptions = new PsdOptions();
                saveOptions.CompressionMethod = CompressionMethod.Raw;
                psdImage.Save(dataDir + "uncompressed_out.psd", saveOptions);
            }

            // Now reopen the newly created image.
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "uncompressed_out.psd"))
            {
                Graphics graphics = new Graphics(psdImage);
                // Perform graphics operations.
            }

            //ExEnd:UncompressedImageUsingFile
        }
    }
}
