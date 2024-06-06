using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.SmartFilters;

namespace Aspose.PSD.Examples.Aspose.SmartFilters
{
    public class DirectlyApplySmartFilter
    {
        public static void Run()
        {
            // The path to the document's directory.
            string sourceDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:DirectlyApplySmartFilter
            string source = Path.Combine(sourceDir, "sharpen_source.psd");
            string outputUpdated = Path.Combine(outputDir, "output_updated.psd");

            using (PsdImage im = (PsdImage)Image.Load(source))
            {
                SharpenSmartFilter sharpenFilter = new SharpenSmartFilter();
                Layer regularLayer = im.Layers[1];
                for (int i = 0; i < 3; i++)
                {
                    sharpenFilter.Apply(regularLayer);
                }

                im.Save(outputUpdated);
            }

            //ExEnd:DirectlyApplySmartFilter

            File.Delete(outputUpdated);
            
            Console.WriteLine("DirectlyApplySmartFilter executed successfully");
        }
    }
}