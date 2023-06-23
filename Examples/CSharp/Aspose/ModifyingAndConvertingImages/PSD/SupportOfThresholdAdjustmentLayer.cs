using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfThresholdAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfThresholdAdjustmentLayer
            //ExSummary:The following code demonstrates the support of ThresholdLayer adjustment layer.

            string sourceFileWithThresholdLayer = Path.Combine(baseDir, "flowers_threshold_source.psd");
            string outputPsdWithThresholdLayer = Path.Combine(outputDir, "flowers_threshold_output.psd");
            string outputPngWithThresholdLayer = Path.Combine(outputDir, "flowers_threshold_output.png");

            string sourceFileWithoutThresholdLayer = Path.Combine(baseDir, "flowers_source.psd");
            string outputPsdWithoutThresholdLayer = Path.Combine(outputDir, "flowers_output.psd");
            string outputPngWithoutThresholdLayer = Path.Combine(outputDir, "flowers_output.png");

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }

            // Get, check, and change the Threshold adjustment layer from the image.
            using (var image = (PsdImage)Image.Load(sourceFileWithThresholdLayer))
            {
                foreach (var layer in image.Layers)
                {
                    if (layer is ThresholdLayer)
                    {
                        // Get Threshold adjustment layer.
                        ThresholdLayer thrsLayer = (ThresholdLayer)layer;
                        var level = thrsLayer.Level;

                        // Check layers parameters.
                        AssertAreEqual(level, (short)115);

                        // Set layers parameters.
                        thrsLayer.Level = 50;

                        image.Save(outputPsdWithThresholdLayer);
                        image.Save(outputPngWithThresholdLayer, new PngOptions());
                    }
                }
            }

            // Add and set the Threshold adjustment layer to the image.
            using (var image = (PsdImage)Image.Load(sourceFileWithoutThresholdLayer))
            {
                // Add Threshold Adjustment layer.
                ThresholdLayer thresholdLayer = image.AddThresholdAdjustmentLayer();

                // Set layers parameters.
                thresholdLayer.Level = 115;

                image.Save(outputPsdWithoutThresholdLayer);
                image.Save(outputPngWithoutThresholdLayer, new PngOptions());
            }
            
            //ExEnd:SupportOfThresholdAdjustmentLayer

            File.Delete(outputPsdWithThresholdLayer);
            File.Delete(outputPngWithThresholdLayer);
            File.Delete(outputPsdWithoutThresholdLayer);
            File.Delete(outputPngWithoutThresholdLayer);

            Console.WriteLine("SupportOfThresholdAdjustmentLayer executed successfully");
        }
    }
}