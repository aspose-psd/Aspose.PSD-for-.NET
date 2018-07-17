using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class MergePSDlayers
    {
        public static void Run()
        {
            //ExStart:MergePSDlayers
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            { 
                // Create JPEG option class object, Set its properties and save image
                var jpgOptions = new JpegOptions();
                psdImage.Save(dataDir + "MergePSDlayers_output.jpg", jpgOptions);
            }

            //ExEnd:MergePSDlayers

        }

    }
}
