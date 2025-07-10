using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.Gradient;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.StrokeResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    public class SupportOfShapeLayerRendering
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfShapeLayerRendering
            //ExSummary:The following code demonstrates support rendering of Shape Stroke.
            
            string sourceFile = Path.Combine(baseDir, "StrokeShapeTest.psd");
            string outputFilePsd = Path.Combine(outputDir, "StrokeShapeTest.out.psd");
            string outputFilePng = Path.Combine(outputDir, "StrokeShapeTest.out.png");

            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                Layer layer = image.Layers[1];
                ShapeLayer shapeLayer = (ShapeLayer)image.Layers[1];
                ColorFillSettings fillSettings = (ColorFillSettings)shapeLayer.Fill;
                fillSettings.Color = Color.GreenYellow;
                shapeLayer.Update();

                ShapeLayer shapeLayer2 = (ShapeLayer)image.Layers[3];
                GradientFillSettings gradientSettings = (GradientFillSettings)shapeLayer2.Fill;
                SolidGradient solidGradient = (SolidGradient)gradientSettings.Gradient;
                gradientSettings.Dither = true;
                gradientSettings.Reverse = true;
                gradientSettings.AlignWithLayer = false;
                gradientSettings.Angle = 20;
                gradientSettings.Scale = 50;
                solidGradient.ColorPoints[0].Location = 100;
                solidGradient.ColorPoints[1].Location = 4000;
                solidGradient.TransparencyPoints[0].Location = 200;
                solidGradient.TransparencyPoints[1].Location = 3800;
                solidGradient.TransparencyPoints[0].Opacity = 90;
                solidGradient.TransparencyPoints[1].Opacity = 10;
                shapeLayer2.Update();

                ShapeLayer shapeLayer3 = (ShapeLayer)image.Layers[5];
                StrokeSettings strokeSettings = (StrokeSettings)shapeLayer3.Stroke;
                strokeSettings.Size = 15;
                ColorFillSettings strokeFillSettings = (ColorFillSettings)strokeSettings.Fill;
                strokeFillSettings.Color = Color.GreenYellow;
                shapeLayer3.Update();

                image.Save(outputFilePsd);
                image.Save(outputFilePng, new PngOptions());
            }

            // Check changed data.
            using (PsdImage image = (PsdImage)Image.Load(outputFilePsd))
            {
                ShapeLayer shapeLayer = (ShapeLayer)image.Layers[1];
                ColorFillSettings fillSettings = (ColorFillSettings)shapeLayer.Fill;
                AssertAreEqual(Color.GreenYellow, fillSettings.Color);

                ShapeLayer shapeLayer2 = (ShapeLayer)image.Layers[3];
                GradientFillSettings gradientSettings = (GradientFillSettings)shapeLayer2.Fill;
                SolidGradient solidGradient = (SolidGradient)gradientSettings.Gradient;
                AssertAreEqual(true, gradientSettings.Dither);
                AssertAreEqual(true, gradientSettings.Reverse);
                AssertAreEqual(false, gradientSettings.AlignWithLayer);
                AssertAreEqual(20.0, gradientSettings.Angle);
                AssertAreEqual(50, gradientSettings.Scale);
                AssertAreEqual(100, solidGradient.ColorPoints[0].Location);
                AssertAreEqual(4000, solidGradient.ColorPoints[1].Location);
                AssertAreEqual(200, solidGradient.TransparencyPoints[0].Location);
                AssertAreEqual(3800, solidGradient.TransparencyPoints[1].Location);
                AssertAreEqual(90.0, solidGradient.TransparencyPoints[0].Opacity);
                AssertAreEqual(10.0, solidGradient.TransparencyPoints[1].Opacity);

                ShapeLayer shapeLayer3 = (ShapeLayer)image.Layers[5];
                StrokeSettings strokeSettings = (StrokeSettings)shapeLayer3.Stroke;
                ColorFillSettings strokeFillSettings = (ColorFillSettings)strokeSettings.Fill;
                AssertAreEqual(15.0, strokeSettings.Size);
                AssertAreEqual(Color.GreenYellow, strokeFillSettings.Color);
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportOfShapeLayerRendering

            File.Delete(outputFilePsd);
            File.Delete(outputFilePng);

            Console.WriteLine("SupportOfShapeLayerRendering executed successfully");
        }
    }
}