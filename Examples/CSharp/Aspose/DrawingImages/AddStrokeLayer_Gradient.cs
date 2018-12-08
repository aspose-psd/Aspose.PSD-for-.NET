using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.Lfx2Resources;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string sourceFileName = dataDir+ "Stroke.psd";
            string exportPath = dataDir+"StrokeGradientChanged.psd";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var gradientStroke = (StrokeEffect)im.Layers[2].BlendingOptions.Effects[0];

                Assert.AreEqual(BlendMode.Normal, gradientStroke.BlendMode);
                Assert.AreEqual(255, gradientStroke.Opacity);
                Assert.AreEqual(true, gradientStroke.IsVisible);

                var fillSettings = (GradientFillSettings)gradientStroke.FillSettings;
                Assert.AreEqual(Color.Black, fillSettings.Color);
                Assert.AreEqual(FillType.Gradient, fillSettings.FillType);
                Assert.AreEqual(true, fillSettings.AlignWithLayer);
                Assert.AreEqual(GradientType.Linear, fillSettings.GradientType);
                Assert.IsTrue(Math.Abs(90 - fillSettings.Angle) < 0.001, "Angle is incorrect");
                Assert.AreEqual(false, fillSettings.Dither);
                Assert.IsTrue(Math.Abs(0 - fillSettings.HorizontalOffset) < 0.001, "Horizontal offset is incorrect");
                Assert.IsTrue(Math.Abs(0 - fillSettings.VerticalOffset) < 0.001, "Vertical offset is incorrect");
                Assert.AreEqual(false, fillSettings.Reverse);

                // Color Points
                var colorPoints = fillSettings.ColorPoints;
                Assert.AreEqual(2, colorPoints.Length);

                Assert.AreEqual(Color.Black, colorPoints[0].Color);
                Assert.AreEqual(0, colorPoints[0].Location);
                Assert.AreEqual(50, colorPoints[0].MedianPointLocation);

                Assert.AreEqual(Color.White, colorPoints[1].Color);
                Assert.AreEqual(4096, colorPoints[1].Location);
                Assert.AreEqual(50, colorPoints[1].MedianPointLocation);

                // Transparency points
                var transparencyPoints = fillSettings.TransparencyPoints;
                Assert.AreEqual(2, transparencyPoints.Length);

                Assert.AreEqual(0, transparencyPoints[0].Location);
                Assert.AreEqual(50, transparencyPoints[0].MedianPointLocation);
                Assert.AreEqual(100, transparencyPoints[0].Opacity);

                Assert.AreEqual(4096, transparencyPoints[1].Location);
                Assert.AreEqual(50, transparencyPoints[1].MedianPointLocation);
                Assert.AreEqual(100, transparencyPoints[1].Opacity);

                // Test editing
                fillSettings.Color = Color.Green;

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
                var colorPoint = fillSettings.AddColorPoint();
                colorPoint.Color = Color.Green;
                colorPoint.Location = 4096;
                colorPoint.MedianPointLocation = 75;

                // Change location of previous point
                fillSettings.ColorPoints[1].Location = 1899;

                // Add new transparency point
                var transparencyPoint = fillSettings.AddTransparencyPoint();
                transparencyPoint.Opacity = 25;
                transparencyPoint.MedianPointLocation = 25;
                transparencyPoint.Location = 4096;

                // Change location of previous transparency point
                fillSettings.TransparencyPoints[1].Location = 2411;

                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(exportPath, loadOptions))
            {
                var gradientStroke = (StrokeEffect)im.Layers[2].BlendingOptions.Effects[0];

                Assert.AreEqual(BlendMode.Color, gradientStroke.BlendMode);
                Assert.AreEqual(127, gradientStroke.Opacity);
                Assert.AreEqual(true, gradientStroke.IsVisible);

                var fillSettings = (GradientFillSettings)gradientStroke.FillSettings;
                Assert.AreEqual(Color.Green, fillSettings.Color);
                Assert.AreEqual(FillType.Gradient, fillSettings.FillType);

                // Check color points
                Assert.AreEqual(3, fillSettings.ColorPoints.Length);

                var point = fillSettings.ColorPoints[0];
                Assert.AreEqual(50, point.MedianPointLocation);
                Assert.AreEqual(Color.Black, point.Color);
                Assert.AreEqual(0, point.Location);

                point = fillSettings.ColorPoints[1];
                Assert.AreEqual(50, point.MedianPointLocation);
                Assert.AreEqual(Color.White, point.Color);
                Assert.AreEqual(1899, point.Location);

                point = fillSettings.ColorPoints[2];
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
                Assert.AreEqual(2411, transparencyPoint.Location);

                transparencyPoint = fillSettings.TransparencyPoints[2];
                Assert.AreEqual(25, transparencyPoint.MedianPointLocation);
                Assert.AreEqual(25, transparencyPoint.Opacity);
                Assert.AreEqual(4096, transparencyPoint.Location);
            }
            //ExEnd:AddStrokeLayer_Gradient
        }
    }
}
