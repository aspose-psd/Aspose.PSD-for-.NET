using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSB
{
    class PSBToPSD
    {
        public static void Run() {

            //ExStart:PSBToPSD
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSB();

            string sourceFilePathPsb = dataDir + "2layers.psb";
            string outputFilePathPsd = dataDir +  "ConvertFromPsb.psd";
            using (Image img = Image.Load(sourceFilePathPsb))
            {
                var options = new PsdOptions((PsdImage)img) { FileFormatVersion = FileFormatVersion.Psd };
                img.Save(outputFilePathPsd, options);
            }
            //ExEnd:PSBToPSD
        }
    }
}
