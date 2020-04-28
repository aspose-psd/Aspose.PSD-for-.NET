using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportForClblResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportForClblResource
            string sourceFileName = SourceDir + "SampleForClblResource.psd";
            string destinationFileName = OutputDir + "SampleForClblResource_out.psd";

            ClblResource GetClblResource(PsdImage psdImage)
            {
                foreach (var layer in psdImage.Layers)
                {
                    foreach (var layerResource in layer.Resources)
                    {
                        if (layerResource is ClblResource)
                        {
                            return (ClblResource)layerResource;
                        }
                    }
                }

                throw new Exception("The specified ClblResource not found");
            }

            using (PsdImage psdImage = (PsdImage)Image.Load(sourceFileName))
            {
                var resource = GetClblResource(psdImage);
                Console.WriteLine("ClblResource.BlendClippedElements [should be true]: " + resource.BlendClippedElements);

                // Test editing and saving
                resource.BlendClippedElements = false;
                psdImage.Save(destinationFileName);
            }

            using (PsdImage psdImage = (PsdImage)Image.Load(destinationFileName))
            {
                var resource = GetClblResource(psdImage);
                Console.WriteLine("ClblResource.BlendClippedElements [should change to false]: " + resource.BlendClippedElements);
            }
            //ExEnd:SupportForClblResource

            Console.WriteLine("SupportForClblResource executed successfully");
        }
    }
}
