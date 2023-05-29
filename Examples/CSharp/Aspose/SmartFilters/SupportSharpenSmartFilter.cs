using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Core.Blending;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartFilters;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartFilters
{
    public class SupportSharpenSmartFilter
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportSharpenSmartFilter
            //ExSummary:The following code demonstrates support of SharpenSmartFilter.

            string sourceFile = Path.Combine(baseDir, "sharpen_source.psd");
            string outputPsd = Path.Combine(outputDir, "sharpen_output.psd");
            string outputPng = Path.Combine(outputDir, "sharpen_output.png");

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }
            
            using (var image = (PsdImage)Image.Load(sourceFile))
            {
                SmartObjectLayer smartObj = (SmartObjectLayer)image.Layers[1];

                // edit smart filters
                SharpenSmartFilter sharpen = (SharpenSmartFilter)smartObj.SmartFilters.Filters[0];

                // check filter values
                AssertAreEqual(BlendMode.Normal, sharpen.BlendMode);
                AssertAreEqual(100d, sharpen.Opacity);
                AssertAreEqual(true, sharpen.IsEnabled);

                // update filter values
                sharpen.BlendMode = BlendMode.Divide;
                sharpen.Opacity = 75;
                sharpen.IsEnabled = false;

                // add new filter items
                var filters = new List<SmartFilter>(smartObj.SmartFilters.Filters);
                filters.Add(new SharpenSmartFilter());
                smartObj.SmartFilters.Filters = filters.ToArray();

                // apply changes
                smartObj.SmartFilters.UpdateResourceValues();
                smartObj.UpdateModifiedContent();

                image.Save(outputPsd);
                image.Save(outputPng, new PngOptions());
            }
            
            //ExEnd:SupportSharpenSmartFilter

            File.Delete(outputPsd);
            File.Delete(outputPng);

            Console.WriteLine("SupportSharpenSmartFilter executed successfully");
        }
    }
}