using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.Gradient;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.LayerEffects;

public class SupportOfGradientPropery
{
    public static void Run()
    {
        // The path to the documents directory.
        string baseDir = RunExamples.GetDataDir_PSD();
        string outputDir = RunExamples.GetDataDir_Output();

        //ExStart:SupportOfGradientPropery
        //ExSummary:Demonstrates reading and modifying noise and solid gradient settings in stroke fill effects.

        string inputFile = Path.Combine(baseDir, "StrokeNoise.psd");
        string outputFile = Path.Combine(outputDir, "output.psd");

        var loadOptions = new PsdLoadOptions() { LoadEffectsResource = true };

        using (PsdImage image = (PsdImage)Image.Load(inputFile, loadOptions))
        {
            var gradientStroke = (StrokeEffect)image.Layers[0].BlendingOptions.Effects[0];
            GradientFillSettings gradientFillSettings = gradientStroke.FillSettings as GradientFillSettings;

            // Check common gradient fill settings properties
            AssertIsNotNull(gradientFillSettings);
            AssertAreEqual(true, gradientFillSettings.AlignWithLayer);
            AssertAreEqual(true, gradientFillSettings.Dither);
            AssertAreEqual(true, gradientFillSettings.Reverse);
            AssertAreEqual(116.0, gradientFillSettings.Angle);
            AssertAreEqual(122, gradientFillSettings.Scale);
            AssertAreEqual(GradientType.Angle, gradientFillSettings.GradientType);

            // Check Noise gradient properties
            NoiseGradient noiseGradient = gradientFillSettings.Gradient as NoiseGradient;
            AssertIsNotNull(noiseGradient);
            AssertAreEqual(GradientKind.Noise, noiseGradient.GradientMode);
            AssertAreEqual(2107422935, noiseGradient.RndNumberSeed);
            AssertAreEqual(false, noiseGradient.ShowTransparency);
            AssertAreEqual(false, noiseGradient.UseVectorColor);
            AssertAreEqual(2048, noiseGradient.Roughness);
            AssertAreEqual(NoiseColorModel.RGB, noiseGradient.ColorModel);
            AssertAreEqual((long)0, noiseGradient.MinimumColor.GetAsLong());
            AssertAreEqual(28147819798528050, noiseGradient.MaximumColor.GetAsLong());

            // Change gradient settings
            gradientFillSettings.AlignWithLayer = false;
            gradientFillSettings.Dither = false;
            gradientFillSettings.Reverse = false;
            gradientFillSettings.Angle = 30;
            gradientFillSettings.Scale = 80;
            gradientFillSettings.GradientType = GradientType.Linear;

            var solidGradient = new SolidGradient();
            solidGradient.Interpolation = 2048;
            solidGradient.ColorPoints[0].RawColor.Components[0].Value = 255; // A
            solidGradient.ColorPoints[0].RawColor.Components[1].Value = 255; // R 
            solidGradient.ColorPoints[0].RawColor.Components[2].Value = 0;   // G
            solidGradient.ColorPoints[0].RawColor.Components[3].Value = 0;   // B
            solidGradient.TransparencyPoints[1].Opacity = 50;
            gradientFillSettings.Gradient = solidGradient;

            image.Save(outputFile);
        }

        // Check saved changes
        using (PsdImage image = (PsdImage)Image.Load(outputFile))
        {
            var gradientStroke = (StrokeEffect)image.Layers[0].BlendingOptions.Effects[0];
            GradientFillSettings gradientFillSettings = gradientStroke.FillSettings as GradientFillSettings;

            // Check common gradient fill settings properties
            AssertIsNotNull(gradientFillSettings);
            AssertAreEqual(false, gradientFillSettings.AlignWithLayer);
            AssertAreEqual(false, gradientFillSettings.Dither);
            AssertAreEqual(false, gradientFillSettings.Reverse);
            AssertAreEqual(30.0, gradientFillSettings.Angle);
            AssertAreEqual(80, gradientFillSettings.Scale);
            AssertAreEqual(GradientType.Linear, gradientFillSettings.GradientType);

            SolidGradient solidGradient = gradientFillSettings.Gradient as SolidGradient;
            AssertIsNotNull(solidGradient);
            AssertAreEqual((short)2048, solidGradient.Interpolation);
            AssertAreEqual(
                (ulong)255,
                solidGradient.ColorPoints[0].RawColor.Components[0].Value);
            AssertAreEqual(
                (ulong)255,
                solidGradient.ColorPoints[0].RawColor.Components[1].Value);
            AssertAreEqual(
                (ulong)0,
                solidGradient.ColorPoints[0].RawColor.Components[2].Value);
            AssertAreEqual(
                (ulong)0,
                solidGradient.ColorPoints[0].RawColor.Components[3].Value);
            AssertAreEqual(50.0, solidGradient.TransparencyPoints[1].Opacity);
        }

        void AssertAreEqual(object expected, object actual, string message = null)
        {
            if (!object.Equals(expected, actual))
            {
                throw new Exception(message ?? "Objects are not equal.");
            }
        }

        void AssertIsNotNull(object actual)
        {
            if (actual == null)
            {
                throw new Exception("Object is null.");
            }
        }

        //ExEnd:SupportOfGradientPropery

        File.Delete(outputFile);

        Console.WriteLine("SupportOfGradientPropery executed successfully");
    }

}
