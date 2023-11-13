using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfBlendClippedElementsProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfBlendClippedElementsProperty
            //ExSummary:The following code demonstrates support of BlendClippedElements property.
            
            string sourceFile = Path.Combine(baseDir, "example_source.psd");
            string outputPsd = Path.Combine(outputDir, "example_output.psd");
            string outputPng = Path.Combine(outputDir, "example_output.png");

            using (var image = (PsdImage)Image.Load(sourceFile))
            {
                image.Layers[1].BlendClippedElements = false;
                image.Save(outputPsd);
                image.Save(outputPng, new PngOptions());
            }

            //ExEnd:SupportOfBlendClippedElementsProperty

            File.Delete(outputPsd);
            File.Delete(outputPng);

            Console.WriteLine("SupportOfBlendClippedElementsProperty executed successfully");
        }
    }
}