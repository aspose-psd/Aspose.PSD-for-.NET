using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using System;
using System.IO;
using Aspose.PSD.FileFormats.Core.Blending;

namespace Aspose.PSD.Examples.Aspose.LayerEffects
{
    class SupportOfGradientOverlayEffect
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart            
            //ExSummary:The following example demonstrates how to create/edit the GradientOverlayEffect effect object in layer.

            string sourceFilePath = Path.Combine(SourceDir, "psdnet256.psd");
            string outputFilePath = Path.Combine(OutputDir, "psdnet256.psd_output.psd");

            // Creates/Gets and edits the gradient overlay effect in a layer.
            using (var psdImage = (PsdImage)Image.Load(sourceFilePath, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                BlendingOptions layerBlendOptions = psdImage.Layers[1].BlendingOptions;
                GradientOverlayEffect gradientOverlayEffect = null;

                // Search GradientOverlayEffect in a layer.
                foreach (ILayerEffect effect in layerBlendOptions.Effects)
                {
                    gradientOverlayEffect = effect as GradientOverlayEffect;
                    if (gradientOverlayEffect != null)
                    {
                        break;
                    }
                }

                if (gradientOverlayEffect == null)
                {
                    // You can create a new GradientOverlayEffect if it not exists.
                    gradientOverlayEffect = layerBlendOptions.AddGradientOverlay();
                }

                // Add a bit of transparency to the effect.
                gradientOverlayEffect.Opacity = 200;

                // Change the blend mode of gradient effect.
                gradientOverlayEffect.BlendMode = BlendMode.Hue;

                // Gets GradientFillSettings object to configure gradient overlay settings.
                GradientFillSettings settings = (GradientFillSettings)gradientOverlayEffect.Settings;

                // Setting a new gradient with two colors.
                settings.ColorPoints = new IGradientColorPoint[]
                {
                    new GradientColorPoint(Color.GreenYellow, 0, 50),
                    new GradientColorPoint(Color.BlueViolet, 4096, 50),
                };

                // Sets an inclination of the gradient at an angle of 80 degrees.
                settings.Angle = 80;

                // Scale gradient effect up to 150%.
                settings.Scale = 150;

                // Sets type of gradient.
                settings.GradientType = GradientType.Linear;

                // Make the gradient opaque by setting the opacity to 100% at each transparency point.
                settings.TransparencyPoints[0].Opacity = 100;
                settings.TransparencyPoints[1].Opacity = 100;

                psdImage.Save(outputFilePath);
            }

            //ExEnd

            Console.WriteLine("SupportOfGradientOverlayEffect executed successfully");
        }
    }
}
