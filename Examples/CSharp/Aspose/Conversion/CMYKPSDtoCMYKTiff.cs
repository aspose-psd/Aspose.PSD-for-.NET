using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class CMYKPSDtoCMYKTiff
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ModifyingAndConvertingImages();

            //ExStart:CMYKPSDtoCMYKTiff

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"output.tiff";

            using (Image image = Image.Load(sourceFile))
            {
                image.Save(destName, new TiffOptions(TiffExpectedFormat.TiffLzwCmyk));
            }

            //ExEnd:CMYKPSDtoCMYKTiff

        }
    }
}
