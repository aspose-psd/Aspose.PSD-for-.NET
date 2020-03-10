using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class SimpleResizing
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SimpleResizing

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"SimpleResizing_out.jpg";

            // Load an existing image into an instance of RasterImage class
            using (Image image = Image.Load(sourceFile))
            {
                image.Resize(300, 300);
                image.Save(destName, new JpegOptions());
            }

            //ExEnd:SimpleResizing

        }

    }
}
