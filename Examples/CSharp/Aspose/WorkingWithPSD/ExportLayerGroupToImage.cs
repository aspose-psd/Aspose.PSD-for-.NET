using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class ExportLayerGroupToImage
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:ExportLayerGroupToImage
            using (var psdImage = (PsdImage)Image.Load(SourceDir + "ExportLayerGroupToImageSample.psd"))
            {
                // folder with background
                LayerGroup bg_folder = (LayerGroup)psdImage.Layers[0];
                // folder with content
                LayerGroup content_folder = (LayerGroup)psdImage.Layers[4];

                bg_folder.Save(OutputDir + "background.png", new PngOptions());
                content_folder.Save(OutputDir + "content.png", new PngOptions());
            }
            //ExEnd:ExportLayerGroupToImage

            Console.WriteLine("ExportLayerGroupToImage executed successfully");
        }
    }
}
