using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.Animation;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;

namespace Aspose.PSD.Examples.Aspose.Animation
{
    public class SupportOfLayerStateEffects
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfLayerStateEffects
            //ExSummary:The following code demonstrates support of effects in Timeline frames.

            string sourceFile = Path.Combine(baseDir, "4_animated.psd");
            string outputFile = Path.Combine(outputDir, "output.psd");

            using (var psdImage = (PsdImage)Image.Load(sourceFile))
            {
                TimeLine timeLine = TimeLine.InitializeFrom(psdImage);
                int[] layerIds = timeLine.LayerIds;

                var layerStateEffects11 = timeLine.Frames[1].LayerStates[layerIds[1]].StateEffects;

                layerStateEffects11.AddDropShadow();
                layerStateEffects11.AddGradientOverlay();

                var layerStateEffects21 = timeLine.Frames[2].LayerStates[layerIds[1]].StateEffects;
                layerStateEffects21.AddStroke(FillType.Color);
                layerStateEffects21.IsVisible = false;

                timeLine.ApplyTo(psdImage);

                psdImage.Save(outputFile);
            }

            //ExEnd:SupportOfLayerStateEffects

            File.Delete(outputFile);

            Console.WriteLine("SupportOfLayerStateEffects executed successfully");
        }
    }
}