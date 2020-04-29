using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using System;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.FillLayers
{
    class AddingFillLayerAtRuntime
    {
        public static void Run()
        {
            // The path to the documents directory.
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:AddingFillLayerAtRuntime            
            //ExSummary:The following example demonstrates how to add the FillLayer type layer at runtime.
            string outputFilePath = Path.Combine(OutputDir, "output.psd");

            using (var image = new PsdImage(100, 100))
            {
                FillLayer colorFillLayer = FillLayer.CreateInstance(FillType.Color);
                colorFillLayer.DisplayName = "Color Fill Layer";
                image.AddLayer(colorFillLayer);

                FillLayer gradientFillLayer = FillLayer.CreateInstance(FillType.Gradient);
                gradientFillLayer.DisplayName = "Gradient Fill Layer";
                image.AddLayer(gradientFillLayer);

                FillLayer patternFillLayer = FillLayer.CreateInstance(FillType.Pattern);
                patternFillLayer.DisplayName = "Pattern Fill Layer";
                patternFillLayer.Opacity = 50;
                image.AddLayer(patternFillLayer);

                image.Save(outputFilePath);
            }

            //ExEnd:AddingFillLayerAtRuntime
            Console.WriteLine("AddingFillLayerAtRuntime executed successfully");
        }
    }
}
