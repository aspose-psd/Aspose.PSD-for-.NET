using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;
using Aspose.PSD.FileFormats.Psd.Layers.SmartFilters;
using Aspose.PSD.FileFormats.Psd.Layers.SmartFilters.Rendering;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartFilters
{
    internal class SupportCustomSmartFilterRenderer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            string sourceFile = Path.Combine(SourceDir, "psdnet1057.psd");
            string outputPsd = Path.Combine(OutputDir, "out_psdnet1057.psd");
            string outputPng = Path.Combine(OutputDir, "out_psdnet1057.png");

            CustomSmartFilterExample(sourceFile, outputPsd, outputPng);
            
            Console.WriteLine("SupportCustomSmartFilterRenderer executed successfully");

            File.Delete(outputPsd);
            File.Delete(outputPng);
        }
        
        //ExStart:SupportCustomSmartFilterRenderer
        //ExSummary:The following code shows you how to create a custom smart filter that has a custom renderer.
        
        public static void CustomSmartFilterExample(string sourceFile = "psdnet1057.psd", string outputPsd = "out_psdnet1057.psd", string outputPng = "out_psdnet1057.png")
        {
            // Inits the unsupported 'Crystallize' smart filter at input array
            SmartFilter[] InitUnknownSmartFilters(SmartFilter[] smartFilters)
            {
                // the 'Crystallize' smart filter ID.
                int id = 1131574132;

                for (int i = 0; i < smartFilters.Length; i++)
                {
                    var smartFilter = smartFilters[i];
                    if (smartFilter is UnknownSmartFilter && smartFilter.FilterId == id)
                    {
                        var customSmartFilterInstance = new CustomSmartFilterWithRenderer();
                        customSmartFilterInstance.SourceDescriptor.Structures = smartFilter.SourceDescriptor.Structures;
                        smartFilters[i] = customSmartFilterInstance;
                    }
                }

                return smartFilters;
            }

            using (var image = (PsdImage) Image.Load(sourceFile))
            {
                SmartObjectLayer smartLayer = (SmartObjectLayer) image.Layers[1];
                Layer maskLayer = image.Layers[2];
                Layer regularLayer = image.Layers[3];

                smartLayer.SmartFilters.Filters = InitUnknownSmartFilters(smartLayer.SmartFilters.Filters);
                var smartFilter = smartLayer.SmartFilters.Filters[0];

                // Apply filter to SmartObject
                smartLayer.UpdateModifiedContent();
                smartLayer.SmartFilters.UpdateResourceValues();

                // Apply filter to layer mask
                smartFilter.ApplyToMask(maskLayer);

                //Apply filter to layer
                smartFilter.Apply(regularLayer);

                image.Save(outputPsd);
                image.Save(outputPng, new PngOptions());
            }
        }

        public sealed class CustomSmartFilterWithRenderer : SmartFilter, ISmartFilterRenderer
        {
            public override string Name
            {
                get { return "Custom 'Crystallize' smart filter\0"; }
            }

            public override int FilterId
            {
                // the 'Crystallize' smart filter ID.
                get { return 1131574132; }
            }

            public PixelsData Render(PixelsData pixelsData)
            {
                // get filter structure
                var filterDescriptor = (DescriptorStructure) this.SourceDescriptor.Structures[6];
                // get value of Crystallize Size
                var valueStructure = (IntegerStructure) filterDescriptor.Structures[0];

                for (int i = 0; i < pixelsData.Pixels.Length; i++)
                {
                    if (i % valueStructure.Value == 0)
                    {
                        pixelsData.Pixels[i] = 0;
                    }
                }

                return pixelsData;
            }
        }
        
        //ExEnd:SupportCustomSmartFilterRenderer
    }
}