using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfSelectiveColorAdjustmentLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfSelectiveColorAdjustmentLayer
            //ExSummary:The following code demonstrates the support of SelectiveColorLayer adjustment layer.

            string sourceFileWithSelectiveColorLayer = Path.Combine(baseDir, "houses_selectiveColor_source.psd");
            string outputPsdWithSelectiveColorLayer = Path.Combine(outputDir, "houses_selectiveColor_output.psd");
            string outputPngWithSelectiveColorLayer = Path.Combine(outputDir, "houses_selectiveColor_output.png");

            string sourceFileWithoutSelectiveColorLayer = Path.Combine(baseDir, "houses_source.psd");
            string outputPsdWithoutSelectiveColorLayer = Path.Combine(outputDir, "houses_output.psd");
            string outputPngWithoutSelectiveColorLayer = Path.Combine(outputDir, "houses_output.png");

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }

            // Get, check, and change the Selective Color adjustment layer from the image.
            using (var image = (PsdImage)Image.Load(sourceFileWithSelectiveColorLayer))
            {
                foreach (var layer in image.Layers)
                {
                    if (layer is SelectiveColorLayer)
                    {
                        // Get Selective Color adjustment layer.
                        SelectiveColorLayer selcLayer = (SelectiveColorLayer)layer;
                        var redCorrection = selcLayer.GetCmykCorrection(SelectiveColorsTypes.Reds);
                        var yellowCorrection = selcLayer.GetCmykCorrection(SelectiveColorsTypes.Yellows);
                        var greenCorrection = selcLayer.GetCmykCorrection(SelectiveColorsTypes.Greens);
                        var blueCorrection = selcLayer.GetCmykCorrection(SelectiveColorsTypes.Blues);

                        // Check layers parameters.
                        AssertAreEqual(CorrectionMethodTypes.Absolute, selcLayer.CorrectionMethod);

                        AssertAreEqual(redCorrection.Cyan, (short)-31);
                        AssertAreEqual(redCorrection.Magenta, (short)-12);
                        AssertAreEqual(redCorrection.Yellow, (short)27);
                        AssertAreEqual(redCorrection.Black, (short)33);

                        AssertAreEqual(yellowCorrection.Cyan, (short)-22);
                        AssertAreEqual(yellowCorrection.Magenta, (short)-19);
                        AssertAreEqual(yellowCorrection.Yellow, (short)8);
                        AssertAreEqual(yellowCorrection.Black, (short)0);

                        AssertAreEqual(greenCorrection.Cyan, (short)0);
                        AssertAreEqual(greenCorrection.Magenta, (short)0);
                        AssertAreEqual(greenCorrection.Yellow, (short)0);
                        AssertAreEqual(greenCorrection.Black, (short)0);

                        AssertAreEqual(blueCorrection.Cyan, (short)58);
                        AssertAreEqual(blueCorrection.Magenta, (short)18);
                        AssertAreEqual(blueCorrection.Yellow, (short)1);
                        AssertAreEqual(blueCorrection.Black, (short)7);

                        // Change layers parameters.
                        selcLayer.CorrectionMethod = CorrectionMethodTypes.Relative;
                        selcLayer.SetCmykCorrection(SelectiveColorsTypes.Reds,
                            new CmykCorrection { Cyan = 12, Magenta = -20, Yellow = 10, Black = -15 });
                        selcLayer.SetCmykCorrection(SelectiveColorsTypes.Whites,
                            new CmykCorrection { Cyan = 15, Magenta = 20, Yellow = -75, Black = 42 });

                        image.Save(outputPsdWithSelectiveColorLayer);
                        image.Save(outputPngWithSelectiveColorLayer, new PngOptions());
                    }
                }
            }

            // Add and set the Selective color adjustment layer to the image.
            using (var image = (PsdImage)Image.Load(sourceFileWithoutSelectiveColorLayer))
            {
                // Add Selective Color Adjustment layer.
                SelectiveColorLayer selectiveColorLayer = image.AddSelectiveColorAdjustmentLayer();

                // Set layers parameters.
                selectiveColorLayer.CorrectionMethod = CorrectionMethodTypes.Absolute;
                selectiveColorLayer.SetCmykCorrection(SelectiveColorsTypes.Whites,
                    new CmykCorrection { Cyan = 100, Magenta = -100, Yellow = 100, Black = 0 });
                selectiveColorLayer.SetCmykCorrection(SelectiveColorsTypes.Blacks,
                    new CmykCorrection { Cyan = 10, Magenta = 15, Yellow = 17, Black = -3 });
                selectiveColorLayer.SetCmykCorrection(SelectiveColorsTypes.Neutrals,
                    new CmykCorrection { Cyan = 45, Magenta = 21, Yellow = -14, Black = 0 });
                selectiveColorLayer.SetCmykCorrection(SelectiveColorsTypes.Magentas,
                    new CmykCorrection { Cyan = 8, Magenta = -10, Yellow = -14, Black = 25 });

                image.Save(outputPsdWithoutSelectiveColorLayer);
                image.Save(outputPngWithoutSelectiveColorLayer, new PngOptions());
            }
            
            //ExEnd:SupportOfSelectiveColorAdjustmentLayer

            File.Delete(outputPsdWithSelectiveColorLayer);
            File.Delete(outputPngWithSelectiveColorLayer);
            File.Delete(outputPsdWithoutSelectiveColorLayer);
            File.Delete(outputPngWithoutSelectiveColorLayer);

            Console.WriteLine("SupportOfSelectiveColorAdjustmentLayer executed successfully");
        }
    }
}