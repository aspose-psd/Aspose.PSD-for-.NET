using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ManageChannelMixerAdjusmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ManageChannelMixerAdjusmentLayer

            // Rgb Channel Mixer
            string sourceFileName = dataDir + "ChannelMixerAdjustmentLayerRgb.psd";
            string psdPathAfterChange = dataDir + "ChannelMixerAdjustmentLayerRgbChanged.psd";

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

            // Adding the new layer(Cmyk for this example)
            sourceFileName = dataDir + "CmykWithAlpha.psd";
            psdPathAfterChange = dataDir + "ChannelMixerAdjustmentLayerCmykChanged.psd";

            using (var im = (PsdImage)Image.Load(sourceFileName))
            {
                var newlayer = im.AddChannelMixerAdjustmentLayer();
                newlayer.GetChannelByIndex(2).Constant = 50;
                newlayer.GetChannelByIndex(0).Constant = 50;

                im.Save(psdPathAfterChange);
            }

            //ExEnd:ManageChannelMixerAdjusmentLayer
        }
    }
}
