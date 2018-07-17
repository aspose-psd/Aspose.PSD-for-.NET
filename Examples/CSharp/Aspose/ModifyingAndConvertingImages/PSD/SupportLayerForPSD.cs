using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportLayerForPSD
    {
        public static void Run()
        {
            //ExStart:SupportLayerForPSD
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir+"layers.psd";
            string output = dataDir+"layers.png";

            using (PsdImage image =(PsdImage)Image.Load(sourceFileName,
                                        new ImageLoadOptions.PsdLoadOptions()
                                        {
                                            LoadEffectsResource = true,
                                            UseDiskForLoadEffectsResource = true
                                        }))
            {
                Debug.Assert(image.Layers[2] != null, "Layer with effects resource was not recognized");

                image.Save(output, new ImageOptions.PngOptions()
                {
                    ColorType =
                                            FileFormats.Png
                                            .PngColorType
                                            .TruecolorWithAlpha
                });
            }

            //ExEnd:SupportLayerForPSD
        }
    }
}
