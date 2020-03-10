using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.TIFF
{
    class TIFFwithDeflateCompression
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:TIFFwithDeflateCompression

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            {
                // Create an instance of TiffOptions while specifying desired format and compression
                TiffOptions options = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb);
                options.Compression = TiffCompressions.AdobeDeflate;
                psdImage.Save(dataDir + "TIFFwithDeflateCompression_out.tiff", options);
            }

            //ExEnd:TIFFwithDeflateCompression
        }
    }
}
