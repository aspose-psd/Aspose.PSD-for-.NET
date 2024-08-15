using System;
using System.IO;
using System.Linq;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.FileFormats.Psd.Layers.Warp;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    public class WarpSettingsForSmartObjectLayerAndTextLayer
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:WarpSettingsForSmartObjectLayerAndTextLayer
            //ExSummary:The following code demonstrates how to manipulate WarpSettings to do warp transformation on SmartObjectLayer and TexLayer. 

            string sourceFile = Path.Combine(baseDir, "smart_without_warp.psd");

            var opt = new PsdLoadOptions()
            {
                LoadEffectsResource = true,
                AllowWarpRepaint = true
            };

            string[] outputImageFile = new string[4];
            string[] outputPsdFile = new string[4];

            for (int caseIndex = 0; caseIndex < outputImageFile.Length; caseIndex++)
            {
                outputImageFile[caseIndex] = Path.Combine(outputDir, "export_" + caseIndex + ".png");
                outputPsdFile[caseIndex] = Path.Combine(outputDir, "export_" + caseIndex + ".psd");

                using (PsdImage img = (PsdImage)Image.Load(sourceFile, opt))
                {
                    foreach (Layer layer in img.Layers)
                    {
                        if (layer is SmartObjectLayer)
                        {
                            var smartLayer = (SmartObjectLayer)layer;
                            smartLayer.WarpSettings = GetWarpSettingsByIndex(smartLayer.WarpSettings, caseIndex);
                        }

                        if (layer is TextLayer)
                        {
                            var textLayer = (TextLayer)layer;

                            if (caseIndex != 3)
                            {
                                textLayer.WarpSettings = GetWarpSettingsByIndex(textLayer.WarpSettings, caseIndex);
                            }
                        }
                    }

                    img.Save(outputPsdFile[caseIndex], new PsdOptions());
                }

                using (PsdImage img = (PsdImage)Image.Load(outputPsdFile[caseIndex], opt))
                {
                    img.Save(outputImageFile[caseIndex],
                        new PngOptions() { CompressionLevel = 9, ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            WarpSettings GetWarpSettingsByIndex(WarpSettings warpParams, int caseIndex)
            {
                switch (caseIndex)
                {
                    case 0:
                        warpParams.Style = WarpStyles.Rise;
                        warpParams.Rotate = WarpRotates.Horizontal;
                        warpParams.Value = 20;
                        break;
                    case 1:
                        warpParams.Style = WarpStyles.Rise;
                        warpParams.Rotate = WarpRotates.Vertical;
                        warpParams.Value = 10;
                        break;
                    case 2:
                        warpParams.Style = WarpStyles.Flag;
                        warpParams.Rotate = WarpRotates.Horizontal;
                        warpParams.Value = 30;
                        break;
                    case 3:
                        warpParams.Style = WarpStyles.Custom;
                        warpParams.MeshPoints[2].Y += 70;
                        break;
                }

                return warpParams;
            }

            //ExEnd:WarpSettingsForSmartObjectLayerAndTextLayer

            foreach (var outputFile in outputImageFile.Concat(outputPsdFile))
            {
                File.Delete(outputFile);   
            }

            Console.WriteLine("WarpSettingsForSmartObjectLayerAndTextLayer executed successfully");
        }
    }
}