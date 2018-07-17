using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // Create a new TiffImage with specific size and TiffOptions settings
            using (TiffImage tiffImage = new TiffImage(new TiffFrame(options, 100, 100)))
            {
                // Loop over the pixels to set the color to red
                for (int j = 0; j < tiffImage.Height; j++)
                {
                    for (int i = 0; i < tiffImage.Width; i++)
                    {
                        tiffImage.ActiveFrame.SetPixel(i, j, Color.Red);
                    }
                }

                // Save resultant image
                tiffImage.Save(dataDir+"TIFFwithAdobeDeflateCompression_output.tif");
            }


            //ExEnd:TIFFwithAdobeDeflateCompression
        }
    }
}
