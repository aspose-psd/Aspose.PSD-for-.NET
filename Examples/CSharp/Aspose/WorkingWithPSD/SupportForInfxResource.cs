using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class SupportForInfxResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:1
            void AssertIsTrue(bool condition, string message)
            {
                if (!condition)
                {
                    throw new FormatException(message);
                }
            }

            string sourceFileName = SourceDir + "SampleForInfxResource.psd";
            string destinationFileName = OutputDir + "SampleForInfxResource_out.psd";
            bool isRequiredResourceFound = false;
            using (PsdImage im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    foreach (var layerResource in layer.Resources)
                    {
                        if (layerResource is InfxResource)
                        {
                            var resource = (InfxResource)layerResource;
                            isRequiredResourceFound = true;
                            AssertIsTrue(!resource.BlendInteriorElements, "The InfxResource.BlendInteriorElements should be false");

                            // Test editing and saving
                            resource.BlendInteriorElements = true;
                            im.Save(destinationFileName);
                            break;
                        }
                    }
                }
            }

            AssertIsTrue(isRequiredResourceFound, "The specified InfxResource not found");
            isRequiredResourceFound = false;

            using (PsdImage im = (PsdImage)Image.Load(destinationFileName))
            {
                foreach (var layer in im.Layers)
                {
                    foreach (var layerResource in layer.Resources)
                    {
                        if (layerResource is InfxResource)
                        {
                            var resource = (InfxResource)layerResource;
                            isRequiredResourceFound = true;
                            AssertIsTrue(resource.BlendInteriorElements, "The InfxResource.BlendInteriorElements should change to true");

                            break;
                        }
                    }
                }
            }

            AssertIsTrue(isRequiredResourceFound, "The specified InfxResource not found");
            //ExEnd:1

            Console.WriteLine("SupportForInfxResource executed successfully");
        }
    }
}
