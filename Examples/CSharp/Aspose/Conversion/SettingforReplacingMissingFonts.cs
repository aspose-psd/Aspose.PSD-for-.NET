using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class SettingforReplacingMissingFonts
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SettingforReplacingMissingFonts

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + "result.png";
          
            // load PSD image and replace the non found fonts.
            using (Image image = Image.Load(sourceFile, new PsdLoadOptions() { DefaultReplacementFont = "Arial" }))
            {
                PsdImage psdImage = (PsdImage)image;
                psdImage.Save(destName, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }


            //ExEnd:SettingforReplacingMissingFonts

        }
    }
}
