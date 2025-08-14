using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    public class SupportOfExportLayerWithEffects
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfExportLayerWithEffects
            //ExSummary:Demonstrates how to get a layer’s bounds with effects and export it with the correct size.

            string srcFile = Path.Combine(baseDir, "1958.psd");
            string outputFile = Path.Combine(outputDir, "out_1958.png");

            using (var psdImage = (PsdImage)Image.Load(srcFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                var layer1 = psdImage.Layers[1];

                var layerBoudns = layer1.Bounds;
                foreach (var effect in layer1.BlendingOptions.Effects)
                {
                    layerBoudns = Rectangle.Union(
                        layerBoudns,
                        effect.GetEffectBounds(layer1.Bounds, psdImage.GlobalAngle));
                }

                Rectangle boundsToExport = Rectangle.Empty; // The default value is to save only the layer with effects.
                // boundsToExport = psdImage.Bounds; // To save within the PsdImage bounds at the original layer location

                layer1.Save(
                    outputFile,
                    new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha },
                    boundsToExport);

                using (var imgStream = new FileStream(outputFile, FileMode.Open))
                {
                    var loadedLayer = new Layer(imgStream);
                    if (loadedLayer.Size == layerBoudns.Size)
                    {
                        System.Console.WriteLine("The size is calculated correctly.");
                    }
                }
            }

            //ExEnd:SupportOfExportLayerWithEffects

            File.Delete(outputFile);

            Console.WriteLine("SupportOfExportLayerWithEffects executed successfully");
        }
    }
}
