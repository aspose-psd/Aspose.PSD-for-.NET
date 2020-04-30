using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG
{
    class SpecifyTransparencyOfPngOnExport
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SpecifyTransparency

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {

                // specify the PNG image transparency options and save to file.
                psdImage.TransparentColor = Color.White;
                psdImage.HasTransparentColor = true;
                PngOptions opt = new PngOptions();
                psdImage.Save(dataDir + "Specify_Transparency_result.png", new PngOptions());

            }

            //ExEnd:SpecifyTransparency
        }
    }
}
