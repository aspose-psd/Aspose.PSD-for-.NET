using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class SupportForLspfResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:1
            const string ActualPropertyValueIsWrongMessage = "Expected property value is not equal to actual value";
            void AssertIsTrue(bool condition, string message)
            {
                if (!condition)
                {
                    throw new FormatException(message);
                }
            }

            string sourceFileName = SourceDir + "SampleForLspfResource.psd";
            string destinationFileName = OutputDir + "SampleForLspfResource_out.psd";
            bool isRequiredResourceFound = false;
            using (PsdImage im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    foreach (var layerResource in layer.Resources)
                    {
                        if (layerResource is LspfResource)
                        {
                            var resource = (LspfResource)layerResource;

                            isRequiredResourceFound = true;

                            AssertIsTrue(false == resource.IsCompositeProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(false == resource.IsPositionProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(false == resource.IsTransparencyProtected, ActualPropertyValueIsWrongMessage);

                            // Test editing and saving
                            resource.IsCompositeProtected = true;
                            AssertIsTrue(true == resource.IsCompositeProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(false == resource.IsPositionProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(false == resource.IsTransparencyProtected, ActualPropertyValueIsWrongMessage);

                            resource.IsCompositeProtected = false;
                            resource.IsPositionProtected = true;
                            AssertIsTrue(false == resource.IsCompositeProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(true == resource.IsPositionProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(false == resource.IsTransparencyProtected, ActualPropertyValueIsWrongMessage);

                            resource.IsPositionProtected = false;
                            resource.IsTransparencyProtected = true;
                            AssertIsTrue(false == resource.IsCompositeProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(false == resource.IsPositionProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(true == resource.IsTransparencyProtected, ActualPropertyValueIsWrongMessage);

                            resource.IsCompositeProtected = true;
                            resource.IsPositionProtected = true;
                            resource.IsTransparencyProtected = true;

                            im.Save(destinationFileName);
                            break;
                        }
                    }
                }
            }

            AssertIsTrue(isRequiredResourceFound, "The specified LspfResource not found");
            isRequiredResourceFound = false;

            using (PsdImage im = (PsdImage)Image.Load(destinationFileName))
            {
                foreach (var layer in im.Layers)
                {
                    foreach (var layerResource in layer.Resources)
                    {
                        if (layerResource is LspfResource)
                        {
                            var resource = (LspfResource)layerResource;

                            isRequiredResourceFound = true;

                            AssertIsTrue(resource.IsCompositeProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(resource.IsPositionProtected, ActualPropertyValueIsWrongMessage);
                            AssertIsTrue(resource.IsTransparencyProtected, ActualPropertyValueIsWrongMessage);

                            break;
                        }
                    }
                }
            }

            AssertIsTrue(isRequiredResourceFound, "The specified LspfResource not found");
            Console.WriteLine("LspfResource updating works as expected. Press any key.");
            //ExEnd:1

            Console.WriteLine("SupportForLspfResource executed successfully");
        }
    }
}
