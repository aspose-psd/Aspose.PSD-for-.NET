using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfLinkedLayer
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfLinkedLayer
            using (var psd = (PsdImage)Image.Load(dataDir + "LinkedLayerexample.psd"))
            {
                Layer[] layers = psd.Layers;

                // link all layers in one linked group
                short layersLinkGroupId = psd.LinkedLayersManager.LinkLayers(layers);

                // gets id for one layer
                short linkGroupId = psd.LinkedLayersManager.GetLinkGroupId(layers[0]);
                if (layersLinkGroupId != linkGroupId)
                {
                    throw new Exception("layersLinkGroupId and linkGroupId are not equal.");
                }

                // gets all linked layers by link group id.
                Layer[] linkedLayers = psd.LinkedLayersManager.GetLayersByLinkGroupId(linkGroupId);

                // unlink each layer from group
                foreach (var linkedLayer in linkedLayers)
                {
                    psd.LinkedLayersManager.UnlinkLayer(linkedLayer);
                }

                // retrieves NULL for a link group ID that has no layers in the group.
                linkedLayers = psd.LinkedLayersManager.GetLayersByLinkGroupId(linkGroupId);
                if (linkedLayers != null)
                {
                    throw new Exception("The linkedLayers field is not NULL.");
                }
                psd.Save(dataDir + "LinkedLayerexample_output.psd");
            }

            //ExEnd:SupportOfLinkedLayer
        }
    }
}
