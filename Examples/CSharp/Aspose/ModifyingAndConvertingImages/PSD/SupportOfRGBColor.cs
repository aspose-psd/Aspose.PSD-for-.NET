using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfRGBColor
    {
        public static void Run() {

            //ExStart:SupportOfRGBColor
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Support of RGB Color mode with 16bits/channel (64 bits per color)
            string sourceFileName = dataDir + "inRgb16.psd";
            string outputFilePathJpg = dataDir+ "outRgb16.jpg";
            string outputFilePathPsd = dataDir + "outRgb16.psd";

            PsdLoadOptions options = new PsdLoadOptions();
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName, options))
            {
                image.Save(outputFilePathPsd, new PsdOptions(image));
                image.Save(outputFilePathJpg, new JpegOptions()
                {
                    Quality = 100
                });
            }
            // Files must be opened without exception and must be readable for Photoshop    
            using (Image image = Image.Load(outputFilePathPsd)) {
            }
            //ExEnd:SupportOfRGBColor
        }
    }
}
