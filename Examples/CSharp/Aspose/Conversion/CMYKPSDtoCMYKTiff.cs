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

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"output.tiff";

            using (Image image = Image.Load(sourceFile))
            {
                image.Save(destName, new TiffOptions(TiffExpectedFormat.TiffLzwCmyk));
            }

            //ExEnd:CMYKPSDtoCMYKTiff

        }
    }
}
