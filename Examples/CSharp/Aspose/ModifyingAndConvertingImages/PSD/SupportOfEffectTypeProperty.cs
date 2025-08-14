using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfEffectTypeProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportOfEffectTypeProperty
            //ExSummary:The following code demonstrates support of ILayerEffect.EffectType property.
            
            string inputFile = Path.Combine(baseDir, "input.psd");
            string outputWithout = Path.Combine(outputDir, "outputWithout.png");
            string outputWith = Path.Combine(outputDir, "outputWith.png");

            using (PsdImage psdImage = (PsdImage)Image.Load(inputFile, new LoadOptions()))
            {
                psdImage.Save(outputWithout, new PngOptions());

                Layer workLayer = psdImage.Layers[1];

                DropShadowEffect dropShadowEffect = workLayer.BlendingOptions.AddDropShadow();
                dropShadowEffect.Distance = 0;
                dropShadowEffect.Size = 8;
                dropShadowEffect.Opacity = 20;

                foreach (ILayerEffect iEffect in workLayer.BlendingOptions.Effects)
                {
                    if (iEffect.EffectType == LayerEffectsTypes.DropShadow)
                    {
                        // it caught
                        psdImage.Save(outputWith, new PngOptions());
                    }
                }
            }

            //ExEnd:SupportOfEffectTypeProperty
            
            File.Delete(outputWithout);
            File.Delete(outputWith);
            
            Console.WriteLine("SupportOfEffectTypeProperty executed successfully");
        }
    }
}
