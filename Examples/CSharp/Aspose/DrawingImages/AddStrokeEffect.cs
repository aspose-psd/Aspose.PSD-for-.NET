using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddStrokeEffect
    {
        public static void Run()
        {
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart
            //ExSummary:This example demonstrates the ability to add the stroke effect with different types of fill like Color, Gradient or Pattern.

            string srcFile = Path.Combine(SourceDir, "AddStrokeEffect.psd");
            string outputFilePng = Path.Combine(OutputDir, "AddStrokeEffect.png");

            using (var psdImage = (PsdImage)Image.Load(srcFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                StrokeEffect strokeEffect;
                IColorFillSettings colorFillSettings;
                IGradientFillSettings gradientFillSettings;
                IPatternFillSettings patternFillSettings;

                // 1. Adds Color fill, at position Inside
                strokeEffect = psdImage.Layers[1].BlendingOptions.AddStroke(FillType.Color);
                strokeEffect.Size = 7;
                strokeEffect.Position = StrokePosition.Inside;
                colorFillSettings = strokeEffect.FillSettings as IColorFillSettings;
                colorFillSettings.Color = Color.Green;

                // 2. Adds Color fill, at position Outside
                strokeEffect = psdImage.Layers[2].BlendingOptions.AddStroke(FillType.Color);
                strokeEffect.Size = 7;
                strokeEffect.Position = StrokePosition.Outside;
                colorFillSettings = strokeEffect.FillSettings as IColorFillSettings;
                colorFillSettings.Color = Color.Green;

                // 3. Adds Color fill, at position Center
                strokeEffect = psdImage.Layers[3].BlendingOptions.AddStroke(FillType.Color);
                strokeEffect.Size = 7;
                strokeEffect.Position = StrokePosition.Center;
                colorFillSettings = strokeEffect.FillSettings as IColorFillSettings;
                colorFillSettings.Color = Color.Green;

                // 4. Adds Gradient fill, at position Inside
                strokeEffect = psdImage.Layers[4].BlendingOptions.AddStroke(FillType.Gradient);
                strokeEffect.Size = 5;
                strokeEffect.Position = StrokePosition.Inside;
                gradientFillSettings = strokeEffect.FillSettings as IGradientFillSettings;
                gradientFillSettings.AlignWithLayer = false;
                gradientFillSettings.Angle = 90;

                // 5. Adds Gradient fill, at position Outside
                strokeEffect = psdImage.Layers[5].BlendingOptions.AddStroke(FillType.Gradient);
                strokeEffect.Size = 5;
                strokeEffect.Position = StrokePosition.Outside;
                gradientFillSettings = strokeEffect.FillSettings as IGradientFillSettings;
                gradientFillSettings.AlignWithLayer = true;
                gradientFillSettings.Angle = 90;

                // 6. Adds Gradient fill, at position Center
                strokeEffect = psdImage.Layers[6].BlendingOptions.AddStroke(FillType.Gradient);
                strokeEffect.Size = 5;
                strokeEffect.Position = StrokePosition.Center;
                gradientFillSettings = strokeEffect.FillSettings as IGradientFillSettings;
                gradientFillSettings.AlignWithLayer = true;
                gradientFillSettings.Angle = 0;

                // 7. Adds Pattern fill, at position Inside
                strokeEffect = psdImage.Layers[7].BlendingOptions.AddStroke(FillType.Pattern);
                strokeEffect.Size = 5;
                strokeEffect.Position = StrokePosition.Inside;
                patternFillSettings = strokeEffect.FillSettings as IPatternFillSettings;
                patternFillSettings.Scale = 200;

                // 8. Adds Pattern fill, at position Outside
                strokeEffect = psdImage.Layers[8].BlendingOptions.AddStroke(FillType.Pattern);
                strokeEffect.Size = 10;
                strokeEffect.Position = StrokePosition.Outside;
                patternFillSettings = strokeEffect.FillSettings as IPatternFillSettings;
                patternFillSettings.Scale = 100;

                // 9. Adds Pattern fill, at position Center
                strokeEffect = psdImage.Layers[9].BlendingOptions.AddStroke(FillType.Pattern);
                strokeEffect.Size = 10;
                strokeEffect.Position = StrokePosition.Center;
                patternFillSettings = strokeEffect.FillSettings as IPatternFillSettings;
                patternFillSettings.Scale = 75;

                psdImage.Save(outputFilePng, new PngOptions());
            }

            //ExEnd

            Console.WriteLine("AddStrokeEffect executed successfully");
        }
    }
}
