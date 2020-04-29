using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG
{
    class SpecifyBitDepthOnPng
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SpecifyBitDepth

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                // Create an instance of PngOptions, Set the desired ColorType, BitDepth according to the specified ColorType and save image
                PngOptions options = new PngOptions();
                options.ColorType = PngColorType.Grayscale;
                options.BitDepth = 1;
                psdImage.Save(dataDir + "SpecifyBitDepth_out.png", options);
            }


            //ExEnd:SpecifyBitDepth
        }
    }
}
