using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class AddGradientMapAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:AddGradientMapAdjustmentLayer
            //ExSummary:The following code demonstrates the support of Gradient map layer.
            
            string sourceFile = Path.Combine(baseDir, "gradient_map_src.psd");
            string outputFile = Path.Combine(outputDir, "gradient_map_src_output.psd");

            using (PsdImage im = (PsdImage)Image.Load(sourceFile))
            {
                // Add Gradient map adjustment layer.
                GradientMapLayer layer = im.AddGradientMapAdjustmentLayer();
                layer.GradientSettings.Reverse = true;
                layer.Update();

                im.Save(outputFile);
            }

            // Check saved changes
            using (PsdImage im = (PsdImage)Image.Load(outputFile))
            {
                GradientMapLayer gradientMapLayer = im.Layers[1] as GradientMapLayer;
                GradientFillSettings gradientSettings = (GradientFillSettings)gradientMapLayer.GradientSettings;

                AssertAreEqual(90.0, gradientSettings.Angle);
                AssertAreEqual((short)4096, gradientSettings.Interpolation);
                AssertAreEqual(true, gradientSettings.Reverse);
                AssertAreEqual(true, gradientSettings.AlignWithLayer);
                AssertAreEqual(false, gradientSettings.Dither);
                AssertAreEqual(GradientType.Linear, gradientSettings.GradientType);
                AssertAreEqual(100, gradientSettings.Scale);
                AssertAreEqual(0.0, gradientSettings.HorizontalOffset);
                AssertAreEqual(0.0, gradientSettings.VerticalOffset);
                AssertAreEqual("Custom", gradientSettings.GradientName);
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }
            
            //ExEnd:AddGradientMapAdjustmentLayer

            File.Delete(outputFile);

            Console.WriteLine("AddGradientMapAdjustmentLayer executed successfully");
        }
    }
}