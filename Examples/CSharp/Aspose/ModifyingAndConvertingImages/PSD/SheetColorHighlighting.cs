using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SheetColorHighlighting
    {
        public static void Run()
        {

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SheetColorHighlighting
            string sourceFileName = dataDir+"SheetColorHighlightExample.psd";
            string exportPath = dataDir+"SheetColorHighlightExampleChanged.psd";


            // Load a PSD file as an image and cast it into PsdImage
            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                var layer1 = im.Layers[0];
                Assert.AreEqual(SheetColorHighlightEnum.Violet, layer1.SheetColorHighlight);

                var layer2 = im.Layers[1];
                Assert.AreEqual(SheetColorHighlightEnum.Orange, layer2.SheetColorHighlight);

                layer1.SheetColorHighlight = SheetColorHighlightEnum.Yellow;

                im.Save(exportPath);
            }


            //ExEnd:SheetColorHighlighting
        }

    }
}
