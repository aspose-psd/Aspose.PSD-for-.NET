using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.ImageOptions;
namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    class SupportOfAiFormatVersion8
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfAiFormatVersion8
            //ExSummary:The following example demonstrates how you can export AI file of 8 version to PSD and PNG format in Aspose.PSD
            string sourceFileName = dataDir + "form_8.ai";
            string outputFileName = dataDir + "form_8_export";
            using (AiImage image = (AiImage)Image.Load(sourceFileName))
            {
                image.Save(outputFileName + ".psd", new PsdOptions());
                image.Save(outputFileName + ".png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            //ExEnd:SupportOfAiFormatVersion8
        }
    }
}