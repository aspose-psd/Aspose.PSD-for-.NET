using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class RenderingOfRotatedTextLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:RenderingOfRotatedTextLayer
            string sourceFileName = dataDir + "TransformedText.psd";
            string exportPath = dataDir + "TransformedTextExport.psd";
            string exportPathPng = dataDir + "TransformedTextExport.png";
            var im = (PsdImage)Image.Load(sourceFileName);
            using (im)
            {
                im.Save(exportPath);
                im.Save(exportPathPng, new PngOptions()
                {
                    ColorType = PngColorType.Grayscale
                });
            }

            //ExEnd:RenderingOfRotatedTextLayer

        }
    }
}