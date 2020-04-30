using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class ExportImagesinMultiThreadEnv
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Output();

            //ExStart:ExportImagesinMultiThreadEnv

            string imageDataPath = dataDir + @"sample.psd";

            try
            {

                // Create the stream of the existing image file.   
                using (System.IO.FileStream fileStream = System.IO.File.Create(imageDataPath))
                {

                    // Create an instance of PSD image option class.
                    using (PsdOptions psdOptions = new PsdOptions())
                    {
                        // Set the source property of the imaging option class object.
                        psdOptions.Source = new Sources.StreamSource(fileStream);

                        // DO PROCESSING. 
                        // Following is the sample processing on the image. Un-comment to use it.
                        //using (RasterImage image = (RasterImage)Image.Create(psdOptions, 10, 10))
                        //{
                        //    Color[] pixels = new Color[4];
                        //    for (int i = 0; i < 4; ++i)
                        //    {
                        //        pixels[i] = Color.FromArgb(40, 30, 20, 10);
                        //    }
                        //    image.SavePixels(new Rectangle(0, 0, 2, 2), pixels);
                        //    image.Save();
                        //}
                    }
                }
            }
            finally
            {
                // Delete the file. This statement is in the final block because in any case this statement should execute to make it sure that resource is properly disposed off.
                System.IO.File.Delete(imageDataPath);
            }

            //ExEnd:ExportImagesinMultiThreadEnv

        }
    }
}
