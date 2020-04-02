using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ColorOverLayEffect
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ColorOverLayEffect

            // ColorOverlay effect editing
            string sourceFileName = dataDir + "ColorOverlay.psd";
            string psdPathAfterChange = dataDir + "ColorOverlayChanged.psd";

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {

                var colorOverlay = (ColorOverlayEffect)(im.Layers[1].BlendingOptions.Effects[0]);

                if (colorOverlay.Color != Color.Red ||
                    colorOverlay.Opacity != 153)
                {
                    throw new Exception("Color overlay read wrong");
                }

                colorOverlay.Color = Color.Green;
                colorOverlay.Opacity = 128;

                im.Save(psdPathAfterChange);
            }
            //ExEnd:ColorOverLayEffect
        }
    }
}