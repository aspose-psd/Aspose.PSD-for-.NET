using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

                Assert.AreEqual(BlendMode.Normal, colorStroke.BlendMode);
                Assert.AreEqual(255, colorStroke.Opacity);
                Assert.AreEqual(true, colorStroke.IsVisible);

                var fillSettings = (ColorFillSettings)colorStroke.FillSettings;
                Assert.AreEqual(Color.Black, fillSettings.Color);
                Assert.AreEqual(FillType.Color, fillSettings.FillType);

                fillSettings.Color = Color.Yellow;

                colorStroke.Opacity = 127;
                colorStroke.BlendMode = BlendMode.Color;
                im.Save(exportPath);
            }

            // Test file after edit
            using (var im = (PsdImage)Image.Load(exportPath, loadOptions))
            {
                var colorStroke = (StrokeEffect)im.Layers[1].BlendingOptions.Effects[0];

                Assert.AreEqual(BlendMode.Color, colorStroke.BlendMode);
                Assert.AreEqual(127, colorStroke.Opacity);
                Assert.AreEqual(true, colorStroke.IsVisible);

                var fillSettings = (ColorFillSettings)colorStroke.FillSettings;
                Assert.AreEqual(Color.Yellow, fillSettings.Color);
                Assert.AreEqual(FillType.Color, fillSettings.FillType);
            }
            //ExEnd:AddStrokeLayer_Color
        }
    }
}
