using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddGradientEffects
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddGradientEffects

            // Gradient overlay effect. Example
            string sourceFileName = dataDir + "GradientOverlay.psd";
            string exportPath = dataDir + "GradientOverlayChanged.psd";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var gradientOverlay = (GradientOverlayEffect)im.Layers[1].BlendingOptions.Effects[0];

                Assert.AreEqual(BlendMode.Normal, gradientOverlay.BlendMode);
                Assert.AreEqual(255, gradientOverlay.Opacity);
                Assert.AreEqual(true, gradientOverlay.IsVisible);

                var settings = gradientOverlay.Settings;
                Assert.AreEqual(Color.Empty, settings.Color);
                Assert.AreEqual(FillType.Gradient, settings.FillType);
                Assert.AreEqual(true, settings.AlignWithLayer);
                Assert.AreEqual(GradientType.Linear, settings.GradientType);
                Assert.IsTrue(Math.Abs(33 - settings.Angle) < 0.001, "Angle is incorrect");
                Assert.AreEqual(false, settings.Dither);
                Assert.IsTrue(Math.Abs(129 - settings.HorizontalOffset) < 0.001, "Horizontal offset is incorrect");
                Assert.IsTrue(Math.Abs(156 - settings.VerticalOffset) < 0.001, "Vertical offset is incorrect");
                Assert.AreEqual(false, settings.Reverse);

                // Color Points
                var colorPoints = settings.ColorPoints;
                Assert.AreEqual(3, colorPoints.Length);

                Assert.AreEqual(Color.FromArgb(9, 0, 178), colorPoints[0].Color);
                Assert.AreEqual(0, colorPoints[0].Location);
                Assert.AreEqual(50, colorPoints[0].MedianPointLocation);

                Assert.AreEqual(Color.Red, colorPoints[1].Color);
                Assert.AreEqual(2048, colorPoints[1].Location);
                Assert.AreEqual(50, colorPoints[1].MedianPointLocation);

                Assert.AreEqual(Color.FromArgb(255, 252, 0), colorPoints[2].Color);
                Assert.AreEqual(4096, colorPoints[2].Location);
                Assert.AreEqual(50, colorPoints[2].MedianPointLocation);

                // Transparency points
                var transparencyPoints = settings.TransparencyPoints;
                Assert.AreEqual(2, transparencyPoints.Length);

                Assert.AreEqual(0, transparencyPoints[0].Location);
                Assert.AreEqual(50, transparencyPoints[0].MedianPointLocation);
                Assert.AreEqual(100, transparencyPoints[0].Opacity);

                Assert.AreEqual(4096, transparencyPoints[1].Location);
                Assert.AreEqual(50, transparencyPoints[1].MedianPointLocation);
                Assert.AreEqual(100, transparencyPoints[1].Opacity);

                // Test editing
                settings.Color = Color.Green;

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
                var colorPoint = settings.AddColorPoint();
                colorPoint.Color = Color.Green;
                colorPoint.Location = 4096;
                colorPoint.MedianPointLocation = 75;

                // Change location of previous point
                settings.ColorPoints[2].Location = 3000;

                // Add new transparency point
                var transparencyPoint = settings.AddTransparencyPoint();
                transparencyPoint.Opacity = 25;
                transparencyPoint.MedianPointLocation = 25;
                transparencyPoint.Location = 4096;

                // Change location of previous transparency point
                settings.TransparencyPoints[1].Location = 2315;
                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var gradientOverlay = (GradientOverlayEffect)im.Layers[1].BlendingOptions.Effects[0];
                try
                {
                    Assert.AreEqual(BlendMode.Lighten, gradientOverlay.BlendMode);
                    Assert.AreEqual(193, gradientOverlay.Opacity);
                    Assert.AreEqual(true, gradientOverlay.IsVisible);

                    var fillSettings = gradientOverlay.Settings;
                    Assert.AreEqual(Color.Empty, fillSettings.Color);
                    Assert.AreEqual(FillType.Gradient, fillSettings.FillType);

                    // Check color points
                    Assert.AreEqual(4, fillSettings.ColorPoints.Length);

                    var point = fillSettings.ColorPoints[0];
                    Assert.AreEqual(50, point.MedianPointLocation);
                    Assert.AreEqual(Color.FromArgb(9, 0, 178), point.Color);
                    Assert.AreEqual(0, point.Location);

                    point = fillSettings.ColorPoints[1];
                    Assert.AreEqual(50, point.MedianPointLocation);
                    Assert.AreEqual(Color.Red, point.Color);
                    Assert.AreEqual(2048, point.Location);

                    point = fillSettings.ColorPoints[2];
                    Assert.AreEqual(50, point.MedianPointLocation);
                    Assert.AreEqual(Color.FromArgb(255, 252, 0), point.Color);
                    Assert.AreEqual(3000, point.Location);

                    point = fillSettings.ColorPoints[3];
                    Assert.AreEqual(75, point.MedianPointLocation);
                    Assert.AreEqual(Color.Green, point.Color);
                    Assert.AreEqual(4096, point.Location);

                    // Check transparent points
                    Assert.AreEqual(3, fillSettings.TransparencyPoints.Length);

                    var transparencyPoint = fillSettings.TransparencyPoints[0];
                    Assert.AreEqual(50, transparencyPoint.MedianPointLocation);
                    Assert.AreEqual(100, transparencyPoint.Opacity);
                    Assert.AreEqual(0, transparencyPoint.Location);

                    transparencyPoint = fillSettings.TransparencyPoints[1];
                    Assert.AreEqual(50, transparencyPoint.MedianPointLocation);
                    Assert.AreEqual(100, transparencyPoint.Opacity);
                    Assert.AreEqual(2315, transparencyPoint.Location);

                    transparencyPoint = fillSettings.TransparencyPoints[2];
                    Assert.AreEqual(25, transparencyPoint.MedianPointLocation);
                    Assert.AreEqual(25, transparencyPoint.Opacity);
                    Assert.AreEqual(4096, transparencyPoint.Location);
                }
                catch (Exception e)
                {
                    string ex = e.StackTrace;
                }
            }
            //ExEnd:AddGradientEffects
        }
    }
}
