using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    internal class SupportOfVibAResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportOfVibAResource
            //ExSummary:The following code example demonstrates the support of the VibAResource resource.

            // Example of the support of read and write Vibration Resource at runtime.
            string sourceFileName = Path.Combine(SourceDir, "VibranceResource.psd");
            string outputFileName = Path.Combine(OutputDir, "out_VibranceResource.psd");

            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in image.Layers)
                {
                    foreach (var resource in layer.Resources)
                    {
                        if (resource is VibAResource)
                        {
                            var vibranceResource = (VibAResource)resource;

                            int vibranceValue =  vibranceResource.Vibrance;
                            int saturationValue = vibranceResource.Saturation;

                            vibranceResource.Vibrance = vibranceValue * 2;
                            vibranceResource.Saturation = saturationValue * 2;

                            break;
                        }
                    }
                }

                image.Save(outputFileName);
            }

            //ExEnd:SupportOfVibAResource

            Console.WriteLine("SupportOfVibAResource executed successfully");

            File.Delete(outputFileName);
        }
    }
}