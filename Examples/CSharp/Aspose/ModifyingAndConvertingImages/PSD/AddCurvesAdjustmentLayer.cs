using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddCurvesAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddCurvesAdjustmentLayer

            // Curves layer editing
            string sourceFileName = dataDir + "CurvesAdjustmentLayer";
            string psdPathAfterChange = dataDir + "CurvesAdjustmentLayerChanged";

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
                }

            }
            //ExEnd:AddCurvesAdjustmentLayer

        }

    }
}
