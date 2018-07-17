using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class UpdateTextLayerInPSDFile
    {
        public static void Run()
        {
            //ExStart:UpdateTextLayerInPSDFile
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            {
                foreach (var layer in psdImage.Layers)
                {
                    if (layer is TextLayer)
                    {
                        TextLayer textLayer = layer as TextLayer;
                        textLayer.UpdateText("test update", new Point(0, 0), 15.0f, Color.Purple);
                    }
                }

                psdImage.Save(dataDir + "UpdateTextLayerInPSDFile_out.psd");
            }

            //ExEnd:UpdateTextLayerInPSDFile

        }
    }
}
