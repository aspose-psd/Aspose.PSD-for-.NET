using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddStrokeLayer_Color
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddStrokeLayer_Color

            // Stroke effect. FillType - Color. Example
            string sourceFileName = dataDir + "Stroke.psd";
            string exportPath = dataDir + "StrokeGradientChanged.psd";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var colorStroke = (StrokeEffect)im.Layers[1].BlendingOptions.Effects[0];

                if ((colorStroke.BlendMode != BlendMode.Normal) ||
                    (colorStroke.Opacity != 255) ||
                    (colorStroke.IsVisible != true))
                {
                    throw new Exception("Color stroke effect was read wrong");
                }

                var fillSettings = (ColorFillSettings)colorStroke.FillSettings;
                if ((fillSettings.Color != Color.Black) || (fillSettings.FillType != FillType.Color))
                {
                    throw new Exception("Color stroke effect settings were read wrong");
                }

                fillSettings.Color = Color.Yellow;

                colorStroke.Opacity = 127;
                colorStroke.BlendMode = BlendMode.Color;
                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(exportPath, loadOptions))
            {
                var colorStroke = (StrokeEffect)im.Layers[1].BlendingOptions.Effects[0];

                if ((colorStroke.BlendMode != BlendMode.Color) ||
                    (colorStroke.Opacity != 127) ||
                    (colorStroke.IsVisible != true))
                {
                    throw new Exception("Color stroke effect was read wrong");
                }

                var fillSettings = (ColorFillSettings)colorStroke.FillSettings;
                if ((fillSettings.Color != Color.Yellow) || (fillSettings.FillType != FillType.Color))
                {
                    throw new Exception("Color stroke effect settings were read wrong");
                }
            }
            //ExEnd:AddStrokeLayer_Color
        }
    }
}
