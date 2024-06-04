using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Core.Blending;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartFilters;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;

namespace Aspose.PSD.Examples.Aspose.SmartFilters
{
    public class ManipulatingSmartFiltersInSmartObjects
    {
        public static void Run()
        {
            // The path to the document's directory.
            string sourceDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:ManipulatingSmartFiltersInSmartObjects
            string source = Path.Combine(sourceDir, "r2_SmartFilters.psd");
            string outputOriginal = Path.Combine(outputDir, "original_smart_features.psd");
            string outputUpdated = Path.Combine(outputDir, "output_updated_features.psd");

            using (PsdImage im = (PsdImage)Image.Load(source))
            {
                im.Save(outputOriginal);
                SmartObjectLayer smartObj = (SmartObjectLayer)im.Layers[1];

                // Edit smart filters
                GaussianBlurSmartFilter gaussianBlur = (GaussianBlurSmartFilter)smartObj.SmartFilters.Filters[0];

                // Update filter values including blend mode
                gaussianBlur.Radius = 1;
                gaussianBlur.BlendMode = BlendMode.Divide;
                gaussianBlur.Opacity = 75;
                gaussianBlur.IsEnabled = false;

                // Working with Add Noise Smart Filter
                AddNoiseSmartFilter addNoise = (AddNoiseSmartFilter)smartObj.SmartFilters.Filters[1];
                addNoise.Distribution = NoiseDistribution.Uniform;

                // Add new filter items
                List<SmartFilter> filters = new List<SmartFilter>(smartObj.SmartFilters.Filters)
                {
                    new GaussianBlurSmartFilter(),
                    new AddNoiseSmartFilter()
                };
                smartObj.SmartFilters.Filters = filters.ToArray();

                // Apply changes
                smartObj.SmartFilters.UpdateResourceValues();

                // Apply filters directly to layer and mask of layer
                smartObj.SmartFilters.Filters[0].Apply(im.Layers[2]);
                smartObj.SmartFilters.Filters[4].ApplyToMask(im.Layers[2]);

                im.Save(outputUpdated);
            }

            //ExEnd:ManipulatingSmartFiltersInSmartObjects

            File.Delete(outputOriginal);
            File.Delete(outputUpdated);
            
            Console.WriteLine("ManipulatingSmartFiltersInSmartObjects executed successfully");
        }
    }
}