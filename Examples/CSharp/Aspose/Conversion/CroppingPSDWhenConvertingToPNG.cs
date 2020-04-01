using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class CroppingPSDWhenConvertingToPNG
    {

        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:CroppingPSDWhenConvertingToPNG

            string srcPath = dataDir + @"sample.psd";
            string destName = dataDir + @"export.png";

            // Load an existing PSD image
            using (RasterImage image = (RasterImage)Image.Load(srcPath))
            {
                // Create an instance of Rectangle class by passing x,y and width,height 
                // Call the crop method of Image class and pass the rectangle class instance
                image.Crop(new Rectangle(0, 0, 350, 450));

                // Create an instance of PngOptions class
                PngOptions pngOptions = new PngOptions();

                // Call the save method, provide output path and PngOptions to convert the PSD file to PNG and save the output
                image.Save(destName, pngOptions);
            }

            //ExEnd:CroppingPSDWhenConvertingToPNG
        }
    }
}
