using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
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
            
            string sourceFile = Path.Combine(baseDir, "2701_GradientOverlay.psd");
            string outputFile = Path.Combine(outputDir, "output_GradientOverlay.psd");
            string outputFilePng = Path.Combine(outputDir, "output_GradientOverlay.png");

            var srcMethod = InterpolationMethod.Linear;
            var newMethod = InterpolationMethod.Smooth;

            var opt = new PsdLoadOptions()
            {
                LoadEffectsResource = true,
            };

            using (var image = (PsdImage)Image.Load(sourceFile, opt))
            {
                // Read
                var effect = image.Layers[1].BlendingOptions.Effects[0] as GradientOverlayEffect;
                var gradientSettings = effect.Settings;
                AssertAreEqual(srcMethod, gradientSettings.InterpolationMethod);

                // Change
                gradientSettings.InterpolationMethod = newMethod;

                image.Save(outputFile);
                image.Save(outputFilePng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            // Check saved data
            using (var image = (PsdImage)Image.Load(outputFile, opt))
            {
                var effect = image.Layers[1].BlendingOptions.Effects[0] as GradientOverlayEffect;
                var gradientSettings = effect.Settings;

                AssertAreEqual(newMethod, gradientSettings.InterpolationMethod);
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