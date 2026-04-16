using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfInterpolationMethodEnum
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfInterpolationMethodEnum
            //ExSummary:The following code demonstrates the support of gradient rendering with Smooth method.
            
            string sourceFile = Path.Combine(baseDir, "Fill_Layer.psd");
            string outputFile = Path.Combine(outputDir, "output_Fill_Layer.psd");
            string outputFilePng = Path.Combine(outputDir, "output_Fill_Layer.png");
            
            var srcMethod = InterpolationMethod.Linear;
            var newMethod = InterpolationMethod.Classic;
            
            var opt = new PsdLoadOptions()
            {
                LoadEffectsResource = true,
            };
            
            using (var image = (PsdImage)Image.Load(sourceFile, opt))
            {
                // Read
                var fillLayer = image.Layers[1] as FillLayer;
                var gradientSettings = fillLayer.FillSettings as GradientFillSettings;
                AssertAreEqual(srcMethod, gradientSettings.InterpolationMethod);
            
                // Change
                gradientSettings.InterpolationMethod = newMethod;
                fillLayer.Update();
            
                image.Save(outputFile);
                image.Save(outputFilePng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }
            
            // Check saved data
            using (var image = (PsdImage)Image.Load(outputFile, opt))
            {
                var fillLayer = image.Layers[1] as FillLayer;
                var gradientSettings = fillLayer.FillSettings as GradientFillSettings;
                var gdflResource = fillLayer.Resources[0] as GdFlResource;
            
                AssertAreEqual(newMethod, gradientSettings.InterpolationMethod);
                AssertAreEqual(newMethod, gdflResource.InterpolationMethod);
            }
            
            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportOfInterpolationMethodEnum

            File.Delete(outputFile);
            File.Delete(outputFilePng);

            Console.WriteLine("SupportOfInterpolationMethodEnum executed successfully");
        }
    }
}