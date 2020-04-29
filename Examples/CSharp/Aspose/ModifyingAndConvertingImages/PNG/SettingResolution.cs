using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG
{
    class SettingResolutionOfPngOnExport
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SettingResolution

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                // Create an instance of PngOptions, Set the horizontal & vertical resolutions and Save the result on disc
                PngOptions options = new PngOptions();
                options.ResolutionSettings = new ResolutionSetting(72, 96);
                psdImage.Save(dataDir + "SettingResolution_output.png", options);
            }
            //ExEnd:SettingResolution
        }

    }
}
