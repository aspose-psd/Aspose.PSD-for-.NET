using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.Ai
{
    class SupportOfLayersInAi
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir_AI();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart
            //ExSummary:The following example demonstrates support of layers in AI format files.

            string sourceFilePath = Path.Combine(dataDir, "form_8_2l3_7.ai");
            string outputFilePath = Path.Combine(OutputDir, "form_8_2l3_7_export");

            void AssertIsTrue(bool condition, string message)
            {
                if (!condition)
                {
                    throw new FormatException(message);
                }
            }

            using (AiImage image = (AiImage)Image.Load(sourceFilePath))
            {
                AiLayerSection layer0 = image.Layers[0];
                AssertIsTrue(layer0 != null, "Layer 0 should be not null.");
                AssertIsTrue(layer0.Name == "Layer 4", "The Name property of the layer 0 should be `Layer 4`");
                AssertIsTrue(!layer0.IsTemplate, "The IsTemplate property of the layer 0 should be false.");
                AssertIsTrue(layer0.IsLocked, "The IsLocked property of the layer 0 should be true.");
                AssertIsTrue(layer0.IsShown, "The IsShown property of the layer 0 should be true.");
                AssertIsTrue(layer0.IsPrinted, "The IsPrinted property of the layer 0 should be true.");
                AssertIsTrue(!layer0.IsPreview, "The IsPreview property of the layer 0 should be false.");
                AssertIsTrue(layer0.IsImagesDimmed, "The IsImagesDimmed property of the layer 0 should be true.");
                AssertIsTrue(layer0.DimValue == 51, "The DimValue property of the layer 0 should be 51.");
                AssertIsTrue(layer0.ColorNumber == 0, "The ColorNumber property of the layer 0 should be 0.");
                AssertIsTrue(layer0.Red == 79, "The Red property of the layer 0 should be 79.");
                AssertIsTrue(layer0.Green == 128, "The Green property of the layer 0 should be 128.");
                AssertIsTrue(layer0.Blue == 255, "The Blue property of the layer 0 should be 255.");
                AssertIsTrue(layer0.RasterImages.Length == 0, "The pixels length property of the raster image in the layer 0 should equals 0.");

                AiLayerSection layer1 = image.Layers[1];
                AssertIsTrue(layer1 != null, "Layer 1 should be not null.");
                AssertIsTrue(layer1.Name == "Layer 1", "The Name property of the layer 1 should be `Layer 1`");
                AssertIsTrue(layer1.RasterImages.Length == 1, "The length property of the raster images in the layer 1 should equals 1.");

                AiRasterImageSection rasterImage = layer1.RasterImages[0];
                AssertIsTrue(rasterImage != null, "The raster image in the layer 1 should be not null.");
                AssertIsTrue(rasterImage.Pixels != null, "The pixels property of the raster image in the layer 1 should be not null.");
                AssertIsTrue(string.Empty == rasterImage.Name, "The Name property of the raster image in the layer 1 should be empty");
                AssertIsTrue(rasterImage.Pixels.Length == 100, "The pixels length property of the raster image in the layer 1 should equals 100.");

                image.Save(outputFilePath + ".psd", new PsdOptions());
                image.Save(outputFilePath + ".png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            //ExEnd
        }
    }
}
