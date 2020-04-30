using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using System;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.LayerEffects
{
    class RenderingOfGradientOverlayEffect
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:RenderingOfGradientOverlayEffect
            //ExSummary:The following example demonstrates how Aspose.PSD can render the Gradient Overlay Layer Effect 

            string sourceFilePath = Path.Combine(SourceDir, "gradientOverlayEffect.psd");
            string outputFilePath = Path.Combine(OutputDir, "output");
            string outputPng = outputFilePath + ".png";
            string outputPsd = outputFilePath + ".psd";

            using (var psdImage = (PsdImage)Image.Load(sourceFilePath, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                psdImage.Save(outputPng, new PngOptions());
                psdImage.Save(outputPsd);
            }

            //ExEnd:RenderingOfGradientOverlayEffect

            Console.WriteLine("SupportOfGradientOverlayEffect executed successfully");
        }
    }
}
