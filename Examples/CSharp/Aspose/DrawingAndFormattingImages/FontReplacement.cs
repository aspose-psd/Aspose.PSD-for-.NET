using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageFilters.FilterOptions;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class FontReplacement
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:FontReplacement
            // The path to the documents directory.
            
            // Load an image in an instance of image and setting default replacement font.
            PsdLoadOptions psdLoadOptions = new PsdLoadOptions() { DefaultReplacementFont = "Arial" };

            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir +"Cloud_AzPlat_Banner3A_SB_EN_US_160x600_chinese_font.psd", psdLoadOptions))
            {
                var pngOptions = new PngOptions();
                psdImage.Save(dataDir + "replaced_font.png", new ImageOptions.PngOptions());
            }

            //ExEnd:FontReplacement

        }

    }
}
