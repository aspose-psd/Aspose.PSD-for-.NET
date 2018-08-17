using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PossibilityToFlattenLayers
    {
        public static void Run()
        {

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:PossibilityToFlattenLayers

       
            // Flatten whole PSD
            string sourceFileName = dataDir + "ThreeRegularLayersSemiTransparent.psd";
            string exportPath = dataDir + "ThreeRegularLayersSemiTransparentFlattened.psd";

            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                im.FlattenImage();
                im.Save(exportPath);
            }

            // Merge one layer in another
             exportPath = dataDir + "ThreeRegularLayersSemiTransparentFlattenedLayerByLayer.psd";

            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                var bottomLayer = im.Layers[0];
                var middleLayer = im.Layers[1];
                var topLayer = im.Layers[2];

                var layer1 = im.MergeLayers(bottomLayer, middleLayer);
                var layer2 = im.MergeLayers(layer1, topLayer);

                // Set up merged layers
                im.Layers = new Layer[] { layer2 };

                im.Save(exportPath);
            }
            //ExEnd:PossibilityToFlattenLayers
        }

    }
}
