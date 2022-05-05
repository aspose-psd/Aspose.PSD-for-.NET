using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    public class SupportShadowEffectOpacity
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportShadowEffectOpacity
            //ExSummary:The following code demonstrates using the Opacity property of DropShadowEffect.
            
            string inputFile = Path.Combine(baseDir, "input.psd");
            string outputImage20 = Path.Combine(outputDir, "outputImage20.png");
            string outputImage200 = Path.Combine(outputDir, "outputImage200.png");

            using (PsdImage psdImage = (PsdImage)Image.Load(inputFile, new LoadOptions()))
            {
                Layer workLayer = psdImage.Layers[1];

                DropShadowEffect dropShadowEffect = workLayer.BlendingOptions.AddDropShadow();
                dropShadowEffect.Distance = 0;
                dropShadowEffect.Size = 8;

                // Example with Opacity = 20
                dropShadowEffect.Opacity = 20;
                psdImage.Save(outputImage20, new PngOptions());

                // Example with Opacity = 200
                dropShadowEffect.Opacity = 200;
                psdImage.Save(outputImage200, new PngOptions());
            }
            
            //ExEnd:SupportShadowEffectOpacity
            
            File.Delete(outputImage20);
            File.Delete(outputImage200);
            
            Console.WriteLine("SupportShadowEffectOpacity executed successfully");
        }
    }
}


