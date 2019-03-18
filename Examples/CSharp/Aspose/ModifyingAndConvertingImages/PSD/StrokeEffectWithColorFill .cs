using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class StrokeEffectWithColorFill
    {
        public static void Run() {

            //ExStart:StrokeEffectWithColorFill

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Implement rendering of Stroke effect with Color Fill for export
            string sourceFileName = dataDir + "StrokeComplex.psd";
            string exportPath = dataDir + "StrokeComplexRendering.psd";
            string exportPathPng = dataDir+"StrokeComplexRendering.png";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                for (int i = 0; i < im.Layers.Length; i++)
                {
                    var effect = (StrokeEffect)im.Layers[i].BlendingOptions.Effects[0];
                    var settings = (ColorFillSettings)effect.FillSettings;
                    settings.Color = Color.DeepPink;
                }

                // Save psd
                im.Save(exportPath, new PsdOptions());

                // Save png
                im.Save(exportPathPng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            //ExEnd:StrokeEffectWithColorFill
        }
    }
}
