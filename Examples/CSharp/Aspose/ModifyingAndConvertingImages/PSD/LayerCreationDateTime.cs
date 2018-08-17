using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class LayerCreationDateTime
    {
        public static void Run()
        {

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:LayerCreationDateTime

            string SourceName = dataDir + "OneLayer.psd";

            // Load a PSD file as an image and cast it into PsdImage
            using (var im = (PsdImage)(Image.Load(SourceName)))
            {
                var layer = im.Layers[0];
                var creationDateTime = layer.LayerCreationDateTime;
                var expectedDateTime = new DateTime(2018, 7, 17, 8, 57, 24, 769);

                Assert.AreEqual(expectedDateTime, creationDateTime);

                var now = DateTime.Now;
                var createdLayer = im.AddLevelsAdjustmentLayer();

                // Check if Creation Date Time Updated on newly created layers
                Assert.IsTrue(now <= createdLayer.LayerCreationDateTime);
            }

        //ExEnd:LayerCreationDateTime
        }

    }
}
