using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SheetColorHighlighting
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SheetColorHighlighting
            string sourceFileName = dataDir + "SheetColorHighlightExample.psd";
            string exportPath = dataDir + "SheetColorHighlightExampleChanged.psd";


            // Load a PSD file as an image and cast it into PsdImage
            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                var layer1 = im.Layers[0];
                var layer2 = im.Layers[1];

                if (layer1.SheetColorHighlight != SheetColorHighlightEnum.Violet ||
                    layer2.SheetColorHighlight != SheetColorHighlightEnum.Orange)
                {
                    throw new Exception("Assertion failed");
                }

                    layer1.SheetColorHighlight = SheetColorHighlightEnum.Yellow;

                im.Save(exportPath);
            }

            //ExEnd:SheetColorHighlighting
        }

    }
}
