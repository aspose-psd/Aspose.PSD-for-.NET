using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.FileFormats.Core.Blending;
using Aspose.PSD.FileFormats.Psd.Layers.Gradient;
using Aspose.PSD.FileFormats.Psd.Core.RawColor;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.FileFormats.Png;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class SupportOfBevelEmbossEffect
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfBevelEmbossEffect
            //ExSummary:The following code demonstrates the BevelEmboss effect.

            string sourceFile = Path.Combine(baseDir, "file.psd");
            string outputFilePng = Path.Combine(outputDir, "output.png");

            using (var psdImage = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions { LoadEffectsResource = true }))
            {
                var bevelEmbossEffect = psdImage.Layers[1].BlendingOptions.Effects[0] as BevelEmbossEffect;

                bevelEmbossEffect.Opacity = 0;
                bevelEmbossEffect.BlendMode = BlendMode.DarkerColor;

                var imageOptions = new PsdOptions(psdImage);
                psdImage.Save(outputFilePng, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
            
            //ExEnd:SupportOfBevelEmbossEffect

            File.Delete(outputFilePng);

            Console.WriteLine("SupportOfBevelEmbossEffect executed successfully");
        }
    }
}
