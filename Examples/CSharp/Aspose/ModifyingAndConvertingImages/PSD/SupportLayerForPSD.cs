using Aspose.PSD.FileFormats.Psd;
using System.Diagnostics;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportLayerForPSD
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportLayerForPSD

            string sourceFileName = dataDir + "layers.psd";
            string output = dataDir + "layers.png";

            using (PsdImage image = (PsdImage)Image.Load(sourceFileName,
                new ImageLoadOptions.PsdLoadOptions()
                {
                    LoadEffectsResource = true,
                    UseDiskForLoadEffectsResource = true
                }))
            {
                Debug.Assert(image.Layers[2] != null, "Layer with effects resource was not recognized");

                image.Save(output, new ImageOptions.PngOptions()
                {
                    ColorType =
                        FileFormats.Png
                            .PngColorType
                            .TruecolorWithAlpha
                });
            }

            //ExEnd:SupportLayerForPSD
        }
    }
}