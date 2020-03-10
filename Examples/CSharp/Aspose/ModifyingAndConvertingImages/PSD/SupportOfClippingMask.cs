using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfClippingMask
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfClippingMask

            // Exposure layer editing
            // Export of the psd with complex clipping mask
            string sourceFileName = dataDir + "ClippingMaskComplex.psd";
            string exportPath = dataDir + "ClippingMaskComplex.png";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                // Export to PNG
                var saveOptions = new PngOptions();
                saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
                im.Save(exportPath, saveOptions);
            }
            //ExEnd:SupportOfClippingMask

        }

    }
}
