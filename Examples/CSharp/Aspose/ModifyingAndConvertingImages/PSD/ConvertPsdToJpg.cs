using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ConvertPsdToJpg
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ConvertPsdToJpg

            string inputFile = dataDir + "PsdConvertToExample.psd";

            using (var psdImage = (PsdImage)Image.Load(inputFile))
            {
                psdImage.Save(dataDir + "PsdConvertedToJpg.jpg", new JpegOptions() {Quality = 80, JpegLsAllowedLossyError = 10 });
            }

            //ExEnd:ConvertPsdToJpg
        }
    }
}