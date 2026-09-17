using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartFilters;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;

namespace Aspose.PSD.Examples.Aspose.SmartFilters
{
    public class SupportEmbossSmartFilter
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportEmbossSmartFilter
            //ExSummary:The following code demonstrates the support of Emboss smart filter.

            string srcFileName = "no_filter.psd";
            string sourceFile = Path.Combine(baseDir, srcFileName);
            string outputFile = Path.Combine(outputDir, "out_PSDNET2834.psd");
            
            using (var image = (PsdImage)Image.Load(sourceFile))
            {
                SmartObjectLayer smartObj = (SmartObjectLayer)image.Layers[1];
                var filters = new List<SmartFilter>(smartObj.SmartFilters.Filters);
                EmbossSmartFilter emboss = new EmbossSmartFilter();
                emboss.Angle = 180;
                emboss.Height = 10;
                emboss.Amount = 120;
                filters.Add(emboss);
                smartObj.SmartFilters.Filters = filters.ToArray();
                smartObj.SmartFilters.UpdateResourceValues();
            
                image.Save(outputFile);
                // Check that output file can be opened by PS.
            }
            
            using (var image = (PsdImage)Image.Load(outputFile))
            {
                SmartObjectLayer smartObj = (SmartObjectLayer)image.Layers[1];
                EmbossSmartFilter emboss = (EmbossSmartFilter)smartObj.SmartFilters.Filters[0];
            
                AssertAreEqual(180, emboss.Angle);
                AssertAreEqual(10, emboss.Height);
                AssertAreEqual(120, emboss.Amount);
            }
            
            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportEmbossSmartFilter

            File.Delete(outputFile);

            Console.WriteLine("SupportEmbossSmartFilter executed successfully");
        }
    }
}