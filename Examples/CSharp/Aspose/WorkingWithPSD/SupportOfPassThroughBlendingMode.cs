using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;
using System;
using Aspose.PSD.FileFormats.Core.Blending;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class SupportOfPassThroughBlendingMode
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfPassThroughBlendingMode
            //ExSummary:The following example demonstrates how you can use the PassThrough layer blend mode in Aspose.PSD
            string sourceFileName = baseDir + "Apple.psd";
            string outputFileName = outputDir + "OutputApple";
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                if (image.Layers.Length < 23)
                {
                    throw new Exception("There is not 23rd layer.");
                }

                var layer = image.Layers[23] as LayerGroup;

                if (layer == null)
                {
                    throw new Exception("The 23rd layer is not a layer group.");
                }

                if (layer.Name != "AdjustmentGroup")
                {
                    throw new Exception("The 23rd layer name is not 'AdjustmentGroup'.");
                }

                if (layer.BlendModeKey != BlendMode.PassThrough)
                {
                    throw new Exception("AdjustmentGroup layer should have 'pass through' blend mode.");
                }

                image.Save(outputFileName + ".psd", new PsdOptions(image));
                image.Save(outputFileName + ".png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });

                layer.BlendModeKey = BlendMode.Normal;

                image.Save(outputFileName + "Normal.psd", new PsdOptions(image));
                image.Save(outputFileName + "Normal.png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            //ExEnd:SupportOfPassThroughBlendingMode
        }
    }
}