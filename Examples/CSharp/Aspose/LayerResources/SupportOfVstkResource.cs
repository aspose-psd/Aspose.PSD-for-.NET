using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.StrokeResources;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfVstkResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfVstkResource
            //ExSummary:The following code demonstrates the support of VstkResource resource.

            string srcFile = Path.Combine(baseDir, "StrokeShapeTest1.psd");
            string dstFile = Path.Combine(outputDir, "StrokeShapeTest2.psd");

            using (PsdImage image = (PsdImage)Image.Load(srcFile))
            {
                Layer layer = image.Layers[1];
                foreach (LayerResource resource in layer.Resources)
                {
                    if (resource is VstkResource)
                    {
                        VstkResource vstkResource = (VstkResource)resource;
                        vstkResource.StrokeStyleLineAlignment = StrokePosition.Outside;
                        vstkResource.StrokeStyleLineWidth = 20;
                    }
                }
            
                image.Save(dstFile);
            }

            //ExEnd:SupportOfVstkResource

            File.Delete(dstFile);

            Console.WriteLine("SupportOfVstkResource executed successfully");
        }
    }
}