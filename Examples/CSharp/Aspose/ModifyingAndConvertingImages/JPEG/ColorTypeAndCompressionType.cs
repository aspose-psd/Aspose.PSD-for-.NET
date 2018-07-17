using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Jpeg;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class ColorTypeAndCompressionType
    {
        public static void Run()
        {
            //ExStart:ColorTypeAndCompressionType
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "PsdImage.psd"))
            {
                JpegOptions options = new JpegOptions();
                options.ColorType = JpegCompressionColorMode.Grayscale;
                options.CompressionType = JpegCompressionMode.Progressive;

                image.Save(dataDir + "ColorTypeAndCompressionType_output.jpg", options);
            }

            //ExEnd:ColorTypeAndCompressionType

        }
    }
}
