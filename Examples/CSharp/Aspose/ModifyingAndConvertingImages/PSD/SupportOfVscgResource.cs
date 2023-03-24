using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.StrokeResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfVscgResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfVscgResource
            //ExSummary:The following code demonstrates the support of VscgResource.

            string sourceFile = Path.Combine(baseDir, "StrokeInternalFill_src.psd");
            string outputFile = Path.Combine(outputDir, "StrokeInternalFill_res.psd");

            void AreEqual(double expected, double current, double tolerance = 0.1)
            {
                if (Math.Abs(expected - current) > tolerance)
                {
                    throw new Exception(
                        $"Values is not equal.\nExpected:{expected}\nResult:{current}\nDifference:{expected - current}");
                }
            }

            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                VscgResource vscgResource = (VscgResource)image.Layers[1].Resources[0];
                DescriptorStructure rgbColorStructure = (DescriptorStructure)vscgResource.Items[0];

                AreEqual(89.8, ((DoubleStructure)rgbColorStructure.Structures[0]).Value);
                AreEqual(219.6, ((DoubleStructure)rgbColorStructure.Structures[1]).Value);
                AreEqual(34.2, ((DoubleStructure)rgbColorStructure.Structures[2]).Value);

                ((DoubleStructure)rgbColorStructure.Structures[0]).Value = 255d; // Red
                ((DoubleStructure)rgbColorStructure.Structures[1]).Value = 0d; // Green
                ((DoubleStructure)rgbColorStructure.Structures[2]).Value = 0d; // Blue

                image.Save(outputFile);
            }

            // checking changes
            using (PsdImage image = (PsdImage)Image.Load(outputFile))
            {
                VscgResource vscgResource = (VscgResource)image.Layers[1].Resources[0];
                DescriptorStructure rgbColorStructure = (DescriptorStructure)vscgResource.Items[0];

                AreEqual(255, ((DoubleStructure)rgbColorStructure.Structures[0]).Value);
                AreEqual(0, ((DoubleStructure)rgbColorStructure.Structures[1]).Value);
                AreEqual(0, ((DoubleStructure)rgbColorStructure.Structures[2]).Value);
            }

            //ExEnd:SupportOfVscgResource

            File.Delete(outputFile);

            Console.WriteLine("SupportOfVscgResource executed successfully");
        }
    }
}