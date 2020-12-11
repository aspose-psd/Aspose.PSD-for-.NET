using System;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class SupportOfObArAndUnFlSignatures
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfObArAndUnFlSignatures
            //ExSummary:The following code demonstrates the support of the ObAr and UnFl signatures.

            void AssertAreEqual(object actual, object expected)
            {
                if (!object.Equals(actual, expected))
                {
                    throw new FormatException(string.Format("Actual value {0} are not equal to expected {1}.", actual, expected));
                }
            }

            var sourceFilePath = baseFolder + "LayeredSmartObjects8bit2.psd";
            using (PsdImage image = (PsdImage)Image.Load(sourceFilePath))
            {
                UnitArrayStructure verticalStructure = null;
                foreach (Layer imageLayer in image.Layers)
                {
                    foreach (var imageResource in imageLayer.Resources)
                    {
                        var resource = imageResource as PlLdResource;
                        if (resource != null && resource.IsCustom)
                        {
                            foreach (OSTypeStructure structure in resource.Items)
                            {
                                if (structure.KeyName.ClassName == "customEnvelopeWarp")
                                {
                                    AssertAreEqual(typeof(DescriptorStructure), structure.GetType());
                                    var custom = (DescriptorStructure)structure;
                                    AssertAreEqual(custom.Structures.Length, 1);
                                    var mesh = custom.Structures[0];
                                    AssertAreEqual(typeof(ObjectArrayStructure), mesh.GetType());
                                    var meshObjectArray = (ObjectArrayStructure)mesh;
                                    AssertAreEqual(meshObjectArray.Structures.Length, 2);
                                    var vertical = meshObjectArray.Structures[1];
                                    AssertAreEqual(typeof(UnitArrayStructure), vertical.GetType());
                                    verticalStructure = (UnitArrayStructure)vertical;
                                    AssertAreEqual(verticalStructure.UnitType, UnitTypes.Pixels);
                                    AssertAreEqual(verticalStructure.ValueCount, 16);

                                    break;
                                }
                            }
                        }
                    }
                }

                AssertAreEqual(true, verticalStructure != null);
            }

            //ExEnd:SupportOfObArAndUnFlSignatures

            Console.WriteLine("SupportOfObArAndUnFlSignatures executed successfully");
        }
    }
}
