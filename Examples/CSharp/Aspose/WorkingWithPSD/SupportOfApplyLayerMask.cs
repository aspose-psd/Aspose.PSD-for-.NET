using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    public class SupportOfApplyLayerMask
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfApplyLayerMask
            //ExSummary:The following code demonstrates the feature to apply mask to the layer.

            var sourceFile = Path.Combine(baseDir, "1870_example.psd");
            var outFile =  Path.Combine(outputDir, "export.png");

            using (var psdImage = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions()))
            {
                psdImage.Layers[1].ApplyLayerMask();

                psdImage.Save(outFile, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }

            //ExEnd:SupportOfApplyLayerMask

            File.Delete(outFile);

            Console.WriteLine("SupportOfApplyLayerMask executed successfully");
        }
    }
}
