using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class LayerEffectsForPSD
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:LayerEffectsForPSD

            string sourceFileName = dataDir + "LayerWithText.psd";
            string exportPath = dataDir + "LayerEffectsForPSD.png";

            using (PsdImage image = (PsdImage)Image.Load(sourceFileName, new ImageLoadOptions.PsdLoadOptions()
            {
                LoadEffectsResource = true,
                UseDiskForLoadEffectsResource = true
            }))
            {
                image.Save(exportPath,
                    new ImageOptions.PngOptions()
                    {
                        ColorType =
                            FileFormats.Png
                                .PngColorType
                                .TruecolorWithAlpha
                    });
            }

            //ExEnd:LayerEffectsForPSD

        }
    }
}