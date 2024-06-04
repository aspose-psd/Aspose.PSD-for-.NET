using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    public class PixelDataManipulation
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:PixelDataManipulation
            // Define input and output file paths
            string inputFile = Path.Combine(baseDir, "input.psd");
            string outputFile = Path.Combine(outputDir, "output.psd");
   
            // Open the input file as a stream
            using (FileStream stream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            {
                // Load the PSD image
                using (PsdImage psdImage = (PsdImage)Image.Load(stream))
                {
                    // Create a new layer and add it to the PSD image
                    Layer layer = new Layer(psdImage);
                    psdImage.AddLayer(layer);
   
                    // Manipulate the pixel data
                    int[] pixels = layer.LoadArgb32Pixels(layer.Bounds);
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        if (i % 5 == 0)
                        {
                            pixels[i] = 0xFF0000; // Example manipulation
                        }
                    }
                    layer.SaveArgb32Pixels(layer.Bounds, pixels);
   
                    // Save the PSD image
                    psdImage.Save(outputFile);
                }
            }
            //ExEnd:PixelDataManipulation

            File.Delete(outputFile);

            Console.WriteLine("PixelDataManipulation executed successfully");
        }
    }
}