using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    public class SupportOfReplaceContentsByLink
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfReplaceContentsByLink

            //ExSummary:The following code demonstrates the support of replacing content in many smart objects that have the same source reference.
            
            string srcFile = Path.Combine(baseDir, "2233_Source.psd");
            string replaceAll = Path.Combine(baseDir, "2233_replaceAll.jpg");
            string replaceOne = Path.Combine(baseDir, "2233_replaceOne.jpg");
            string outFileImgAll = Path.Combine(outputDir, "2233_output_All.png");
            string outFileImgOne = Path.Combine(outputDir, "2233_output_one.png");
            
            // This will replace the same context in all smart layers with the same link.
            using (var image = (PsdImage)Image.Load(srcFile))
            {
                var smartObjectLayer = (SmartObjectLayer)image.Layers[1];

                // This will replace the content in all SmartLayers that use the same content.
                smartObjectLayer.ReplaceContents(replaceAll, false);
                smartObjectLayer.UpdateModifiedContent();

                image.Save(outFileImgAll, new PngOptions());
            }
            
            //This will replace the context of only the selected layer, leaving all others with the same context alone.
            using (var image = (PsdImage)Image.Load(srcFile))
            {
                var smartObjectLayer = (SmartObjectLayer)image.Layers[1];

                // It replaces the content in the selected SmartLayer only. 
                smartObjectLayer.ReplaceContents(replaceOne, true);
                smartObjectLayer.UpdateModifiedContent();

                image.Save(outFileImgOne, new PngOptions());
            }
            
            //ExEnd:SupportOfReplaceContentsByLink

            File.Delete(outFileImgAll);
            File.Delete(outFileImgOne);
            Console.WriteLine("SupportOfReplaceContentsByLink executed successfully");
        }
    }
}