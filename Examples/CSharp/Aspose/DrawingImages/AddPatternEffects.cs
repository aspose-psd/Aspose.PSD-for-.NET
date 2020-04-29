using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
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

                if ((patternOverlay.BlendMode != BlendMode.Normal) ||
                    (patternOverlay.Opacity != 127) ||
                    (patternOverlay.IsVisible != true)
                    )
                {
                    throw new Exception("Pattern overlay effect properties were read wrong");
                }

                var settings = patternOverlay.Settings;

                if ((settings.Color != Color.Empty) ||
                    (settings.FillType != FillType.Pattern) ||
                    (settings.PatternId != "85163837-eb9e-5b43-86fb-e6d5963ea29a\0") ||
                    (settings.PatternName != "$$$/Presets/Patterns/OpticalSquares=Optical Squares\0") ||
                    (settings.PointType != null) ||
                    (Math.Abs(settings.Scale - 100) > 0.001) ||
                    (settings.Linked != true) ||
                    (Math.Abs(0 - settings.HorizontalOffset) > 0.001) ||
                    (Math.Abs(0 - settings.VerticalOffset) > 0.001))
                {
                    throw new Exception("Pattern overlay effect settings were read wrong");
                }

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

                    if ((patternOverlay.BlendMode != BlendMode.Difference) ||
                        (patternOverlay.Opacity != 193) ||
                        (patternOverlay.IsVisible != true))
                    {
                        throw new Exception("Pattern overlay effect properties were read wrong");
                    }

                    var fillSettings = patternOverlay.Settings;


                    if ((fillSettings.Color != Color.Empty) ||
                        (fillSettings.FillType != FillType.Pattern))
                    {
                        throw new Exception("Pattern overlay effect settings were read wrong");
                    }

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
                    if ((resource.PatternData != newPattern) ||
                        (newPatternBounds != new Rectangle(0, 0, resource.Width, resource.Height)) ||
                        (resource.PatternId != guid.ToString()) ||
                        (resource.Name != newPatternName)
                        )
                    {
                        throw new Exception("Pattern was set wrong");
                    }
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
