using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPSB
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:PSDToPSB

            string sourceFilePathPsd = dataDir + "2layers.psd";
            string outputFilePathPsb = dataDir + "ConvertFromPsd.psb";
            using (Image img = Image.Load(sourceFilePathPsd))
            {
                var options = new PsdOptions((PsdImage)img) { PsdVersion = PsdVersion.Psb };
                img.Save(outputFilePathPsb, options);
            }
            //ExEnd:PSDToPSB
        }
    }
}
