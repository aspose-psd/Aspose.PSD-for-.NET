using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    internal class SupportOfFXidResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfFXidResource
            //ExSummary:This example demonstrates how to get and set properties of the FXidResource resource.

            string inputFilePath = Path.Combine(SourceDir, "psdnet414_3.psd");
            string output = Path.Combine(OutputDir, "out_psdnet414_3.psd");

            int resLength = 1144;
            int maskLength = 369;

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new FormatException(message ?? "Objects are not equal.");
                }
            }

            using (var psdImage = (PsdImage)Image.Load(inputFilePath))
            {
                FXidResource fXidResource = (FXidResource)psdImage.GlobalLayerResources[3];

                AssertAreEqual(resLength, fXidResource.Length);
                foreach (var maskData in fXidResource.FilterEffectMasks)
                {
                    AssertAreEqual(maskLength, maskData.Length);
                }

                psdImage.Save(output);
            }

            // check after saving
            using (var psdImage = (PsdImage)Image.Load(output))
            {
                FXidResource fXidResource = (FXidResource)psdImage.GlobalLayerResources[3];

                AssertAreEqual(resLength, fXidResource.Length);
                foreach (var maskData in fXidResource.FilterEffectMasks)
                {
                    AssertAreEqual(maskLength, maskData.Length);
                }
            }

            //ExEnd:SupportOfFXidResource

            Console.WriteLine("SupportOfFXidResource executed successfully");

            File.Delete(output);
        }
    }
}
