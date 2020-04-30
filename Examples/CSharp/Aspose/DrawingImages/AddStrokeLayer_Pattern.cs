using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddStrokeLayer_Pattern
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddStrokeLayer_Pattern

            // Stroke effect. FillType - Pattern. Example
            string sourceFileName = dataDir + "Stroke.psd";
            string exportPath = dataDir + "StrokePatternChanged.psd";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            // Preparing new data
            var newPattern = new int[]
            {
              Color.Aqua.ToArgb(), Color.Red.ToArgb(), Color.Red.ToArgb(), Color.Aqua.ToArgb(),
              Color.Aqua.ToArgb(), Color.White.ToArgb(), Color.White.ToArgb(), Color.Aqua.ToArgb(),
              Color.Aqua.ToArgb(), Color.White.ToArgb(), Color.White.ToArgb(), Color.Aqua.ToArgb(),
              Color.Aqua.ToArgb(), Color.Red.ToArgb(), Color.Red.ToArgb(), Color.Aqua.ToArgb(),
            };

            var newPatternBounds = new Rectangle(0, 0, 4, 4);
            var guid = Guid.NewGuid();

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var patternStroke = (StrokeEffect)im.Layers[3].BlendingOptions.Effects[0];
                var fillSettings = (PatternFillSettings)patternStroke.FillSettings;

                if ((patternStroke.BlendMode != BlendMode.Normal) ||
                    (patternStroke.Opacity != 255) ||
                    (patternStroke.IsVisible != true) ||
                    (fillSettings.FillType != FillType.Pattern))
                {
                    throw new Exception("Pattern effect properties were read wrong");
                }

                patternStroke.Opacity = 127;
                patternStroke.BlendMode = BlendMode.Color;

                PattResource resource;
                foreach (var globalLayerResource in im.GlobalLayerResources)
                {
                    if (globalLayerResource is PattResource)
                    {
                        resource = (PattResource)globalLayerResource;
                        resource.PatternId = guid.ToString();
                        resource.Name = "$$$/Presets/Patterns/HorizontalLine1=Horizontal Line 9\0";

                        resource.SetPattern(newPattern, newPatternBounds);
                    }
                }

                 ((PatternFillSettings)patternStroke.FillSettings).PatternName = "$$$/Presets/Patterns/HorizontalLine1=Horizontal Line 9\0";

                ((PatternFillSettings)patternStroke.FillSettings).PatternId = guid.ToString() + "\0";
                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var patternStroke = (StrokeEffect)im.Layers[3].BlendingOptions.Effects[0];

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

                try
                {
                    // Check the pattern data
                    var fillSettings = (PatternFillSettings)patternStroke.FillSettings;

                    if ((resource.PatternData != newPattern) ||
                        (newPatternBounds != new Rectangle(0, 0, resource.Width, resource.Height)) ||
                        (resource.PatternId != guid.ToString()) ||
                        (patternStroke.BlendMode != BlendMode.Color) ||
                        (patternStroke.Opacity != 127) ||
                        (patternStroke.IsVisible != true) ||
                        (fillSettings.FillType != FillType.Pattern))
                    {
                        throw new Exception("Pattern stroke effect properties were read wrong");
                    }
                }
                catch (Exception e)
                {
                    string ex = e.StackTrace;

                }
            }

            //ExEnd:AddStrokeLayer_Pattern
        }
    }
}
