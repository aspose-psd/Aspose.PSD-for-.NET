using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.FileFormats.Core.Blending;
using Aspose.PSD.FileFormats.Psd.Layers.Gradient;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddGradientEffects
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:AddGradientEffects
            void AssertIsTrue(bool condition, string message = "Assertion fails")
            {
                if (!condition)
                {
                    throw new FormatException(message);
                }
            }

            // Gradient overlay effect. Example
            string sourceFileName = Path.Combine(SourceDir, "GradientOverlay.psd");
            string exportPath = Path.Combine(OutputDir, "GradientOverlayChanged.psd");

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var gradientOverlay = (GradientOverlayEffect)im.Layers[1].BlendingOptions.Effects[0];

                AssertIsTrue(gradientOverlay.BlendMode == BlendMode.Normal);
                AssertIsTrue(gradientOverlay.Opacity == 255);
                AssertIsTrue(gradientOverlay.IsVisible == true);

                var settings = (GradientFillSettings)gradientOverlay.Settings;
                var solidGradient = (SolidGradient)gradientOverlay.Settings.Gradient;
                AssertIsTrue(Color.Empty == solidGradient.Color);
                AssertIsTrue(settings.FillType == FillType.Gradient);
                AssertIsTrue(settings.AlignWithLayer == true);
                AssertIsTrue(settings.GradientType == GradientType.Linear);
                AssertIsTrue(Math.Abs(33 - settings.Angle) < 0.001, "Angle is incorrect");
                AssertIsTrue(settings.Dither == false);
                AssertIsTrue(Math.Abs(129 - settings.HorizontalOffset) < 0.001, "Horizontal offset is incorrect");
                AssertIsTrue(Math.Abs(156 - settings.VerticalOffset) < 0.001, "Vertical offset is incorrect");
                AssertIsTrue(settings.Reverse == false);

                // Color Points
                var colorPoints = solidGradient.ColorPoints;
                AssertIsTrue(colorPoints.Length == 3);

                AssertIsTrue(colorPoints[0].Color == Color.FromArgb(9, 0, 178));
                AssertIsTrue(colorPoints[0].Location == 0);
                AssertIsTrue(colorPoints[0].MedianPointLocation == 50);

                AssertIsTrue(colorPoints[1].Color == Color.Red);
                AssertIsTrue(colorPoints[1].Location == 2048);
                AssertIsTrue(colorPoints[1].MedianPointLocation == 50);

                AssertIsTrue(colorPoints[2].Color == Color.FromArgb(255, 252, 0));
                AssertIsTrue(colorPoints[2].Location == 4096);
                AssertIsTrue(colorPoints[2].MedianPointLocation == 50);

                // Transparency points
                var transparencyPoints = solidGradient.TransparencyPoints;
                AssertIsTrue(transparencyPoints.Length == 2);

                AssertIsTrue(transparencyPoints[0].Location == 0);
                AssertIsTrue(transparencyPoints[0].MedianPointLocation == 50);
                AssertIsTrue(transparencyPoints[0].Opacity == 100);

                AssertIsTrue(transparencyPoints[1].Location == 4096);
                AssertIsTrue(transparencyPoints[1].MedianPointLocation == 50);
                AssertIsTrue(transparencyPoints[1].Opacity == 100);

                // Test editing
                solidGradient.Color = Color.Green;

                gradientOverlay.Opacity = 193;
                gradientOverlay.BlendMode = BlendMode.Lighten;

                settings.AlignWithLayer = false;
                settings.GradientType = GradientType.Radial;
                settings.Angle = 45;
                settings.Dither = true;
                settings.HorizontalOffset = 15;
                settings.VerticalOffset = 11;
                settings.Reverse = true;

                // Add new color point
                var colorPoint = solidGradient.AddColorPoint();
                colorPoint.Color = Color.Green;
                colorPoint.Location = 4096;
                colorPoint.MedianPointLocation = 75;

                // Change location of previous point
                solidGradient.ColorPoints[2].Location = 3000;

                // Add new transparency point
                var transparencyPoint = solidGradient.AddTransparencyPoint();
                transparencyPoint.Opacity = 25;
                transparencyPoint.MedianPointLocation = 25;
                transparencyPoint.Location = 4096;

                // Change location of previous transparency point
                solidGradient.TransparencyPoints[1].Location = 2315;
                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(exportPath, loadOptions))
            {
                var gradientOverlay = (GradientOverlayEffect)im.Layers[1].BlendingOptions.Effects[0];
                try
                {
                    AssertIsTrue(gradientOverlay.BlendMode == BlendMode.Lighten);
                    AssertIsTrue(gradientOverlay.Opacity == 193);
                    AssertIsTrue(gradientOverlay.IsVisible == true);

                    var fillSettings = (GradientFillSettings)gradientOverlay.Settings;
                    var solidGradient = (SolidGradient)gradientOverlay.Settings.Gradient;

                    AssertIsTrue(Color.Empty == solidGradient.Color);

                    AssertIsTrue(fillSettings.FillType == FillType.Gradient);

                    // Check color points
                    AssertIsTrue(solidGradient.ColorPoints.Length == 4);

                    var point = solidGradient.ColorPoints[0];
                    AssertIsTrue(point.MedianPointLocation == 50);
                    AssertIsTrue(point.Color == Color.FromArgb(9, 0, 178));
                    AssertIsTrue(point.Location == 0);

                    point = solidGradient.ColorPoints[1];
                    AssertIsTrue(point.MedianPointLocation == 50);
                    AssertIsTrue(point.Color == Color.Red);
                    AssertIsTrue(point.Location == 2048);

                    point = solidGradient.ColorPoints[2];
                    AssertIsTrue(point.MedianPointLocation == 50);
                    AssertIsTrue(point.Color == Color.FromArgb(255, 252, 0));
                    AssertIsTrue(point.Location == 3000);

                    point = solidGradient.ColorPoints[3];
                    AssertIsTrue(point.MedianPointLocation == 75);
                    AssertIsTrue(point.Color == Color.Green);
                    AssertIsTrue(point.Location == 4096);

                    // Check transparent points
                    AssertIsTrue(solidGradient.TransparencyPoints.Length == 3);

                    var transparencyPoint = solidGradient.TransparencyPoints[0];
                    AssertIsTrue(transparencyPoint.MedianPointLocation == 50);
                    AssertIsTrue(transparencyPoint.Opacity == 100.0);
                    AssertIsTrue(transparencyPoint.Location == 0);

                    transparencyPoint = solidGradient.TransparencyPoints[1];
                    AssertIsTrue(transparencyPoint.MedianPointLocation == 50);
                    AssertIsTrue(transparencyPoint.Opacity == 100.0);
                    AssertIsTrue(transparencyPoint.Location == 2315);

                    transparencyPoint = solidGradient.TransparencyPoints[2];
                    AssertIsTrue(transparencyPoint.MedianPointLocation == 25);
                    AssertIsTrue(transparencyPoint.Opacity == 25.0);
                    AssertIsTrue(transparencyPoint.Location == 4096);
                }
                catch (Exception e)
                {
                    string ex = e.StackTrace;
                }
            }
            //ExEnd:AddGradientEffects

            File.Delete(exportPath);
        }
    }
}
