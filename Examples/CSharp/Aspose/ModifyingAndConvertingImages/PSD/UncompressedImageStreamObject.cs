using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class UncompressedImageStreamObject
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:UncompressedImageStreamObject
            using (MemoryStream stream = new MemoryStream())
            {
                // Load a PSD file as an image and cast it into PsdImage
                using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
                {
                    PsdOptions saveOptions = new PsdOptions();
                    saveOptions.CompressionMethod = CompressionMethod.Raw;
                    psdImage.Save(stream, saveOptions);

                }

                // Now reopen the newly created image. But first seek to the beginning of stream since after saving seek is at the end now.
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                using (PsdImage psdImage = (PsdImage)Image.Load(stream))
                {
                    Graphics graphics = new Graphics(psdImage);
                    // Perform graphics operations.
                }
            }
            //ExEnd:UncompressedImageStreamObject
        }
    }
}
