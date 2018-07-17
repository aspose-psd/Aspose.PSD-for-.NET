using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageFilters.FilterOptions;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ForceFontCache
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ForceFontCache
            // The path to the documents directory.
            using (PsdImage image = (PsdImage)Image.Load(dataDir+"sample.psd"))
            {
                image.Save("NoFont.psd");
            }

            Console.WriteLine("You have 2 minutes to install the font");
            Thread.Sleep(TimeSpan.FromMinutes(2));
            OpenTypeFontsCache.UpdateCache();

            using (PsdImage image = (PsdImage)Image.Load(dataDir+ @"sample.psd"))
            {
                image.Save(dataDir+"HasFont.psd");
            }
            //ExEnd:ForceFontCache

        }

    }
}
