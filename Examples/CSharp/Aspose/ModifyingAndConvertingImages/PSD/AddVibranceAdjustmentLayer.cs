using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    internal class AddVibranceAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:AddVibranceAdjustmentLayer
            //ExSummary:The following code example demonstrates support of the VibranceLayer layer and the ability to edit this adjustment.
            
            string sourceFileName = Path.Combine(SourceDir, "WithoutVibrance.psd");
            string outputFileNamePsd = Path.Combine(OutputDir, "out_VibranceLayer.psd");
            string outputFileNamePng = Path.Combine(OutputDir, "out_VibranceLayer.png");

            using (PsdImage image = (PsdImage) Image.Load(sourceFileName))
            {
                // Creating a new VibranceLayer
                VibranceLayer vibranceLayer = image.AddVibranceAdjustmentLayer();
                vibranceLayer.Vibrance = 50;
                vibranceLayer.Saturation = 100;

                image.Save(outputFileNamePsd);
                image.Save(outputFileNamePng, new PngOptions());
            }
            
            //ExEnd:AddVibranceAdjustmentLayer
            
            Console.WriteLine("AddVibranceAdjustmentLayer executed successfully");

            File.Delete(outputFileNamePsd);
            File.Delete(outputFileNamePng);
        }
    }
}