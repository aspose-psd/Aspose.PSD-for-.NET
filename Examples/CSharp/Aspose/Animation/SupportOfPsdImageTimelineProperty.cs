using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.Animation;

namespace Aspose.PSD.Examples.Aspose.Animation
{
    public class SupportOfPsdImageTimelineProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfPsdImageTimelineProperty
            //ExSummary:The following code demonstrates a new approach to work with the Timeline.
            
            string sourceFile = Path.Combine(baseDir, "4_animated.psd");
            string outputFile = Path.Combine(outputDir, "output_edited.psd");

            using (var psdImage = (PsdImage)Image.Load(sourceFile))
            {
                Timeline timeline = psdImage.Timeline;
    
                // Add one more frame
                List<Frame> frames = new List<Frame>(timeline.Frames);
                frames.Add(new Frame());
                timeline.Frames = frames.ToArray();

                timeline.SwitchActiveFrame(4);

                psdImage.Save(outputFile);
            }
            
            //ExEnd:SupportOfPsdImageTimelineProperty

            File.Delete(outputFile);

            Console.WriteLine("SupportOfPsdImageTimelineProperty executed successfully");
        }
    }
}