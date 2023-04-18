using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfGrdmResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfGrdmResource
            //ExSummary:The following code demonstrates support of GrdmResource resource.

            string sourceFile = Path.Combine(baseDir, "gradient_map_default.psd");
            string outputFile = Path.Combine(outputDir, "gradient_map_res.psd");

            using (var image = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions()))
            {
                Layer layer = image.Layers[1];
                GrdmResource grdmResource = (GrdmResource)layer.Resources[0];
                
                // check current values
                AssertAreEqual(false, grdmResource.Reverse);
                AssertAreEqual((ulong)65535, grdmResource.ColorPoints[1].RawColor.Components[2].Value);
                AssertAreEqual((ulong)65535, grdmResource.ColorPoints[1].RawColor.Components[3].Value);
                
                grdmResource.Reverse = true;
                // Red color for second gradient color point
                grdmResource.ColorPoints[1].RawColor.Components[1].Value = ushort.MaxValue;
                grdmResource.ColorPoints[1].RawColor.Components[2].Value = 0;
                grdmResource.ColorPoints[1].RawColor.Components[3].Value = 0;
                
                image.Save(outputFile, new PsdOptions());
            }

            using (var image = (PsdImage)Image.Load(outputFile))
            {
                Layer layer = image.Layers[1];
                GrdmResource grdmResource = (GrdmResource)layer.Resources[0];
                
                // check changed values
                AssertAreEqual(true, grdmResource.Reverse);
                AssertAreEqual((ulong)0, grdmResource.ColorPoints[1].RawColor.Components[2].Value);
                AssertAreEqual((ulong)0, grdmResource.ColorPoints[1].RawColor.Components[3].Value);
            }
            
            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportOfGrdmResource

            File.Delete(outputFile);

            Console.WriteLine("SupportOfGrdmResource executed successfully");
        }
    }
}