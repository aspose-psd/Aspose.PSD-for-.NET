using Aspose.PSD.FileFormats.Psd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class InvertAdjustmentLayer
    {
        public static void Run()
        {

            //ExStart:InvertAdjustmentLayer
            // Add color overlay layer effect at runtime
            string dataDir = RunExamples.GetDataDir_PSD();


            var filePath = dataDir + "InvertStripes_before.psd";
            var outputPath = dataDir +  "InvertStripes_after.psd";
            using (var im = (PsdImage)Image.Load(filePath))
            {
                im.AddInvertAdjustmentLayer();
                im.Save(outputPath);
            }
            //ExEnd:InvertAdjustmentLayer


        }
    }
}
