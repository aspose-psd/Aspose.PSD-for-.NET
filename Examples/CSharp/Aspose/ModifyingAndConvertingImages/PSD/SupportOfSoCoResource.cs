using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfSoCoResource
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfSoCoResource

            string sourceFileName = dataDir + "ColorFillLayer.psd";
            string exportPath = dataDir + "SoCoResource_Edited.psd";

            var im = (PsdImage)Image.Load(sourceFileName);

            using (im)
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is FillLayer)
                    {
                        var fillLayer = (FillLayer)layer;
                        foreach (var resource in fillLayer.Resources)
                        {
                            if (resource is SoCoResource)
                            {
                                var socoResource = (SoCoResource)resource;

                                if (socoResource.Color != Color.FromArgb(63, 83, 141))
                                {
                                    throw new Exception("Color from SoCoResource was read wrong");
                                }
                          
                                socoResource.Color = Color.Red;
                                break;
                            }
                        }
                        break;
                    }
                    im.Save(exportPath);
                }
            }

            //ExEnd:SupportOfSoCoResource
        }
    }
}