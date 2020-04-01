using Aspose.PSD.FileFormats.Jpeg;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class SupportForJPEG_LSWithCMYK
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportForJPEG_LSWithCMYK

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "PsdImage.psd"))
            {
                JpegOptions options = new JpegOptions();
                //Just replace one line given below in examples to use YCCK instead of CMYK
                //options.ColorType = JpegCompressionColorMode.Cmyk;
                options.ColorType = JpegCompressionColorMode.Cmyk;
                options.CompressionType = JpegCompressionMode.JpegLs;

                // The default profiles will be used.
                options.RgbColorProfile = null;
                options.CmykColorProfile = null;

                image.Save(dataDir + "output.jpg", options);
            }

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "PsdImage.psd"))
            {
                JpegOptions options = new JpegOptions();
                //Just replace one line given below in examples to use YCCK instead of CMYK
                //options.ColorType = JpegCompressionColorMode.Cmyk;
                options.ColorType = JpegCompressionColorMode.Cmyk;
                options.CompressionType = JpegCompressionMode.Lossless;

                // The default profiles will be used.
                options.RgbColorProfile = null;
                options.CmykColorProfile = null;

                image.Save(dataDir + "output2.jpg", options);
            }


            //ExEnd:SupportForJPEG_LSWithCMYK

        }
    }
}
