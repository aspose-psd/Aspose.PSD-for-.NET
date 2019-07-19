using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PSDToPSB
    {
        public static void Run() {

            //ExStart:PSDToPSB
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFilePathPsd = dataDir + "2layers.psd";
            string outputFilePathPsb = dataDir + "ConvertFromPsd.psb";
            using (Image img = Image.Load(sourceFilePathPsd))
            {
                var options = new PsdOptions((PsdImage)img) { FileFormatVersion = FileFormatVersion.Psb };
                img.Save(outputFilePathPsb, options);
            }
            //ExEnd:PSDToPSB
        }
    }
}
