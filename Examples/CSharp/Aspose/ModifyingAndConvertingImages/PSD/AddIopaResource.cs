using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddIopaResource
    {
        public static void Run()
        {
            //ExStart:AddIopaResource
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir+ "FillOpacitySample.psd";
            string exportPath = dataDir+ "FillOpacitySampleChanged.psd";

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
