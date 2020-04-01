using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddPatternEffects
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddPatternEffects

            // Pattern overlay effect. Example
            string sourceFileName = dataDir + "PatternOverlay.psd";
            string exportPath = dataDir + "PatternOverlayChanged.psd";

            var newPattern = new int[]
            {
                 Color.Aqua.ToArgb(), Color.Red.ToArgb(), Color.Red.ToArgb(), Color.Aqua.ToArgb(),
                 Color.Aqua.ToArgb(), Color.White.ToArgb(), Color.White.ToArgb(), Color.Aqua.ToArgb(),

            };

            var newPatternBounds = new Rectangle(0, 0, 4, 2);
            var guid = Guid.NewGuid();
            var newPatternName = "$$$/Presets/Patterns/Pattern=Some new pattern name\0";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var patternOverlay = (PatternOverlayEffect)im.Layers[1].BlendingOptions.Effects[0];

                Assert.AreEqual(BlendMode.Normal, patternOverlay.BlendMode);
                Assert.AreEqual(127, patternOverlay.Opacity);
                Assert.AreEqual(true, patternOverlay.IsVisible);

                var settings = patternOverlay.Settings;
                Assert.AreEqual(Color.Empty, settings.Color);
                Assert.AreEqual(FillType.Pattern, settings.FillType);
                Assert.AreEqual("85163837-eb9e-5b43-86fb-e6d5963ea29a\0", settings.PatternId);
                Assert.AreEqual("$$$/Presets/Patterns/OpticalSquares=Optical Squares\0", settings.PatternName);
                Assert.AreEqual(null, settings.PointType);
                Assert.AreEqual(100, settings.Scale);

                Assert.AreEqual(false, settings.Linked);
                Assert.IsTrue(Math.Abs(0 - settings.HorizontalOffset) < 0.001, "Horizontal offset is incorrect");
                Assert.IsTrue(Math.Abs(0 - settings.VerticalOffset) < 0.001, "Vertical offset is incorrect");

                // Test editing
                settings.Color = Color.Green;

                patternOverlay.Opacity = 193;
                patternOverlay.BlendMode = BlendMode.Difference;
                settings.HorizontalOffset = 15;
                settings.VerticalOffset = 11;

                PattResource resource;
                foreach (var globalLayerResource in im.GlobalLayerResources)
                {
                    if (globalLayerResource is PattResource)
                    {
                        resource = (PattResource)globalLayerResource;
                        resource.PatternId = guid.ToString();
                        resource.Name = newPatternName;
                        resource.SetPattern(newPattern, newPatternBounds);
                    }
                }

                settings.PatternName = newPatternName;

                settings.PatternId = guid.ToString() + "\0";
                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var patternOverlay = (PatternOverlayEffect)im.Layers[1].BlendingOptions.Effects[0];
                try
                {
                    Assert.AreEqual(BlendMode.Difference, patternOverlay.BlendMode);
                    Assert.AreEqual(193, patternOverlay.Opacity);
                    Assert.AreEqual(true, patternOverlay.IsVisible);

                    var fillSettings = patternOverlay.Settings;
                    Assert.AreEqual(Color.Empty, fillSettings.Color);
                    Assert.AreEqual(FillType.Pattern, fillSettings.FillType);

                    PattResource resource = null;
                    foreach (var globalLayerResource in im.GlobalLayerResources)
                    {
                        if (globalLayerResource is PattResource)
                        {
                            resource = (PattResource)globalLayerResource;
                        }
                    }

                    if (resource == null)
                    {
                        throw new Exception("PattResource not found");
                    }

                    // Check the pattern data
                    Assert.AreEqual(newPattern, resource.PatternData);
                    Assert.AreEqual(newPatternBounds, new Rectangle(0, 0, resource.Width, resource.Height));
                    Assert.AreEqual(guid.ToString(), resource.PatternId);
                    Assert.AreEqual(newPatternName, resource.Name);
                }
                catch (Exception e)
                {
                    string ex = e.StackTrace;
                }
            }
            //ExEnd:AddPatternEffects
        }
    }
}
