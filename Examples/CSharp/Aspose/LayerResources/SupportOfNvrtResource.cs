using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportOfNvrtResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string sourceDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfNvrtResource
            //The following example demonstrates how to get NvrtResource.
            string sourceFilePath = Path.Combine(sourceDir, "InvertAdjustmentLayer.psd");
            NvrtResource resource = null;
            using (PsdImage psdImage = (PsdImage)Image.Load(sourceFilePath))
            {
                foreach (Layer layer in psdImage.Layers)
                {
                    if (layer is InvertAdjustmentLayer)
                    {
                        foreach (LayerResource layerResource in layer.Resources)
                        {
                            if (layerResource is NvrtResource)
                            {
                                // The NvrtResource is supported.
                                resource = (NvrtResource)layerResource;
                                break;
                            }
                        }
                    }
                }
            }

            if (resource is null)
            {
                throw new Exception("NvrtResource Not Found");
            }
            //ExEnd:SupportOfNvrtResource

            Console.WriteLine("SupportOfNvrtResource executed successfully");
        }
    }
}


