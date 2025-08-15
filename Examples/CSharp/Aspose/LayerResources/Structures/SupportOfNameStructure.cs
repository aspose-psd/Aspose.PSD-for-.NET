using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources.Structures
{
    public class SupportOfNameStructure
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfNameStructure

            //ExSummary:The following code demonstrates the support of NameStructure.

            string inputFile = Path.Combine(baseDir, "Mixer_ipad_Hand_W_crash.psd");
            string outputFile = Path.Combine(outputDir, "output.psd");

            using (var psdImage = (PsdImage)Image.Load(inputFile, new PsdLoadOptions { DataRecoveryMode = DataRecoveryMode.MaximalRecover }))
            {
                //// File is loaded successfully

                SmartObjectLayer layer = (SmartObjectLayer)psdImage.Layers[3];
                SoLdResource resource = (SoLdResource)layer.Resources[9];

                DescriptorStructure struct1 = (DescriptorStructure)resource.Items[15];
                ListStructure struct2 = (ListStructure)struct1.Structures[5];
                DescriptorStructure struct3 = (DescriptorStructure)struct2.Types[0];
                DescriptorStructure struct4 = (DescriptorStructure)struct3.Structures[6];
                ReferenceStructure struct5 = (ReferenceStructure)struct4.Structures[8];
                NameStructure nameStructure = (NameStructure)struct5.Items[0];

                AssertIsNotNull(nameStructure);
                AssertAreEqual(37, nameStructure.Length);
                AssertAreEqual("None\0", nameStructure.Value);

                // Save the test file without changes
                psdImage.Save(outputFile);

                //// File should be opened in PS without mistakes
            }

            // Check that the structures of Lighting effects are saved correctly
            using (var psdImage = (PsdImage)Image.Load(
                       outputFile,
                       new PsdLoadOptions { DataRecoveryMode = DataRecoveryMode.MaximalRecover }))
            {
                SmartObjectLayer layer = (SmartObjectLayer)psdImage.Layers[3];
                SoLdResource resource = (SoLdResource)layer.Resources[9];

                DescriptorStructure struct1 = (DescriptorStructure)resource.Items[15];
                ListStructure struct2 = (ListStructure)struct1.Structures[5];
                DescriptorStructure struct3 = (DescriptorStructure)struct2.Types[0];
                DescriptorStructure struct4 = (DescriptorStructure)struct3.Structures[6];
                ReferenceStructure struct5 = (ReferenceStructure)struct4.Structures[8];
                NameStructure nameStructure = (NameStructure)struct5.Items[0];

                AssertIsNotNull(nameStructure);
                AssertAreEqual(37, nameStructure.Length);
                AssertAreEqual("None\0", nameStructure.Value);
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            void AssertIsNotNull(object actual)
            {
                if (actual == null)
                {
                    throw new Exception("Object is null.");
                }
            }

            //ExEnd:SupportOfNameStructure

            File.Delete(outputFile);

            Console.WriteLine("SupportOfNameStructure executed successfully");
        }
    }
}
