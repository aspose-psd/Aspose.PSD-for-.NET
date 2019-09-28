using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfScaleProperty
    {
        public static void Run() {

            //ExStart:SupportOfScaleProperty

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            using (var image = (PsdImage)Image.Load(dataDir+"FillLayerGradient.psd"))
            {
                // getting a fill layer
                FillLayer fillLayer = null;
                foreach (var layer in image.Layers)
                {
                    fillLayer = layer as FillLayer;
                    if (fillLayer != null)
                    {
                        break;
                    }
                }

                var settings = fillLayer.FillSettings as IGradientFillSettings;

                // update scale value
                settings.Scale = 200;
                fillLayer.Update(); // Updates pixels data

                image.Save(dataDir +  "scaledImage.png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }


            //ExEnd:SupportOfScaleProperty

        }
    }
}
