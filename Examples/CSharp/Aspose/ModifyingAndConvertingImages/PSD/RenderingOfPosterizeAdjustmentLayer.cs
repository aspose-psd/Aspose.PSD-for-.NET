using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class RenderingOfPosterizeAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:RenderingOfPosterizeAdjustmentLayer
            //ExSummary:The following code demonstrates the support of PosterizeLayer.

            string sourceFile = Path.Combine(baseDir, "zendeya_posterize.psd");
            string outputFile = Path.Combine(outputDir, "zendeya_posterize_10.psd");

            using (var image = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions()))
            {
                foreach (Layer layer in image.Layers)
                {
                    if (layer is PosterizeLayer)
                    {
                        ((PosterizeLayer)layer).Levels = 10;
                        image.Save(outputFile);

                        break;
                    }
                }
            }

            //ExEnd:RenderingOfPosterizeAdjustmentLayer

            File.Delete(outputFile);

            Console.WriteLine("RenderingOfPosterizeAdjustmentLayer executed successfully");
        }
    }
}