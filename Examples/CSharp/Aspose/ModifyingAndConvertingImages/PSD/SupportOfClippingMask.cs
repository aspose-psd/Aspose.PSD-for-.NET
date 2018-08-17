using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfClippingMask
    {
        public static void Run()
        {
            //ExStart:SupportOfClippingMask
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Exposure layer editing
            // Export of the psd with complex clipping mask
            string sourceFileName = dataDir+"ClippingMaskComplex.psd";
            string exportPath = dataDir+ "ClippingMaskComplex.png";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                // Export to PNG
                var saveOptions = new PngOptions();
                saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
                im.Save(exportPath, saveOptions);
            }
            //ExEnd:SupportOfClippingMask

        }

    }
}
