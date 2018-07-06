using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class GIFImageLayersToTIFF
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ModifyingAndConvertingImages();

            //ExStart:GIFImageLayersToTIFF

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"output";

            // Load a PSD image and Convert the image's layers to Tiff images.
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                // Iterate through array of PSD layers
                for (int i = 0; i < image.Layers.Length; i++)
                {
                    // Get PSD layer.
                    Layer layer = image.Layers[i];

                    // Create an instance of TIFF Option class and Save the PSD layer as TIFF image
                    TiffOptions objTiff = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb);
                    layer.Save("output" + i + "_out.tif", objTiff);
                }
            }

            //ExEnd:GIFImageLayersToTIFF

            }
        }
}
