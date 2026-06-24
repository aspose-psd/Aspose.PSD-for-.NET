using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfGrdmResourcePsdVersionProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfGrdmResourcePsdVersionProperty
            //ExSummary:The following code demonstrates the specific behaviour of version in GrdmResource.
            
            string sourceFile = Path.Combine(baseDir, "Grdm_Classic.psd");
            string outputFilePsd = Path.Combine(outputDir, "output_Grdm_Smooth.psd");
            string outputFilePng = Path.Combine(outputDir, "output_Grdm_Smooth.png");
            
            using (var img = (PsdImage)PsdImage.Load(sourceFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                GradientMapLayer gradientMapLayer = img.Layers[4] as GradientMapLayer;
                GradientMapSettings gradientSettings = gradientMapLayer.GradientSettings;
                GrdmResource grdmResource = gradientMapLayer.Resources[0] as GrdmResource;
            
                AssertAreEqual(1, grdmResource.PsdVersion);
            
                gradientSettings.InterpolationMethod = InterpolationMethod.Smooth;
                gradientMapLayer.Update();
            
                img.Save(outputFilePsd);
                img.Save(outputFilePng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }
            
            using (var img = (PsdImage)PsdImage.Load(outputFilePsd, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                GradientMapLayer gradientMapLayer = img.Layers[4] as GradientMapLayer;
                GrdmResource grdmResource = gradientMapLayer.Resources[0] as GrdmResource;
            
                AssertAreEqual(3, grdmResource.PsdVersion);
            }
            
            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportOfGrdmResourcePsdVersionProperty

            File.Delete(outputFilePsd);
            File.Delete(outputFilePng);

            Console.WriteLine("SupportOfGrdmResourcePsdVersionProperty executed successfully");
        }
    }
}