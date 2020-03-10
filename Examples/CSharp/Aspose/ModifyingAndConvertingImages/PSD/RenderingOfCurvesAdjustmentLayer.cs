using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class RenderingOfCurvesAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:RenderingOfCurvesAdjustmentLayer

            // Curves layer editing
            string sourceFileName = dataDir + "CurvesAdjustmentLayer";
            string psdPathAfterChange = "CurvesAdjustmentLayerChanged";
            string pngExportPath = "CurvesAdjustmentLayerChanged";

            for (int j = 1; j < 2; j++)
            {
                using (var im = (PsdImage)Image.Load(sourceFileName + j.ToString() + ".psd"))
                {
                    foreach (var layer in im.Layers)
                    {
                        if (layer is CurvesLayer)
                        {
                            var curvesLayer = (CurvesLayer)layer;
                            if (curvesLayer.IsDiscreteManagerUsed)
                            {
                                var manager = (CurvesDiscreteManager)curvesLayer.GetCurvesManager();

                                for (int i = 10; i < 50; i++)
                                {
                                    manager.SetValueInPosition(0, (byte)i, (byte)(15 + (i * 2)));
                                }
                            }
                            else
                            {
                                var manager = (CurvesContinuousManager)curvesLayer.GetCurvesManager();
                                manager.AddCurvePoint(0, 50, 100);
                                manager.AddCurvePoint(0, 150, 130);
                            }
                        }
                    }

                    // Save PSD
                    im.Save(psdPathAfterChange + j.ToString() + ".psd");

                    // Save PNG
                    var saveOptions = new PngOptions();
                    saveOptions.ColorType = PngColorType.TruecolorWithAlpha;
                    im.Save(pngExportPath + j.ToString() + ".png", saveOptions);
                }
            }
            //ExEnd:RenderingOfCurvesAdjustmentLayer

        }
    }
}
