using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    class ResizeLayersWithVectorPaths
    {
        public static void Run()
        {
            //ExStart:ResizeLayersWithVectorPaths

            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            string sourceFileName = "vectorShapes.psd";
            string outputFileName = "out_vectorShapes.psd";
            string sourcePath = Path.Combine(SourceDir, sourceFileName);
            string outputPath = Path.Combine(OutputDir, outputFileName);
            string outputPathPng = Path.ChangeExtension(outputPath, ".png");
            using (var psdImage = (PsdImage)Image.Load(sourcePath))
            {
                foreach (var layer in psdImage.Layers)
                {
                    layer.Resize(layer.Width * 5 / 4, layer.Height / 2);
                }

                psdImage.Save(outputPath);
                psdImage.Save(outputPathPng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            Console.WriteLine("ResizeLayersWithVectorPaths executed successfully");

            //ExEnd:ResizeLayersWithVectorPaths

            File.Delete(outputPath);
            File.Delete(outputPathPng);
        }
    }
}
