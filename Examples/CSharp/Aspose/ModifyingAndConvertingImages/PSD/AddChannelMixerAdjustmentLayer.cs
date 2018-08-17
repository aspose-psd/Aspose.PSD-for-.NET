using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddChannelMixerAdjustmentLayer
    {
        public static void Run()
        {
            //ExStart:AddChannelMixerAdjustmentLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir+"ChannelMixerAdjustmentLayerRgb.psd";
            string psdPathAfterChange = dataDir+ "ChannelMixerAdjustmentLayerRgbChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is RgbChannelMixerLayer)
                    {
                        var rgbLayer = (RgbChannelMixerLayer)layer;
                        rgbLayer.RedChannel.Blue = 100;
                        rgbLayer.BlueChannel.Green = -100;
                        rgbLayer.GreenChannel.Constant = 50;
                    }
                }

                im.Save(psdPathAfterChange);
            }

            // Cmyk Channel Mixer
            sourceFileName = dataDir+"ChannelMixerAdjustmentLayerCmyk.psd";
            psdPathAfterChange = dataDir + "ChannelMixerAdjustmentLayerCmykChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is CmykChannelMixerLayer)
                    {
                        var cmykLayer = (CmykChannelMixerLayer)layer;
                        cmykLayer.CyanChannel.Black = 20;
                        cmykLayer.MagentaChannel.Yellow = 50;
                        cmykLayer.YellowChannel.Cyan = -25;
                        cmykLayer.BlackChannel.Yellow = 25;
                    }
                }

                im.Save(psdPathAfterChange);
            }


            // Adding the new layer(Cmyk for this example)
            sourceFileName = dataDir+"CmykWithAlpha.psd";
            psdPathAfterChange = dataDir+"ChannelMixerAdjustmentLayerCmykChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                var newlayer = im.AddChannelMixerAdjustmentLayer();
                newlayer.GetChannelByIndex(2).Constant = 50;
                newlayer.GetChannelByIndex(0).Constant = 50;

                im.Save(psdPathAfterChange);
            }
            //ExEnd:AddChannelMixerAdjustmentLayer

        }

    }
}
