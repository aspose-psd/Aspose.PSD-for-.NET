using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfLsdkResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfLsdkResource
            //ExSummary:The following code demonstrates support of LsdkResource.

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new FormatException(message ?? "Objects are not equal.");
                }
            }

            string srcFile = Path.Combine(baseDir, "123 1.psd");
            string outFile = Path.Combine(outputDir, "output.psd");

            using (var psdImage = (PsdImage)Image.Load(srcFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                AssertAreEqual((psdImage.Layers[8].Resources[3] as LsdkResource).Length, 4);
                psdImage.Save(outFile);
            }

            // check after saving
            using (var psdImage = (PsdImage)Image.Load(outFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                AssertAreEqual((psdImage.Layers[8].Resources[3] as LsdkResource).Length, 4);
            }

            //ExEnd:SupportOfLsdkResource

            File.Delete(outFile);

            Console.WriteLine("SupportOfLsdkResource executed successfully");
        }
    }
}
