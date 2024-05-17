using System;
using System.IO;
using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    public class SupportOfHasMultiLayerMasksAndColorIndexProperties
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfHasMultiLayerMasksAndColorIndexProperties
            //ExSummary:The following code demonstrates support of HasMultiLayerMasks and ColorIndex properties in AiLayerSection.
            
            string sourceFile = Path.Combine(baseDir, "example.ai");
            string outputFilePath = Path.Combine(outputDir, "example.png");

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }

            using (AiImage image = (AiImage)Image.Load(sourceFile))
            {
                AssertAreEqual(image.Layers.Length, 2);
                AssertAreEqual(image.Layers[0].HasMultiLayerMasks, false);
                AssertAreEqual(image.Layers[0].ColorIndex, -1);
                AssertAreEqual(image.Layers[1].HasMultiLayerMasks, false);
                AssertAreEqual(image.Layers[1].ColorIndex, -1);

                image.Save(outputFilePath, new PngOptions());
            }
            
            //ExEnd:SupportOfHasMultiLayerMasksAndColorIndexProperties

            File.Delete(outputFilePath);

            Console.WriteLine("SupportOfHasMultiLayerMasksAndColorIndexProperties executed successfully");
        }
    }
}