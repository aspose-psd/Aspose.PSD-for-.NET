using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.StrokeResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfPostResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfPostResource
            //ExSummary:The following code demonstrates the ability to manipulation of PostResource.

            string sourceFile = Path.Combine(baseDir, "zendeya_posterize.psd");
            string outputFile = Path.Combine(outputDir, "zendeya_posterize_10.psd");

            using (var image = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions()))
            {
                Layer layer = image.Layers[1];

                foreach (LayerResource resource in layer.Resources)
                {
                    if (resource is PostResource)
                    {
                        ((PostResource)resource).Levels = 10;
                        image.Save(outputFile);

                        break;
                    }
                }
            }

            //ExEnd:SupportOfPostResource

            File.Delete(outputFile);

            Console.WriteLine("SupportOfPostResource executed successfully");
        }
    }
}