using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ResizePSDFile
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ResizePSDFile

            // Implement correct Resize method for PSD files.
            string sourceFileName = dataDir + "1.psd";
            string exportPathPsd = dataDir + "ResizeTest.psd";
            string exportPathPng = dataDir + "ResizeTest.png";
            using (RasterImage image = Image.Load(sourceFileName) as RasterImage)
            {
                image.Resize(160, 120);
                image.Save(exportPathPsd, new PsdOptions());
                image.Save(exportPathPng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            //ExEnd:ResizePSDFile
        }
    }
}
