using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class ChangingGroupVisibility
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart
            //ExSummary:The following example demonstrates how you can change LayerGroup visibility in Aspose.PSD
            string sourceFilePath = baseDir + "apple.psd";
            string outputFilePath = outputDir + "apple_with_hidden_gorup_output.psd";

            // make changes in layer names and save it
            using (var image = (PsdImage)Image.Load(sourceFilePath))
            {
                for (int i = 0; i < image.Layers.Length; i++)
                {
                    var layer = image.Layers[i];

                    // Turn off everything inside a group
                    if (layer is LayerGroup)
                    {
                        layer.IsVisible = false;
                    }
                }

                image.Save(outputFilePath);
            }

            //ExEnd
        }
    }
}