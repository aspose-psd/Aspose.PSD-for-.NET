using Aspose.PSD.FileFormats.Psd;
using System;
using System.Threading;

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
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                image.Save("NoFont.psd");
            }

            Console.WriteLine("You have 2 minutes to install the font");
            Thread.Sleep(TimeSpan.FromMinutes(2));
            OpenTypeFontsCache.UpdateCache();

            using (PsdImage image = (PsdImage)Image.Load(dataDir + @"sample.psd"))
            {
                image.Save(dataDir + "HasFont.psd");
            }
            //ExEnd:ForceFontCache

        }

    }
}
