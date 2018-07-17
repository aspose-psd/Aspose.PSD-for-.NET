using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ExportPSDLayerToRasterImage
    {
        public static void Run()
        {
            //ExStart:ExportPSDLayerToRasterImage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and caste it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                // Create an instance of PngOptions class
                var pngOptions = new PngOptions();
                pngOptions.ColorType = PngColorType.TruecolorWithAlpha;

                // Loop through the list of layers
                for (int i = 0; i < psdImage.Layers.Length; i++)
                {
                    // Convert and save the layer to PNG file format.
                    psdImage.Layers[i].Save(string.Format("layer_out{0}.png", i + 1), pngOptions);
                }
            }


            //ExEnd:ExportPSDLayerToRasterImage

        }
    }
}
