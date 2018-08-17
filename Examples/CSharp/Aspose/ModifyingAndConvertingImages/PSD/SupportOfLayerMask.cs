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
    class SupportOfLayerMask
    {
        public static void Run()
        {
            //ExStart:SupportOfLayerMask
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Export of the psd with complex mask
            string sourceFileName = dataDir + "MaskComplex.psd";
            string exportPath = dataDir + "MaskComplex.png";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                // Export to PNG
                var saveOptions = new PngOptions();
                saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
                im.Save(exportPath, saveOptions);
            }
            //ExEnd:SupportOfLayerMask

        }

    }
}
