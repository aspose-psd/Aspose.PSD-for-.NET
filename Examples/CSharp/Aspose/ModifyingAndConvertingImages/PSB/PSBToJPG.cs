using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSB
{
    class PSBToJPG
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSB();

            //ExStart:PSBToJPG

            string[] sourceFileNames = new string[] { 
               //Test files with layers
               "Little",
               "Simple",
               //Test files without layers
               "psb",
               "psb3"
           };
            var options = new PsdLoadOptions();
            foreach (var fileName in sourceFileNames)
            {
                var sourceFileName = dataDir + fileName + ".psb";
                using (PsdImage image = (PsdImage)Image.Load(sourceFileName, options))
                {
                    // All jpeg and psd files must be readable
                    image.Save(dataDir + fileName + "_output.jpg", new JpegOptions() { Quality = 95 });
                    image.Save(dataDir + fileName + "_output.psb");
                }
            }
            //ExEnd:PSBToJPG
        }
    }
}
