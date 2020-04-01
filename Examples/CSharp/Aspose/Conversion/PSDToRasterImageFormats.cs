using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class PSDToRasterImageFormats
    {

        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:PSDToRasterImageFormats

            string srcPath = dataDir + @"sample.psd";
            string destName = dataDir + @"export";

            // Load an existing PSD image as Image
            using (Image image = Image.Load(srcPath))
            {
                // Create an instance of PngOptions class
                PngOptions pngOptions = new PngOptions();

                // Create an instance of BmpOptions class
                BmpOptions bmpOptions = new BmpOptions();

                // Create an instance of TiffOptions class
                TiffOptions tiffOptions = new TiffOptions(FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

                // Create an instance of GifOptions class
                GifOptions gifOptions = new GifOptions();

                // Create an instance of JpegOptions class
                JpegOptions jpegOptions = new JpegOptions();

                // Create an instance of Jpeg2000Options class
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options();

                // Call the save method, provide output path and export options to convert PSD file to various raster file formats.
                image.Save(destName + ".png", pngOptions);
                image.Save(destName + ".bmp", bmpOptions);
                image.Save(destName + ".tiff", tiffOptions);
                image.Save(destName + ".gif", gifOptions);
                image.Save(destName + ".jpeg", jpegOptions);
                image.Save(destName + ".jp2", jpeg2000Options);
            }

            //ExEnd:PSDToRasterImageFormats
        }
    }
}
