using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SetTextLayerPosition
    {
        public static void Run() {

            //ExStart:SetTextLayerPosition
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir + "OneLayer.psd";
            string exportPath = dataDir + "OneLayer_Edited.psd";
            int leftPos = 99;
            int topPos = 47;
            var im = (PsdImage)Image.Load(sourceFileName);
            using (im)
            {
                im.AddTextLayer("Some text", new Rectangle(leftPos, topPos, 99, 47));
                TextLayer textLayer = (TextLayer)im.Layers[1];
                if (textLayer.Left != leftPos || textLayer.Top != topPos)
                {
                    throw new Exception("Was created incorrect Text Layer");
                }
                
                im.Save(exportPath);
            }

            //ExEnd:SetTextLayerPosition
        }
    }
}
