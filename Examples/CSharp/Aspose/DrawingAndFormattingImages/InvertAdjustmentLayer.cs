using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class InvertAdjustmentLayer
    {
        public static void Run()
        {
            // Add color overlay layer effect at runtime
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:InvertARunExamples.er
            var filePath = dataDir + "InvertStripes_before.psd";
            var outputPath = dataDir + "InvertStripes_after.psd";
            using (var im = (PsdImage)Image.Load(filePath))
            {
                im.AddInvertAdjustmentLayer();
                im.Save(outputPath);
            }
            //ExEnd:InvertAdjustmentLayer


        }
    }
}
