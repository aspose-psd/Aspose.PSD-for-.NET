using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfIfxsResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfIfxsResource
            //ExSummary:The following code demonstrates the support of IfxsResource.

            string sourceFile = Path.Combine(baseDir, "548_example.psd");
            string outputFile = Path.Combine(outputDir, "export.psd");

            var loadOptions = new PsdLoadOptions()
            {
                LoadEffectsResource = true,
            };

            using (var psdImage = (PsdImage)Image.Load(sourceFile, loadOptions))
            {
                // Example has 2 group layers with effects
                // Group layer with one effect
                LayerGroup layerGroupOne = (LayerGroup)psdImage.Layers[2];

                // Group layer with many effects
                LayerGroup layerGroupMany = (LayerGroup)psdImage.Layers[5];

                // Get the number of effects and verify their quantity
                int effectCountOne = layerGroupOne.BlendingOptions.Effects.Length;
                int effectCountMany = layerGroupMany.BlendingOptions.Effects.Length;

                // One effect in the group layer is in resource 'IfxsResource'
                IfxsResource ifxsResource = (IfxsResource)layerGroupOne.Resources[0];

                // Two or more effects in a group layer are in resource 'ImfxResource'
                ImfxResource imfxResource = (ImfxResource)layerGroupMany.Resources[0];

                // Add a third shadow to a group layer with multiple effects
                layerGroupMany.BlendingOptions.AddDropShadow();

                psdImage.Save(outputFile);
            }

            //ExEnd:SupportOfIfxsResource

            File.Delete(outputFile);

            Console.WriteLine("SupportOfIfxsResource executed successfully");
        }
    }
}