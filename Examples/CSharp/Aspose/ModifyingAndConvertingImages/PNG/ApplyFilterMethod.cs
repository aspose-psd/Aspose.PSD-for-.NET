using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG
{
    class ApplyFilterMethod
    {
        public static void Run()
        {
            //ExStart:ApplyFilterMethod
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                // Create an instance of PngOptions, Set the PNG filter method and Save changes to the disc
                PngOptions options = new PngOptions();
                options.FilterType = PngFilterType.Paeth;
                psdImage.Save(dataDir+"ApplyFilterMethod_out.png", options);
            }

            //ExEnd:ApplyFilterMethod
        }
    }
}
