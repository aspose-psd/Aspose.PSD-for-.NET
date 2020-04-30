using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;
using System;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportOfLclrResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart
            //ExSummary:The following example demonstrates how you can change Sheet Color Highlight In Aspose.PSD
            string sourceFilePath = Path.Combine(baseDir, "AllLclrResourceColors.psd");
            string outputFilePath = Path.Combine(outputDir, "AllLclrResourceColorsReversed.psd");

            // In the file colors of layers' highlighting are in this order
            SheetColorHighlightEnum[] sheetColorsArr = new SheetColorHighlightEnum[] {
                SheetColorHighlightEnum.Red,
                SheetColorHighlightEnum.Orange,
                SheetColorHighlightEnum.Yellow,
                SheetColorHighlightEnum.Green,
                SheetColorHighlightEnum.Blue,
                SheetColorHighlightEnum.Violet,
                SheetColorHighlightEnum.Gray,
                SheetColorHighlightEnum.NoColor
            };

            // Layer Sheet Color is used to visually highlight layers. 
            // For example you can update some layers in PSD and then highlight by color the layer which you want to attract attention. (Sheet color setting)
            using (PsdImage img = (PsdImage)Image.Load(sourceFilePath))
            {
                CheckSheetColorsAndRerverse(sheetColorsArr, img);
                img.Save(outputFilePath, new PsdOptions());
            }

            using (PsdImage img = (PsdImage)Image.Load(outputFilePath))
            {
                // Colors should be reversed
                Array.Reverse(sheetColorsArr);
                CheckSheetColorsAndRerverse(sheetColorsArr, img);
            }

            void CheckSheetColorsAndRerverse(SheetColorHighlightEnum[] sheetColors, PsdImage img)
            {
                int layersCount = img.Layers.Length;
                for (int layerIndex = 0; layerIndex < layersCount; layerIndex++)
                {
                    Layer layer = img.Layers[layerIndex];
                    LayerResource[] resources = layer.Resources;
                    foreach (LayerResource layerResource in resources)
                    {
                        // The lcrl resource always presents in psd file resource list.
                        LclrResource resource = layerResource as LclrResource;
                        if (resource != null)
                        {
                            if (resource.Color != sheetColors[layerIndex])
                            {
                                throw new Exception("Sheet Color has been read wrong");
                            }

                            // Reverse of style sheet colors. Set up of Layer color highlight.
                            resource.Color = sheetColors[layersCount - layerIndex - 1];
                            break;
                        }
                    }
                }
            }

            //ExEnd

            Console.WriteLine("SupportOfLclrResource executed successfully");
        }
    }
}
