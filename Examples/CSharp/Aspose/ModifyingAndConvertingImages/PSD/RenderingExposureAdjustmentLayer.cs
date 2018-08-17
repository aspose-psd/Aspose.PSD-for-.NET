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
    class RenderingExposureAdjustmentLayer
    {
        public static void Run()
        {
            //ExStart:RenderingExposureAdjustmentLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Exposure layer editing
            string sourceFileName = dataDir+"ExposureAdjustmentLayer.psd";
            string psdPathAfterChange = dataDir + "ExposureAdjustmentLayerChanged.psd";
            string pngExportPath = dataDir + "ExposureAdjustmentLayerChanged.png";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is ExposureLayer)
                    {
                        var expLayer = (ExposureLayer)layer;
                        expLayer.Exposure = 2;
                        expLayer.Offset = -0.25f;
                        expLayer.GammaCorrection = 0.5f;
                    }
                }

                // Save PSD
                im.Save(psdPathAfterChange);

                // Save PNG
                var saveOptions = new PngOptions();
                saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
                im.Save(pngExportPath, saveOptions);
            }

            // Exposure layer adding
            sourceFileName = dataDir+"PhotoExample.psd";
            psdPathAfterChange = dataDir + "PhotoExampleAddedExposure.psd";
            pngExportPath = dataDir + "PhotoExampleAddedExposure.png";

            using (PsdImage im = (PsdImage)Image.Load(sourceFileName))
            {
                var newlayer = im.AddExposureAdjustmentLayer();
                newlayer.Exposure = 2;
                newlayer.Offset = -0.25f;
                newlayer.GammaCorrection = 2f;

                // Save PSD
                im.Save(psdPathAfterChange);

                // Save PNG
                var saveOptions = new PngOptions();
                saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
                im.Save(pngExportPath, saveOptions);
            }
            //ExEnd:RenderingExposureAdjustmentLayer

        }

    }
}
