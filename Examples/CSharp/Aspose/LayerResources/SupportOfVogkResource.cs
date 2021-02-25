using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;
using System.IO;
using Aspose.PSD.FileFormats.Core.VectorPaths;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportOfVogkResource
    {
        public static void Run()
        {
            //ExStart:SupportOfVogkResource
            // VogkResource Support
            void ExampleOfVogkResourceSupport()
            {
                // The path to the documents directory.
                string SourceDir = RunExamples.GetDataDir_PSD();
                string OutputDir = RunExamples.GetDataDir_Output();

                string fileName = Path.Combine(SourceDir, "VectorOriginationDataResource.psd");
                string outFileName = Path.Combine(OutputDir, "out_VectorOriginationDataResource_.psd");

                using (var psdImage = (PsdImage)Image.Load(fileName))
                {
                    var resource = GetVogkResource(psdImage);

                    // Reading
                    if (resource.ShapeOriginSettings.Length != 1 ||
                        !resource.ShapeOriginSettings[0].IsShapeInvalidated ||
                        resource.ShapeOriginSettings[0].OriginIndex != 0)
                    {
                        throw new Exception("VogkResource were read wrong.");
                    }

                    // Editing
                    resource.ShapeOriginSettings = new[]
                    {
                    resource.ShapeOriginSettings[0],
                    new VectorShapeOriginSettings(true, 1)
                };

                    psdImage.Save(outFileName);
                }
            }

            VogkResource GetVogkResource(PsdImage image)
            {
                var layer = image.Layers[1];

                VogkResource resource = null;
                var resources = layer.Resources;
                for (int i = 0; i < resources.Length; i++)
                {
                    if (resources[i] is VogkResource)
                    {
                        resource = (VogkResource)resources[i];
                        break;
                    }
                }

                if (resource == null)
                {
                    throw new Exception("VogkResourcenot found.");
                }

                return resource;
            }


            ExampleOfVogkResourceSupport();

            //ExEnd:SupportOfVogkResource

            Console.WriteLine("SupportOfVogkResource executed successfully");
        }
    }
}
