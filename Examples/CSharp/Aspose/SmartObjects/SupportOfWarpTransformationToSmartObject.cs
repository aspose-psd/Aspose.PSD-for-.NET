using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    public class SupportOfWarpTransformationToSmartObject
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfWarpTransformationToSmartObject
            //ExSummary:The following code demonstrates the Warp effect rendering.

            string sourceFile = Path.Combine(baseDir, "source.psd");
            string pngWarpedExport = Path.Combine(outputDir, "warped.png");
            string psdWarpedExport = Path.Combine(outputDir, "warpFile.psd");

            var warpLoadOptions = new PsdLoadOptions() { AllowWarpRepaint = true };

            using (var image = (PsdImage)Image.Load(sourceFile, warpLoadOptions))
            {
                image.Save(pngWarpedExport, new PngOptions());
                image.Save(psdWarpedExport, new PsdOptions());
            }

            //ExEnd:SupportOfWarpTransformationToSmartObject

            File.Delete(pngWarpedExport);
            File.Delete(psdWarpedExport);

            Console.WriteLine("SupportOfWarpTransformationToSmartObject executed successfully");
        }
    }
}