using Aspose.PSD.FileFormats.Psd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ExtractLayerName
    {

        public static void Run() {

            //ExStart:ExtractLayerName

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // make changes in layer names and save it
            using (var image = (PsdImage)Image.Load(dataDir + "Korean_layers.psd"))
            {
                for (int i = 0; i < image.Layers.Length; i++)
                {
                    var layer = image.Layers[i];
                    // set new value into DisplayName property
                    layer.DisplayName += "_changed";
                }

                image.Save(dataDir + "Korean_layers_output.psd");
            }

            //ExEnd:ExtractLayerName
        }
    }
}
