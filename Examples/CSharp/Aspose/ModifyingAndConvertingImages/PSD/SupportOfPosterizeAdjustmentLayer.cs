using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfPosterizeAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfPosterizeAdjustmentLayer
            //ExSummary:The following code demonstrates the ability to add PosterizeAdjustmentLayer through PsdImage.
            
            string srcFile = Path.Combine(baseDir, "zendeya.psd");
            string outFile = Path.Combine(outputDir, "zendeya.psd.out.psd");

            using (PsdImage psdImage = (PsdImage)Image.Load(srcFile))
            {
                psdImage.AddPosterizeAdjustmentLayer();
                psdImage.Save(outFile);
            }

            // Check saved changes
            using (PsdImage image = (PsdImage)Image.Load(
                       outFile,
                       new PsdLoadOptions { LoadEffectsResource = true }))
            {
                AssertAreEqual(2, image.Layers.Length);

                PosterizeLayer posterizeLayer = (PosterizeLayer)image.Layers[1];

                AssertAreEqual(true, posterizeLayer is PosterizeLayer);
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportOfPosterizeAdjustmentLayer

            File.Delete(outFile);

            Console.WriteLine("SupportOfPosterizeAdjustmentLayer executed successfully");
        }
    }
}