using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;

using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class AddNewRegularLayerToPSD
    {
        public static void Run()
        {

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddNewRegularLayerToPSD

            // Make ability to add the newly generated regular layer to PsdImage
            string sourceFileName = dataDir + "OneLayer.psd";
            string exportPath = dataDir + "OneLayerEdited.psd";
            string exportPathPng = dataDir + "OneLayerEdited.png";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                // Preparing two int arrays
                var data1 = new int[2500];
                var data2 = new int[2500];

                var rect1 = new Rectangle(0, 0, 50, 50);
                var rect2 = new Rectangle(0, 0, 100, 25);

                for (int i = 0; i < 2500; i++)
                {
                    data1[i] = -10000000;
                    data2[i] = -10000000;
                }

                var layer1 = im.AddRegularLayer();
                layer1.Left = 25;
                layer1.Top = 25;
                layer1.Right = 75;
                layer1.Bottom = 75;
                layer1.SaveArgb32Pixels(rect1, data1);

                var layer2 = im.AddRegularLayer();
                layer2.Left = 25;
                layer2.Top = 150;
                layer2.Right = 125;
                layer2.Bottom = 175;
                layer2.SaveArgb32Pixels(rect2, data2);

                // Save psd
                im.Save(exportPath, new PsdOptions());

                // Save png
                im.Save(exportPathPng, new PngOptions());
            }
            //ExEnd:AddNewRegularLayerToPSD
        }
    }
}
