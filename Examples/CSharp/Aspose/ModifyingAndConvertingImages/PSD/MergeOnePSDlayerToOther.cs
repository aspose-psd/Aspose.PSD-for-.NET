using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class TextLayerBoundBox
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:TextLayerBoundBox

            string sourceFileName = dataDir + "LayerWithText.psd";

            var correctOpticalSize = new Size(127, 45);
            var correctBoundBox = new Size(172, 62);

            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                var textLayer = (TextLayer)im.Layers[1];

                // Size of the layer is the size of the rendered area
                var opticalSize = textLayer.Size;
                Assert.AreEqual(correctOpticalSize, opticalSize);

                // TextBoundBox is the maximum layer size for Text Layer. 
                // In this area PS will try to fit your text
                var boundBox = textLayer.TextBoundBox;
                Assert.AreEqual(correctBoundBox, boundBox);
            }

            //ExEnd:TextLayerBoundBox
        }
    }
}
