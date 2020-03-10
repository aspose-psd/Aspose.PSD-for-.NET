using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class Bradleythreshold
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:Bradleythreshold

            string sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"binarized_out.png";

            // Load the noisy image 
            // Load an image
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                // Define threshold value, Call BinarizeBradley method and pass the threshold value as parameter and Save the output image
                double threshold = 0.15;
                image.BinarizeBradley(threshold);
                image.Save(destName, new PngOptions());
            }

            //ExEnd:Bradleythreshold

        }
    }
}
