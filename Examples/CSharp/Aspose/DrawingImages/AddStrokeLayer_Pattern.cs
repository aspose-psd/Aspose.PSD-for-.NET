using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
using System;
using Aspose.PSD.FileFormats.Core.Blending;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddStrokeLayer_Pattern
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:AddStrokeLayer_Pattern

            // Stroke effect. FillType - Pattern. Example
            string sourceFileName = Path.Combine(SourceDir, "Stroke.psd");
            string exportPath = Path.Combine(OutputDir, "StrokePatternChanged.psd");

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
                        var patternData = resource.Patterns[0];
                        patternData.PatternId = guid.ToString();
                        patternData.Name = "$$$/Presets/Patterns/HorizontalLine1=Horizontal Line 9";

                        patternData.SetPattern(newPattern, newPatternBounds);
                    }
                }

                var settings = (PatternFillSettings) patternStroke.FillSettings;
                settings.PatternName = "$$$/Presets/Patterns/HorizontalLine1=Horizontal Line 9";
                settings.PatternId = guid.ToString();

                settings.PatternData = newPattern;
                settings.PatternWidth = newPatternBounds.Width;
                settings.PatternHeight = newPatternBounds.Height;
                
                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(exportPath, loadOptions))
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
                    var patternData = resource.Patterns[0];

                    if ((newPatternBounds != new Rectangle(0, 0, patternData.Width, patternData.Height)) ||
                        (patternData.PatternId != guid.ToString()) ||
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

            File.Delete(exportPath);
        }
    }
}
