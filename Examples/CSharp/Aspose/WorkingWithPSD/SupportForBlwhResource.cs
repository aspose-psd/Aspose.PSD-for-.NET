using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    class SupportForBlwhResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:1
            const string ActualPropertyValueIsWrongMessage = "Expected property value is not equal to actual value";
            void AssertIsTrue(bool condition, string message)
            {
                if (!condition)
                {
                    throw new FormatException(message);
                }
            }

            void ExampleSupportOfBlwhResource(
                string sourceFileName,
                int reds,
                int yellows,
                int greens,
                int cyans,
                int blues,
                int magentas,
                bool useTint,
                int bwPresetKind,
                string bwPresetFileName,
                double tintColorRed,
                double tintColorGreen,
                double tintColorBlue,
                int tintColor,
                int newTintColor)
            {
                string destinationFileName = OutputDir + "Output_" + sourceFileName;
                bool isRequiredResourceFound = false;
                using (PsdImage im = (PsdImage)Image.Load(SourceDir + sourceFileName))
                {
                    foreach (var layer in im.Layers)
                    {
                        foreach (var layerResource in layer.Resources)
                        {
                            if (layerResource is BlwhResource)
                            {
                                var blwhResource = (BlwhResource)layerResource;
                                var blwhLayer = (BlackWhiteAdjustmentLayer)layer;
                                isRequiredResourceFound = true;

                                AssertIsTrue(blwhResource.Reds == reds, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Yellows == yellows, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Greens == greens, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Cyans == cyans, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Blues == blues, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Magentas == magentas, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.UseTint == useTint, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.TintColor == tintColor, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.BwPresetKind == bwPresetKind, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.BlackAndWhitePresetFileName == bwPresetFileName, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(Math.Abs(blwhLayer.TintColorRed - tintColorRed) < 1e-6, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(Math.Abs(blwhLayer.TintColorGreen - tintColorGreen) < 1e-6, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(Math.Abs(blwhLayer.TintColorBlue - tintColorBlue) < 1e-6, ActualPropertyValueIsWrongMessage);

                                // Test editing and saving
                                blwhResource.Reds = reds - 15;
                                blwhResource.Yellows = yellows - 15;
                                blwhResource.Greens = greens + 15;
                                blwhResource.Cyans = cyans + 15;
                                blwhResource.Blues = blues - 15;
                                blwhResource.Magentas = magentas - 15;
                                blwhResource.UseTint = !useTint;
                                blwhResource.BwPresetKind = 4;
                                blwhResource.BlackAndWhitePresetFileName = "bwPresetFileName";
                                blwhLayer.TintColorRed = tintColorRed - 60;
                                blwhLayer.TintColorGreen = tintColorGreen - 60;
                                blwhLayer.TintColorBlue = tintColorBlue - 60;

                                im.Save(destinationFileName);
                                break;
                            }
                        }
                    }
                }

                AssertIsTrue(isRequiredResourceFound, "The specified BlwhResource not found");
                isRequiredResourceFound = false;

                using (PsdImage im = (PsdImage)Image.Load(destinationFileName))
                {
                    foreach (var layer in im.Layers)
                    {
                        foreach (var layerResource in layer.Resources)
                        {
                            if (layerResource is BlwhResource)
                            {
                                var blwhResource = (BlwhResource)layerResource;
                                var blwhLayer = (BlackWhiteAdjustmentLayer)layer;
                                isRequiredResourceFound = true;

                                AssertIsTrue(blwhResource.Reds == reds - 15, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Yellows == yellows - 15, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Greens == greens + 15, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Cyans == cyans + 15, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Blues == blues - 15, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.Magentas == magentas - 15, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.UseTint == !useTint, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.TintColor == newTintColor, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.BwPresetKind == 4, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(blwhResource.BlackAndWhitePresetFileName == "bwPresetFileName", ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(Math.Abs(blwhLayer.TintColorRed - tintColorRed + 60) < 1e-6, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(Math.Abs(blwhLayer.TintColorGreen - tintColorGreen + 60) < 1e-6, ActualPropertyValueIsWrongMessage);
                                AssertIsTrue(Math.Abs(blwhLayer.TintColorBlue - tintColorBlue + 60) < 1e-6, ActualPropertyValueIsWrongMessage);

                                break;
                            }
                        }
                    }
                }

                AssertIsTrue(isRequiredResourceFound, "The specified BlwhResource not found");
            }

            ExampleSupportOfBlwhResource(
                "BlackWhiteAdjustmentLayerStripesMask.psd",
                0x28,
                0x3c,
                0x28,
                0x3c,
                0x14,
                0x50,
                false,
                1,
                "\0",
                225.00045776367188,
                211.00067138671875,
                179.00115966796875,
                -1977421,
                -5925001);

            ExampleSupportOfBlwhResource(
                "BlackWhiteAdjustmentLayerStripesMask2.psd",
                0x80,
                0x40,
                0x20,
                0x10,
                0x08,
                0x04,
                true,
                4,
                "\0",
                239.996337890625,
                127.998046875,
                63.9990234375,
                -1015744,
                -4963324);
            //ExEnd:1

            Console.WriteLine("SupportForBlwhResource executed successfully");
        }
    }
}
