using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class ExportLayerGroupToImage
    {
        public static void Run()
        {
            // The path to the document's directory.
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:ExportLayerGroupToImage
            string outputPsd = Path.Combine(outputDir, "LayerGroup.psd");
            string outputPng = Path.Combine(outputDir, "LayerGroup.psd_folder.png");

            using (PsdImage psdImage = new PsdImage(100, 100))
            {
                // Init background layer
                var bgLayer = FillLayer.CreateInstance(FillType.Color);
                ((IColorFillSettings)bgLayer.FillSettings).Color = Color.Blue;

                // Init regular layers
                byte[] tempBytes = new byte[10 * 10];
                Layer layer1 = new Layer(
                    new Rectangle(50, 50, 10, 10), tempBytes, tempBytes, tempBytes, "Layer 1");
                Layer layer2 = new Layer(
                    new Rectangle(50, 50, 10, 10), tempBytes, tempBytes, tempBytes, "Layer 2");
    
                // Init and add folder
                LayerGroup layerGroup = psdImage.AddLayerGroup("Folder", 0, true);
    
                // add background to PsdImage
                psdImage.AddLayer(bgLayer);
    
                // add regular layers to folder
                layerGroup.AddLayer(layer1);
                layerGroup.AddLayer(layer2);
    
                // Validate that the layers were added correctly
                System.Diagnostics.Debug.Assert(layerGroup.Layers[0].DisplayName == "Layer 1");
                System.Diagnostics.Debug.Assert(layerGroup.Layers[1].DisplayName == "Layer 2");

                psdImage.Save(outputPsd);
                layerGroup.Save(outputPng, new PngOptions());
            }
            //ExEnd:ExportLayerGroupToImage
            
            File.Delete(outputPsd);
            File.Delete(outputPng);
            Console.WriteLine("ExportLayerGroupToImage executed successfully");
        }
    }
}
