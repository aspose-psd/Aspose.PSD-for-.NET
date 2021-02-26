using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    class SupportOfReplaceContentsInSmartObjects
    {
        public static void Run()
        {
            //ExStart:SupportOfReplaceContentsInSmartObjects

            // This example demonstrates that the ReplaceContents method works correctly when the new content file has a different resolution.

            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            string fileName = "CommonPsb.psd";
            string filePath = SourceDir + fileName; // original PSD image
            string newContentPath = SourceDir + "image.jpg"; // the new content file for the smart object
            string outputFilePath = OutputDir + "ChangedPsd";
            string pngOutputPath = outputFilePath + ".png"; // the output PNG file
            string psdOutputPath = outputFilePath + ".psd"; // the output PSD file
            using (PsdImage psd = (PsdImage)Image.Load(filePath))
            {
                for (int i = 0; i < psd.Layers.Length; i++)
                {
                    var layer = psd.Layers[i];
                    SmartObjectLayer smartObjectLayer = layer as SmartObjectLayer;
                    if (smartObjectLayer != null)
                    {
                        smartObjectLayer.ReplaceContents(newContentPath);

                        psd.Save(psdOutputPath);
                        psd.Save(pngOutputPath, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            //ExEnd:SupportOfReplaceContentsInSmartObjects

            File.Delete(psdOutputPath);
            File.Delete(pngOutputPath);

            Console.WriteLine("SupportOfReplaceContentsInSmartObjects executed successfully");
        }
    }
}
