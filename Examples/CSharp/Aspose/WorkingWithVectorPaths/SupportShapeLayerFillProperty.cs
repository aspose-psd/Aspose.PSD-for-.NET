using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    public class SupportShapeLayerFillProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportShapeLayerFillProperty
            //ExSummary:The following code demonstrates the Fill property of ShapeLayer.

            string srcFile =  Path.Combine(baseDir, "ShapeInternalSolid.psd");
            string outFile = Path.Combine(outputDir, "ShapeInternalSolid.psd.out.psd");

            using (PsdImage image = (PsdImage)Image.Load(
                       srcFile,
                       new PsdLoadOptions { LoadEffectsResource = true }))
            {
                ShapeLayer shapeLayer = (ShapeLayer)image.Layers[1];
                ColorFillSettings fillSettings = (ColorFillSettings)shapeLayer.Fill;
                fillSettings.Color = Color.Red;

                shapeLayer.Update();

                image.Save(outFile);
            }

            // Check saved changes
            using (PsdImage image = (PsdImage)Image.Load(
                       outFile,
                       new PsdLoadOptions { LoadEffectsResource = true }))
            {
                ShapeLayer shapeLayer = (ShapeLayer)image.Layers[1];
                ColorFillSettings fillSettings = (ColorFillSettings)shapeLayer.Fill;

                AssertAreEqual(Color.Red, fillSettings.Color);
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            //ExEnd:SupportShapeLayerFillProperty

            File.Delete(outFile);

            Console.WriteLine("SupportShapeLayerFillProperty executed successfully");
        }
    }
}