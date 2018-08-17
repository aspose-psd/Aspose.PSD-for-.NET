using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ManagePhotoFilterAdjustmentLayer
    {
        public static void Run()
        {
            //ExStart:ManagePhotoFilterAdjustmentLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Photo Filter layer editing
            string sourceFileName = dataDir + "PhotoFilterAdjustmentLayer.psd";
            string psdPathAfterChange = dataDir + "PhotoFilterAdjustmentLayerChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is PhotoFilterLayer)
                    {
                        var photoLayer = (PhotoFilterLayer)layer;
                        photoLayer.Color = Color.FromArgb(255, 60, 60);
                        photoLayer.Density = 78;
                        photoLayer.PreserveLuminosity = false;
                    }
                }
                im.Save(psdPathAfterChange);
            }

            // Photo Filter layer adding
            sourceFileName = dataDir+"PhotoExample.psd";
            psdPathAfterChange = dataDir + "PhotoExampleAddedPhotoFilter.psd";

            using (PsdImage im = (PsdImage)Image.Load(sourceFileName))
            {
                var layer = im.AddPhotoFilterLayer(Color.FromArgb(25, 255, 35));

                im.Save(psdPathAfterChange);
            }
            //ExEnd:ManagePhotoFilterAdjustmentLayer

        }

    }
}
