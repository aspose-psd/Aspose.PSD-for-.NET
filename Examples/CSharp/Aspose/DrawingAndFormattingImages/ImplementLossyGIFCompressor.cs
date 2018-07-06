using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ImplementLossyGIFCompressor
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ImplementLossyGIFCompressor

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"anim_lossy-200.gif";

            GifOptions gifExport = new GifOptions();

            // Load an existing image into an instance of RasterImage class
            using (var image = Image.Load(sourceFile))
            {
                gifExport.MaxDiff = 80;
                image.Save("anim_lossy-80.gif", gifExport);
                gifExport.MaxDiff = 200;
                image.Save(destName, gifExport);
            }

            //ExEnd:ImplementLossyGIFCompressor

        }

    }
}
