using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.TIFF
{
    class CompressingTiff
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:CompressingTiff

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            {
                // Create an instance of TiffOptions for the resultant image
                TiffOptions outputSettings = new TiffOptions(TiffExpectedFormat.Default);

                // Set BitsPerSample, Compression, Photometric mode and graycale palette
                outputSettings.BitsPerSample = new ushort[] { 4 };
                outputSettings.Compression = TiffCompressions.Lzw;
                outputSettings.Photometric = TiffPhotometrics.Palette;
                outputSettings.Palette = ColorPaletteHelper.Create4BitGrayscale(true);

                psdImage.Save(dataDir + "SampleTiff_out.tiff", outputSettings);
            }


            //ExEnd:CompressingTiff
        }
    }
}
