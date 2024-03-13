using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.FillLayers
{
    public class RotatePatternSupport
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:RotatePatternSupport
            //ExSummary:The following code demonstrates support of Angle property in PtFlResource.
            
            string sourceFile = Path.Combine(baseDir, "PatternFillLayerWide_0.psd");
            string outputFile = Path.Combine(outputDir, "PatternFillLayerWide_0_output.psd");

            using (PsdImage image = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions { LoadEffectsResource = true }))
            {
                FillLayer fillLayer = (FillLayer)image.Layers[1];
                PatternFillSettings fillSettings = (PatternFillSettings)fillLayer.FillSettings;
                fillSettings.Angle = 70;
                fillLayer.Update();
                image.Save(outputFile, new PsdOptions());
            }

            using (PsdImage image = (PsdImage)Image.Load(outputFile, new PsdLoadOptions { LoadEffectsResource = true }))
            {
                FillLayer fillLayer = (FillLayer)image.Layers[1];
                PatternFillSettings fillSettings = (PatternFillSettings)fillLayer.FillSettings;
                AssertAreEqual(70, fillSettings.Angle);
            }
            
            void AssertAreEqual(double expected, double actual)
            {
                if (expected != actual)
                {
                    throw new Exception("Objects are not equal.");
                }
            }

            //ExEnd:RotatePatternSupport
            
            File.Delete(outputFile);

            Console.WriteLine("RotatePatternSupport executed successfully");
        }
    }
}