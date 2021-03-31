using System;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class CreateLayerGroups
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:CreateLayerGroups

            string inputFile = dataDir + "ButtonTemp.psd";

            var createOptions = new PsdOptions();
            createOptions.Source = new FileCreateSource(inputFile, false);
            createOptions.Palette = new PsdColorPalette(new Color[] { Color.Green });

            using (var psdImage = (PsdImage)Image.Create(createOptions, 500, 500))
            {
                LayerGroup group1 = psdImage.AddLayerGroup("Group 1", 0, true);

                Layer layer1 = new Layer(psdImage);
                layer1.Name = "Layer 1";
                group1.AddLayer(layer1);

                LayerGroup group2 = group1.AddLayerGroup("Group 2", 1);

                Layer layer2 = new Layer(psdImage);
                layer2.Name = "Layer 2";
                group2.AddLayer(layer2);

                Layer layer3 = new Layer(psdImage);
                layer3.Name = "Layer 3";
                group2.AddLayer(layer3);

                Layer layer4 = new Layer(psdImage);
                layer4.Name = "Layer 4";
                group1.AddLayer(layer4);

                psdImage.Save(dataDir + "LayerGroups_out.psd");
            }
            //ExEnd:CreateLayerGroups

            Console.WriteLine("CreateLayerGroups executed successfully");
        }
    }
}
