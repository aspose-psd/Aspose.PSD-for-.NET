using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportOfBritResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseFolder = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfBritResource
            /* This Example demonstrates how you can programmatically change the PSD Image Brightness/Contrast Layer Resource - BritResource
            This is a Low-Level Aspose.PSD API. You can use Brightness/Contrast Layer through its API, which will be much easier, 
            but direct PhotoShop resource editing gives you more control over the PSD file content.  */

            string path = Path.Combine(baseFolder, "BrightnessContrastPS6.psd");
            string outputPath = Path.Combine(outputDir, "BrightnessContrastPS6_output.psd");

            using (PsdImage im = (PsdImage)Image.Load(path))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is BrightnessContrastLayer)
                    {
                        foreach (var layerResource in layer.Resources)
                        {
                            if (layerResource is BritResource)
                            {
                                var resource = (BritResource)layerResource;

                                if (resource.Brightness != -40 ||
                                    resource.Contrast != 10 ||
                                    resource.LabColor != false ||
                                    resource.MeanValueForBrightnessAndContrast != 127)
                                {
                                    throw new Exception("BritResource was read wrong");
                                }

                                // Test editing and saving
                                resource.Brightness = 25;
                                resource.Contrast = -14;
                                resource.LabColor = true;
                                resource.MeanValueForBrightnessAndContrast = 200;
                                im.Save(Path.Combine(outputPath, outputPath), new PsdOptions());
                                break;
                            }
                        }
                    }
                }
            }

            //ExEnd:SupportOfBritResource

            Console.WriteLine("SupportOfBritResource executed successfully");
        }
    }
}
