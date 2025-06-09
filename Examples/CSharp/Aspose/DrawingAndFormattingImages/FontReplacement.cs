using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff.Enums;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class FontReplacement
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();
            string outputFolder = RunExamples.GetDataDir_Output();

            //ExStart:FontReplacement

            string sourceFileName = Path.Combine(dataDir, "sample_konstanting.psd");

            string[] outputs = new string[]
            {
                "replacedfont0.tiff",
                "replacedfont1.png",
                "replacedfont2.jpg"
            };

            using (PsdImage image = (PsdImage)Image.Load(sourceFileName, new PsdLoadOptions() { AllowNonChangedLayerRepaint = true }))
            {
                // This way you can use different fonts for different outputs 
                image.Save(Path.Combine(outputFolder, outputs[0]), new TiffOptions(TiffExpectedFormat.TiffJpegRgb) { DefaultReplacementFont = "Arial" });
                image.Save(Path.Combine(outputFolder, outputs[1]), new PngOptions { DefaultReplacementFont = "Verdana" });
                image.Save(Path.Combine(outputFolder, outputs[2]), new JpegOptions { DefaultReplacementFont = "Times New Roman" });
            }
            //ExEnd:FontReplacement

            Console.WriteLine("FontReplacement executed successfully");
        }
    }
}
