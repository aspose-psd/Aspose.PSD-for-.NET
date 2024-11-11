using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    public class SupportOfArtboardLayer
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfArtboardLayer
            //ExSummary:The following code demonstrates the support of export ArtboardLayer as separate images and all in one image.
            
            string srcFile = Path.Combine(baseDir, "artboard2.psd");

            string outFilePng0 = Path.Combine(outputDir, "art0.png");
            string outFilePng1 = Path.Combine(outputDir, "art1.png");
            string outFilePng2 = Path.Combine(outputDir, "art2.png");
            string outFilePng3 = Path.Combine(outputDir, "art3.png");

            using (var psdImage = (PsdImage)Image.Load(srcFile))
            {
                ArtboardLayer art1 = (ArtboardLayer)psdImage.Layers[4];
                ArtboardLayer art2 = (ArtboardLayer)psdImage.Layers[9];
                ArtboardLayer art3 = (ArtboardLayer)psdImage.Layers[14];

                var pngSaveOptions = new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha };
                art1.Save(outFilePng1, pngSaveOptions);
                art2.Save(outFilePng2, pngSaveOptions);
                art3.Save(outFilePng3, pngSaveOptions);

                psdImage.Save(outFilePng0, pngSaveOptions);
            }
            
            //ExEnd:SupportOfArtboardLayer

            Console.WriteLine("SupportOfArtboardLayer executed successfully");
            
            File.Delete(outFilePng0);
            File.Delete(outFilePng1);
            File.Delete(outFilePng2);
            File.Delete(outFilePng3);
        }
    }
}