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
    class AddTextLayerOnRuntime
    {
        public static void Run()
        {
            //ExStart:AddTextLayerOnRuntime
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir+"OneLayer.psd";
            string psdPath = dataDir + "ImageWithTextLayer.psd";

            using (var img = Image.Load(sourceFileName))
            {
                PsdImage im = (PsdImage)img;
                var rect = new Rectangle(
                    (int)(im.Width * 0.25),
                    (int)(im.Height * 0.25),
                    (int)(im.Width * 0.5),
                    (int)(im.Height * 0.5));

                var layer = im.AddTextLayer("Added text", rect);

                im.Save(psdPath);
            }
            //ExEnd:AddTextLayerOnRuntime

        }

    }
}
