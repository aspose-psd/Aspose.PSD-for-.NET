using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class SupportShadowEffect
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportShadowEffect
            string sourceFileName = dataDir + "Shadow.psd";
            string psdPathAfterChange = dataDir + "ShadowChanged.psd";
            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true
            };

            using (var im = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                var shadowEffect = (DropShadowEffect)(im.Layers[1].BlendingOptions.Effects[0]);

                if ((shadowEffect.Color != Color.Black) ||
                    (shadowEffect.Opacity != 255) ||
                    (shadowEffect.Distance != 3) ||
                    (shadowEffect.Size != 7) ||
                    (shadowEffect.UseGlobalLight != true) ||
                    (shadowEffect.Angle != 90) ||
                    (shadowEffect.Spread != 0) ||
                    (shadowEffect.Noise != 0))
                {
                    throw new Exception("Shadow Effect was read wrong");
                }

                shadowEffect.Color = Color.Green;
                shadowEffect.Opacity = 128;
                shadowEffect.Distance = 11;
                shadowEffect.UseGlobalLight = false;
                shadowEffect.Size = 9;
                shadowEffect.Angle = 45;
                shadowEffect.Spread = 3;
                shadowEffect.Noise = 50;

                im.Save(psdPathAfterChange);
            }
        }
        //ExEnd:SupportShadowEffect
    }
}