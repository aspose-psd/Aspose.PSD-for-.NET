using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    public class SupportOfAreEffectsEnabledProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfAreEffectsEnabledProperty
            //ExSummary:Demonstrates how to enable or disable layer effects using AreEffectsEnabled property.

            string srcFile = Path.Combine(baseDir, "2485.psd");
            string outputOnFile = Path.Combine(outputDir, "on_2485.png");
            string outputOffFile = Path.Combine(outputDir, "off_2485.png");

            using (var psdImage = (PsdImage)Image.Load(srcFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                psdImage.Save(outputOnFile);

                psdImage.Layers[1].BlendingOptions.AreEffectsEnabled = false;

                psdImage.Save(outputOffFile);
            }

            //ExEnd:SupportOfAreEffectsEnabledProperty

            File.Delete(outputOnFile);
            File.Delete(outputOffFile);

            Console.WriteLine("SupportOfAreEffectsEnabledProperty executed successfully");
        }
    }
}
