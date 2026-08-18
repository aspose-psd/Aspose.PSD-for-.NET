using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartFilters;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;

namespace Aspose.PSD.Examples.Aspose.SmartFilters
{
    public class SupportDisplaceSmartFilter
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportDisplaceSmartFilter
            //ExSummary:The following code demonstrates the support of DisplaceSmartFilter.

            string sourceFile = Path.Combine(baseDir, "no_displace_filter.psd");
            string outputFile = Path.Combine(outputDir, "output_displace_filter.psd");
            string displaceMapPath = Path.Combine(baseDir, "displace_map.psd");

            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                SmartObjectLayer smartObj = (SmartObjectLayer)image.Layers[1];
                DisplaceSmartFilter displace = new DisplaceSmartFilter(displaceMapPath, true)
                {
                    HorizontalScale = 12.5,
                    VerticalScale = 15.0,
                    DisplacementMethod = DisplacementMethod.Tile,
                    UndefinedAreas = UndefinedAreas.WrapAround
                };

                List<SmartFilter> filters = new List<SmartFilter>(smartObj.SmartFilters.Filters);
                filters.Add(displace);
                smartObj.SmartFilters.Filters = filters.ToArray();
                smartObj.SmartFilters.UpdateResourceValues();
                image.Save(outputFile);

                // Need to check that output psd file can be opened by Photoshop
            }

            using (PsdImage image = (PsdImage)Image.Load(outputFile))
            {
                SmartObjectLayer smartObj = (SmartObjectLayer)image.Layers[1];
                DisplaceSmartFilter displace = smartObj.SmartFilters
                    .Filters[smartObj.SmartFilters.Filters.Length - 1] as DisplaceSmartFilter;

                AssertAreEqual(12.5, displace.HorizontalScale);
                AssertAreEqual(15.0, displace.VerticalScale);
                AssertAreEqual(DisplacementMethod.Tile, displace.DisplacementMethod);
                AssertAreEqual(UndefinedAreas.WrapAround, displace.UndefinedAreas);
                AssertAreEqual(true, displace.IsDisplacementMapEmbedded);
                AssertAreEqual(true, displace.DisplaceMapData != null);
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportDisplaceSmartFilter

            File.Delete(outputFile);

            Console.WriteLine("SupportDisplaceSmartFilter executed successfully");
        }
    }
}