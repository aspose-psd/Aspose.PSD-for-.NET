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
    class GradientFillLayers
    {
        public static void Run() {

            //ExStart:GradientFillLayers

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

           
            string fileName = dataDir+ "FillLayerGradient.psd";
            GradientType[] gradientTypes = new[]
            {
                GradientType.Linear, GradientType.Radial, GradientType.Angle, GradientType.Reflected, GradientType.Diamond
            };
            using (var image = Image.Load(fileName))
            {
                PsdImage psdImage = (PsdImage)image;
                FillLayer fillLayer = (FillLayer)psdImage.Layers[0];
                GradientFillSettings fillSettings = (GradientFillSettings)fillLayer.FillSettings;
                foreach (var gradientType in gradientTypes)
                {
                    fillSettings.GradientType = gradientType;
                    fillLayer.Update();
                    psdImage.Save(fileName + "_" + gradientType.ToString() + ".png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            //ExEnd:GradientFillLayers

        }
    }
}
