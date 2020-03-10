using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddIopaResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddIopaResource

            string sourceFileName = dataDir + "FillOpacitySample.psd";
            string exportPath = dataDir + "FillOpacitySampleChanged.psd";

            using (var im = (PsdImage)(Image.Load(sourceFileName)))
            {
                var layer = im.Layers[2];

                var resources = layer.Resources;
                foreach (var resource in resources)
                {
                    if (resource is FileFormats.Psd.Layers.LayerResources.IopaResource)
                    {
                        var iopaResource = (IopaResource)resource;
                        iopaResource.FillOpacity = 200;
                    }
                }

                im.Save(exportPath);
            }

            //ExEnd:AddIopaResource

        }

    }
}
