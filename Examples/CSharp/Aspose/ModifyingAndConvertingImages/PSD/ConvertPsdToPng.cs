using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ConvertPsdToPng
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ConvertPsdToPng

            string inputFile = dataDir + "PsdConvertToPngExample.psd";

            using (var psdImage = (PsdImage)Image.Load(inputFile, new PsdLoadOptions() { ReadOnlyMode = true }))
            {
                psdImage.Save(dataDir + "PsdConvertedToPng.png",
                    new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha, Progressive = true, CompressionLevel = 9 });
            }

            //ExEnd:ConvertPsdToPng
        }
    }
}