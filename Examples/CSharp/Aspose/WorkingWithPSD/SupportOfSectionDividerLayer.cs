using System;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class SupportOfSectionDividerLayer
    {
        public static void Run()
        {
            //ExStart:SupportOfSectionDividerLayer

            // The following code demonstrates SectionDividerLayer layers and how to get the related to it LayerGroup.

            // Layers hierarchy
            //    [0]: '</Layer group>' SectionDividerLayer for Group 1
            //    [1]: 'Layer 1' Regular Layer
            //    [2]: '</Layer group>' SectionDividerLayer for Group 2
            //    [3]: '</Layer group>' SectionDividerLayer for Group 3
            //    [4]: 'Group 3' GroupLayer
            //    [5]: 'Group 2' GroupLayer
            //    [6]: 'Group 1' GroupLayer

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            using (var image = new PsdImage(100, 100))
            {
                // Creating layers hierarchy
                // Add the LayerGroup 'Group 1'
                LayerGroup group1 = image.AddLayerGroup("Group 1", 0, true);
                // Add regular layer
                Layer layer1 = new Layer();
                layer1.DisplayName = "Layer 1";
                group1.AddLayer(layer1);
                // Add the LayerGroup 'Group 2'
                LayerGroup group2 = group1.AddLayerGroup("Group 2", 1);
                // Add the LayerGroup 'Group 3'
                LayerGroup group3 = group2.AddLayerGroup("Group 3", 0);

                // Gets the SectionDividerLayer's
                SectionDividerLayer divider1 = (SectionDividerLayer)image.Layers[0];
                SectionDividerLayer divider2 = (SectionDividerLayer)image.Layers[2];
                SectionDividerLayer divider3 = (SectionDividerLayer)image.Layers[3];

                // using the SectionDividerLayer.GetRelatedLayerGroup() method, obtains the related LayerGroup instance.
                AssertAreEqual(group1.DisplayName, divider1.GetRelatedLayerGroup().DisplayName); // the same LayerGroup
                AssertAreEqual(group2.DisplayName, divider2.GetRelatedLayerGroup().DisplayName); // the same LayerGroup
                AssertAreEqual(group3.DisplayName, divider3.GetRelatedLayerGroup().DisplayName); // the same LayerGroup

                LayerGroup folder1 = divider1.GetRelatedLayerGroup();
                AssertAreEqual(5, folder1.Layers.Length); // 'Group 1' contains 5 layers
            }

            //ExEnd:SupportOfSectionDividerLayer

            Console.WriteLine("SupportOfSectionDividerLayer executed successfully");
        }
    }
}
