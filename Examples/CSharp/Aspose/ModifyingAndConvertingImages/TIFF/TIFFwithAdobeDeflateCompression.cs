using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.TIFF
{
    class TIFFwithAdobeDeflateCompression
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:TIFFwithAdobeDeflateCompression

            // Create an instance of TiffOptions and set its various properties
            TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
            options.BitsPerSample = new ushort[] { 8, 8, 8 };
            options.Photometric = TiffPhotometrics.Rgb;
            options.Xresolution = new TiffRational(72);
            options.Yresolution = new TiffRational(72);
            options.ResolutionUnit = TiffResolutionUnits.Inch;
            options.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Set the Compression to AdobeDeflate
            options.Compression = TiffCompressions.AdobeDeflate;

            //Create a new image with specific size and TiffOptions settings
            using (PsdImage image = new PsdImage(100, 100))
            {

                // Fill image data.
                int count = image.Width * image.Height;
                int[] pixels = new int[count];

                for (int i = 0; i < count; i++)
                {

                    pixels[i] = Color.Red.ToArgb();
                }

                // Save the newly created pixels.
                image.SaveArgb32Pixels(image.Bounds, pixels);

                // Save resultant image
                image.Save(dataDir + "TIFFwithAdobeDeflateCompression_output.tif", options);
            }


            //ExEnd:TIFFwithAdobeDeflateCompression
        }
    }
}
