using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Animation
{
    public class SupportExportToGifImage
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportExportToGifImage
            //ExSummary:The following code demonstrates the support of export Timeline to a Gif image.
            
            string sourceFile = Path.Combine(baseDir, "4GIF_animated.psd");
            string outputGif = Path.Combine(outputDir, "out_4_animated.psd.gif");

            using (var psdImage = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions() { LoadEffectsResource = true }))
            {
                psdImage.Timeline.Save(outputGif, new GifOptions());
            }
            
            //ExEnd:SupportExportToGifImage

            File.Delete(outputGif);

            Console.WriteLine("SupportExportToGifImage executed successfully");
        }
    }
}