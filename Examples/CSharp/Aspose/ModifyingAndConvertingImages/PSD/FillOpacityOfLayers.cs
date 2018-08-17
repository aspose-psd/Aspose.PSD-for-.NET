using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class FillOpacityOfLayers
    {
        public static void Run()
        {
            //ExStart:FillOpacityOfLayers
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();
            
            // Change the Fill Opacity property
            string sourceFileName = dataDir+"FillOpacitySample.psd";
            string exportPath = dataDir+"FillOpacitySampleChanged.psd";

            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                var layer = im.Layers[2];
                layer.FillOpacity = 5;
                im.Save(exportPath);
            }

            //ExEnd:FillOpacityOfLayers

        }

    }
}
