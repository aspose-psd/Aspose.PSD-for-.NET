using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class DetectFlattenedPSD
    {
        public static void Run()
        {
            //ExStart:DetectFlattenedPSD
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            {
                // Do processing, Get the true value if PSD is flatten and false in case the PSD is not flatten.
                Console.WriteLine(psdImage.IsFlatten);
            }

            //ExEnd:DetectFlattenedPSD
        }
    }
}
