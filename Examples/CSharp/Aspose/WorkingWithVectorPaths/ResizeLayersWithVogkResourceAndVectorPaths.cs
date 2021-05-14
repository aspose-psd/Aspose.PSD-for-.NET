using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    class ResizeLayersWithVogkResourceAndVectorPaths
    {
        public static void Run()
        {
            //ExStart:ResizeLayersWithVogkResourceAndVectorPaths

            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            // This example shows how to resize layers with a Vogk and vector path resource in the PSD image
            float scaleX = 0.45f;
            float scaleY = 1.60f;
            string sourceFileName = Path.Combine(SourceDir, "vectorShapes.psd");
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                for (int layerIndex = 1; layerIndex < image.Layers.Length; layerIndex++, scaleX += 0.25f, scaleY -= 0.25f)
                {
                    var layer = image.Layers[layerIndex];
                    var newWidth = (int)Math.Round(layer.Width * scaleX);
                    var newHeight = (int)Math.Round(layer.Height * scaleY);
                    layer.Resize(newWidth, newHeight);

                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
                    string outputName = string.Format("resized_{0}_{1}_{2}", layerIndex, scaleX, scaleY);
                    string outputPath = Path.Combine(OutputDir, outputName + ".psd");
                    string outputPngPath = Path.Combine(OutputDir, outputName + ".png");
                    image.Save(outputPath, new PsdOptions(image));
                    image.Save(outputPngPath, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            Console.WriteLine("ResizeLayersWithVogkResourceAndVectorPaths executed successfully");

            //ExEnd:ResizeLayersWithVogkResourceAndVectorPaths

            string[] outputFiles = Directory.GetFiles(OutputDir, "resized_*", SearchOption.TopDirectoryOnly);
            foreach (var outputFile in outputFiles)
            {
                if (outputFile.EndsWith(".png") || outputFile.EndsWith(".psd"))
                {
                    File.Delete(outputFile);
                }
            }
        }
    }
}
