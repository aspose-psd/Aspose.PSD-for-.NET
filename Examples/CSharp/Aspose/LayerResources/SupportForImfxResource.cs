using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportForImfxResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportForImfxResource
            //ExSummary:The following code demonstrates suport of multi-effects resource.

            // PSD image contains 2 Drop Shadow effects 
            string sourceFile = Path.Combine(baseDir, "MultiExample.psd");
            string outputFile1 = Path.Combine(outputDir, "export1.png");
            string outputFile2 = Path.Combine(outputDir, "export2.png");
            string outputFile3 = Path.Combine(outputDir, "export3.png");

            using (PsdImage image = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                // It renders PSD image with 2 Drop Shadow effects
                image.Save(outputFile1, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });

                var blendingOptions = image.Layers[0].BlendingOptions;

                // It adds a third Drop Shadow effect.
                DropShadowEffect dropShadowEffect3 = blendingOptions.AddDropShadow();
                dropShadowEffect3.Color = Color.Red;
                dropShadowEffect3.Distance = 50;
                dropShadowEffect3.Angle = 0;

                // It renders PSD image with 3 Drop Shadow effects
                image.Save(outputFile2, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });

                // The imfx resource is used if the layer contains multiple effects of the same type.
                var imfx = (ImfxResource)image.Layers[0].Resources[0];

                // It clears all effects
                blendingOptions.Effects = new ILayerEffect[0];

                DropShadowEffect dropShadowEffect1 = blendingOptions.AddDropShadow();
                dropShadowEffect1.Color = Color.Blue;
                dropShadowEffect1.Distance = 10;

                // It renders PSD image with 1 Drop Shadow effects (others was deleted)
                image.Save(outputFile3, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });

                // The lfx2 resource is used if the layer does not contain multiple effects of the same type.
                var lfx2 = (Lfx2Resource)image.Layers[0].Resources[14];
            }

            //ExEnd:SupportForImfxResource

            File.Delete(outputFile1);
            File.Delete(outputFile2);
            File.Delete(outputFile3);

            Console.WriteLine("SupportForImfxResource executed successfully");
        }
    }
}
