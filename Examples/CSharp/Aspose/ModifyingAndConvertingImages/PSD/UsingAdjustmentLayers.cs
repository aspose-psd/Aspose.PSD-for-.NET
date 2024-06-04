using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class UsingAdjustmentLayers
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:UsingAdjustmentLayers

            string sourcePsd = Path.Combine(baseDir, "AllAdjustments.psd");
            string outputOrigPng = Path.Combine(outputDir, "AllAdjustments_orig.png");
            string outputModPng = Path.Combine(outputDir, "AllAdjustments_mod.png");
            PngOptions pngOpt = new PngOptions();
            pngOpt.ColorType = PngColorType.TruecolorWithAlpha;

            using (PsdImage psdImage = (PsdImage)Image.Load(sourcePsd))
            {
                psdImage.Save(outputOrigPng, pngOpt);
                var layers = psdImage.Layers;

                foreach (var layer in layers)
                {
                    if (layer is BrightnessContrastLayer br)
                    {
                        br.Brightness = -br.Brightness;
                        br.Contrast = -br.Contrast;
                    }

                    if (layer is LevelsLayer levels)
                    {
                        levels.MasterChannel.OutputShadowLevel = 30;
                        levels.MasterChannel.InputShadowLevel = 5;
                        levels.MasterChannel.InputMidtoneLevel = 2;
                        levels.MasterChannel.OutputHighlightLevel = 213;
                        levels.MasterChannel.InputHighlightLevel = 120;
                    }

                    if (layer is CurvesLayer curves)
                    {
                        var manager = curves.GetCurvesManager();
                        var curveManager = (CurvesContinuousManager)manager;
                        curveManager.AddCurvePoint(2, 150, 180);
                    }

                    if (layer is ExposureLayer exp)
                    {
                        exp.Exposure += 0.1f;
                    }

                    if (layer is HueSaturationLayer hue)
                    {
                        hue.Hue = -15;
                        hue.Saturation = 30;
                    }

                    if (layer is ColorBalanceAdjustmentLayer colorBal)
                    {
                        colorBal.MidtonesCyanRedBalance = 30;
                    }

                    if (layer is BlackWhiteAdjustmentLayer bw)
                    {
                        bw.Reds = 30;
                        bw.Greens = 25;
                        bw.Blues = 40;
                    }

                    if (layer is PhotoFilterLayer photoFilter)
                    {
                        photoFilter.Color = Color.Azure;
                    }

                    if (layer is ChannelMixerLayer channelMixer)
                    {
                        var channel = channelMixer.GetChannelByIndex(0);
                        if (channel is RgbMixerChannel rgbChannel)
                        {
                            rgbChannel.Green = 120;
                            rgbChannel.Red = 50;
                            rgbChannel.Blue = 70;
                            rgbChannel.Constant += 10;
                        }
                    }

                    if (layer is InvertAdjustmentLayer)
                    {
                        // No actions needed for InvertAdjustmentLayer
                    }

                    if (layer is PosterizeLayer post)
                    {
                        post.Levels = 3;
                    }

                    if (layer is ThresholdLayer threshold)
                    {
                        threshold.Level = 15;
                    }

                    if (layer is SelectiveColorLayer selectiveColor)
                    {
                        var correction = new CmykCorrection
                        {
                            Cyan = 25,
                            Magenta = 10,
                            Yellow = -15,
                            Black = 5
                        };
                        selectiveColor.SetCmykCorrection(SelectiveColorsTypes.Cyans, correction);
                    }
                }

                psdImage.Save(outputModPng, pngOpt);
            }

            //ExEnd:UsingAdjustmentLayers

            File.Delete(outputOrigPng);
            File.Delete(outputModPng);

            Console.WriteLine("UsingAdjustmentLayers executed successfully");
        }
    }
}