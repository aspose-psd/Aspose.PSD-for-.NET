using System;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.FileFormats.Core.Blending;
using Aspose.PSD.FileFormats.Psd.Layers.Gradient;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddStrokeLayer_Gradient
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddStrokeLayer_Gradient

            // Stroke effect. FillType - Gradient. Example
            void AssertIsTrue(bool condition, string message = "Assertion fails")
            {
                if (!condition)
                {
                    throw new FormatException(message);
                }
            }

            string sourceFileName = dataDir + "Stroke.psd";
            string exportPath = dataDir + "StrokeGradientChanged.psd";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var gradientStroke = (StrokeEffect)im.Layers[2].BlendingOptions.Effects[0];

                AssertIsTrue(gradientStroke.BlendMode == BlendMode.Normal);
                AssertIsTrue(gradientStroke.Opacity == 255);
                AssertIsTrue(gradientStroke.IsVisible);

                var fillSettings = (GradientFillSettings)gradientStroke.FillSettings;
                AssertIsTrue(fillSettings.FillType == FillType.Gradient);
                AssertIsTrue(fillSettings.AlignWithLayer);
                AssertIsTrue(fillSettings.GradientType == GradientType.Linear);
                AssertIsTrue(Math.Abs(90 - fillSettings.Angle) < 0.001, "Angle is incorrect");
                AssertIsTrue(fillSettings.Dither == false);
                AssertIsTrue(Math.Abs(0 - fillSettings.HorizontalOffset) < 0.001, "Horizontal offset is incorrect");
                AssertIsTrue(Math.Abs(0 - fillSettings.VerticalOffset) < 0.001, "Vertical offset is incorrect");
                AssertIsTrue(fillSettings.Reverse == false);

                // Color Points
                var solidGradient = (SolidGradient)fillSettings.Gradient;
                var colorPoints = solidGradient.ColorPoints;
                
                AssertIsTrue(colorPoints.Length == 2);

                AssertIsTrue(colorPoints[0].Color == Color.Black);
                AssertIsTrue(colorPoints[0].Location == 0);
                AssertIsTrue(colorPoints[0].MedianPointLocation == 50);

                AssertIsTrue(colorPoints[1].Color == Color.White);
                AssertIsTrue(colorPoints[1].Location == 4096);
                AssertIsTrue(colorPoints[1].MedianPointLocation == 50);

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
                gradientStroke.Opacity = 127;
                gradientStroke.BlendMode = BlendMode.Color;

                fillSettings.AlignWithLayer = false;
                fillSettings.GradientType = GradientType.Radial;
                fillSettings.Angle = 45;
                fillSettings.Dither = true;
                fillSettings.HorizontalOffset = 15;
                fillSettings.VerticalOffset = 11;
                fillSettings.Reverse = true;

                // Add new color point
                var colorPoint = solidGradient.AddColorPoint();
                colorPoint.Color = Color.Green;
                colorPoint.Location = 4096;
                colorPoint.MedianPointLocation = 75;

                // Change location of previous point
                solidGradient.ColorPoints[1].Location = 1899;

                // Add new transparency point
                var transparencyPoint = solidGradient.AddTransparencyPoint();
                transparencyPoint.Opacity = 25;
                transparencyPoint.MedianPointLocation = 25;
                transparencyPoint.Location = 4096;

                // Change location of previous transparency point
                solidGradient.TransparencyPoints[1].Location = 2411;

                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(exportPath, loadOptions))
            {
                var gradientStroke = (StrokeEffect)im.Layers[2].BlendingOptions.Effects[0];

                if ((gradientStroke.BlendMode != BlendMode.Color) ||
                    (gradientStroke.Opacity != 127) ||
                    (gradientStroke.IsVisible != true))
                {
                    throw new Exception("Assertion of Gradient Stroke fails");
                }

                var fillSettings = (GradientFillSettings)gradientStroke.FillSettings;
                var solidGradient = (SolidGradient)fillSettings.Gradient;

                if (fillSettings.FillType != FillType.Gradient || solidGradient.ColorPoints.Length != 3)
                {
                    throw new Exception("Assertion fails");
                }

                // Check color points
                var point = solidGradient.ColorPoints[0];

                AssertIsTrue(point.MedianPointLocation == 50);
                AssertIsTrue(point.Color == Color.Black);
                AssertIsTrue(point.Location == 0);

                point = solidGradient.ColorPoints[1];
                AssertIsTrue(point.MedianPointLocation == 50);
                AssertIsTrue(point.Color == Color.White);
                AssertIsTrue(point.Location == 1899);

                point = solidGradient.ColorPoints[2];
                AssertIsTrue(point.MedianPointLocation == 75);
                AssertIsTrue(point.Color == Color.Green);
                AssertIsTrue(point.Location == 4096);

                // Check transparent points
                AssertIsTrue(solidGradient.TransparencyPoints.Length == 3);

                var transparencyPoint = solidGradient.TransparencyPoints[0];
                AssertIsTrue(transparencyPoint.MedianPointLocation == 50);
                AssertIsTrue(transparencyPoint.Opacity == 100);
                AssertIsTrue(transparencyPoint.Location == 0);

                transparencyPoint = solidGradient.TransparencyPoints[1];
                AssertIsTrue(transparencyPoint.MedianPointLocation == 50);
                AssertIsTrue(transparencyPoint.Opacity == 100);
                AssertIsTrue(transparencyPoint.Location == 2411);

                transparencyPoint = solidGradient.TransparencyPoints[2];
                AssertIsTrue(transparencyPoint.MedianPointLocation == 25);
                AssertIsTrue(transparencyPoint.Opacity == 25);
                AssertIsTrue(transparencyPoint.Location == 4096);
            }
            //ExEnd:AddStrokeLayer_Gradient
        }
    }
}
