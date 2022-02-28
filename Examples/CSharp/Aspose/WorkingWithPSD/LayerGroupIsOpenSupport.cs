using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class LayerGroupIsOpenSupport
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:LayerGroupIsOpenSupport
            //ExSummary:The following code shows how to open and close LayerGroup (Folder) using the IsOpen property.

            // Example of reading and writing IsOpen property at runtime.
            string sourceFileName = Path.Combine(baseDir, "LayerGroupOpenClose.psd");
            string outputFileName = Path.Combine(outputDir, "OutputLayerGroupOpenClose.psd");

            using (var image = (PsdImage) Image.Load(sourceFileName))
            {
                foreach (var layer in image.Layers)
                {
                    if (layer is LayerGroup && layer.Name == "Group 1")
                    {
                        bool isOpenedGroup1 = ((LayerGroup) layer).IsOpen;
                        ((LayerGroup) layer).IsOpen = !isOpenedGroup1;
                    }

                    if (layer is LayerGroup && layer.Name == "Group 2")
                    {
                        bool isOpenedGroup2 = ((LayerGroup) layer).IsOpen;
                        ((LayerGroup) layer).IsOpen = !isOpenedGroup2;
                    }
                }

                image.Save(outputFileName);
            }
            
            //ExEnd:LayerGroupIsOpenSupport

            File.Delete(outputFileName);
            
            Console.WriteLine("LayerGroupIsOpenSupport executed successfully");
        }
    }
}