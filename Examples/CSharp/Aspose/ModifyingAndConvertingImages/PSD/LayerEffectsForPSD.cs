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
    class LayerEffectsForPSD
    {
        public static void Run()
        {
            //ExStart:LayerEffectsForPSD
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir+ "LayerWithText.psd";
            string exportPath = dataDir+ "LayerEffectsForPSD.png";

            using (PsdImage image =(PsdImage)Image.Load(sourceFileName,new ImageLoadOptions.PsdLoadOptions()
              {
                  LoadEffectsResource = true,
                  UseDiskForLoadEffectsResource = true
              }))
            {
                image.Save(exportPath,
                            new ImageOptions.PngOptions()
                            {
                                ColorType =
                                        FileFormats.Png
                                        .PngColorType
                                        .TruecolorWithAlpha
                            });
            }

            //ExEnd:LayerEffectsForPSD

        }

    }
}
