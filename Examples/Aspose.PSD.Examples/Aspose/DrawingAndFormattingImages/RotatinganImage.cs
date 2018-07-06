using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class RotatinganImage
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:RotatinganImage

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"RotatingAnImage_out.jpg";

            // Load an existing image into an instance of RasterImage class
            using (Image image = Image.Load(sourceFile))
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                image.Save(destName, new JpegOptions());
            }

            //ExEnd:RotatinganImage

            }

        }
}
