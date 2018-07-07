using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class LoadingFromStream
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:LoadingFromStream

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + "result.png";

            FileStream fStream = new FileStream(sourceFile, FileMode.Open);
            fStream.Position = 0;

            // load PSD image and replace the non found fonts.
            using (Image image = Image.Load(fStream))
            {
                PsdImage psdImage = (PsdImage)image;
                MemoryStream stream = new MemoryStream();
                psdImage.Save(stream, new PngOptions());
            }

            //ExEnd:LoadingFromStream

        }
    }
}
