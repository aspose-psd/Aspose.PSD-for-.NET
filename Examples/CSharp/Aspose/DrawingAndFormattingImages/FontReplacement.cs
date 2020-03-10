using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class FontReplacement
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:FontReplacement

            // Load an image in an instance of image and setting default replacement font.
            PsdLoadOptions psdLoadOptions = new PsdLoadOptions() { DefaultReplacementFont = "Arial" };

            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "Cloud_AzPlat_Banner3A_SB_EN_US_160x600_chinese_font.psd", psdLoadOptions))
            {
                var pngOptions = new PngOptions();
                psdImage.Save(dataDir + "replaced_font.png", new ImageOptions.PngOptions());
            }

            //ExEnd:FontReplacement
        }
    }
}
