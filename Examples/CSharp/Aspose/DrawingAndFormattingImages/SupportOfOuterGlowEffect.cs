using System;
using System.IO;
using Aspose.PSD.FileFormats.Core.Blending;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    public class SupportOfOuterGlowEffect
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportOfOuterGlowEffect
            //ExSummary:The following code demonstrates the OuterGlowEffect support.

            string src = Path.Combine(baseDir, "GreenLayer.psd");
            string outputPng = Path.Combine(outputDir, "output261.png");

            using (var image = (PsdImage)Image.Load(src))
            {
                OuterGlowEffect effect = image.Layers[1].BlendingOptions.AddOuterGlow();
                effect.Range = 10;
                effect.Spread = 10;
                ((IColorFillSettings)effect.FillColor).Color = Color.Red;
                effect.Opacity = 128;
                effect.BlendMode = BlendMode.Normal;

                image.Save(outputPng, new PngOptions());
            }

            //ExEnd:SupportOfOuterGlowEffect
            
            File.Delete(outputPng);
            
            Console.WriteLine("SupportOfOuterGlowEffect executed successfully");
        }
        
    }
}