using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Resources.Enums;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfLMskResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportOfLMskResource
            //ExSummary:The following code demonstrates how to change Layer Mask Display Options on 16-bit images through changing LmskResource properties.
            
            string sourceFile = Path.Combine(baseDir, "sourceFile.psd");
            string outputPsd = Path.Combine(outputDir, "sourceFile_output.psd");

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }

            // Load 16-bit image.
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                // Find LmskResource.
                LmskResource lmskResource = new LmskResource();
                foreach (var res in image.GlobalLayerResources)
                {
                    if (res is LmskResource)
                    {
                        lmskResource = (LmskResource)res;
                        break;
                    }
                }

                // Check LmskResource properties.
                AssertAreEqual(lmskResource.ColorSpace, ColorSpace.RGB);
                AssertAreEqual(lmskResource.ColorComponent1, (ushort)65535);
                AssertAreEqual(lmskResource.ColorComponent2, (ushort)0);
                AssertAreEqual(lmskResource.ColorComponent3, (ushort)0);
                AssertAreEqual(lmskResource.ColorComponent4, (ushort)0);
                AssertAreEqual(lmskResource.Opacity, (short)45);
                AssertAreEqual(lmskResource.Flag, (byte)128);

                // Change LmskResource properties.
                lmskResource.ColorSpace = ColorSpace.HSB;
                lmskResource.ColorComponent1 = 7854;
                lmskResource.ColorComponent2 = 10;
                lmskResource.ColorComponent3 = 15484;
                lmskResource.Opacity = 85;

                // Save the image.
                image.Save(outputPsd);
            }

            //ExEnd:SupportOfLMskResource
            
            File.Delete(outputPsd);

            Console.WriteLine("SupportOfLMskResource executed successfully");
        }
    }
}