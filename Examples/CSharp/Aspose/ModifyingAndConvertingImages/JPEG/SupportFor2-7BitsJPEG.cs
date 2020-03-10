using Aspose.PSD.FileFormats.Jpeg;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class SupportFor2_7BitsJPEG
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportFor2_7BitsJPEG

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "PsdImage.psd"))
            {
                JpegOptions options = new JpegOptions();

                // Set 2 bits per sample to see the difference in size and quality
                byte bpp = 2;

                //Just replace one line given below in examples to use YCCK instead of CMYK
                //options.ColorType = JpegCompressionColorMode.Cmyk;
                options.ColorType = JpegCompressionColorMode.Cmyk;
                options.CompressionType = JpegCompressionMode.JpegLs;
                options.BitsPerChannel = bpp;

                // The default profiles will be used.
                options.RgbColorProfile = null;
                options.CmykColorProfile = null;

                image.Save(dataDir + "2_7BitsJPEG_output.jpg", options);
            }


            //ExEnd:SupportFor2_7BitsJPEG

        }
    }
}
