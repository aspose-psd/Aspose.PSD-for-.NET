using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ColorBalanceAdjustment
    {
        public static void Run() {

            //ExStart:ColorBalanceAdjustmentLayer
            // Add color overlay layer effect at runtime
            string dataDir = RunExamples.GetDataDir_PSD();


            var filePath = dataDir + "ColorBalance.psd";
            var outputPath = dataDir + "ColorBalance_out.psd";
            using (var im = (FileFormats.Psd.PsdImage)Image.Load(filePath))
            {
                foreach (var layer in im.Layers)
                {
                    var cbLayer = layer as ColorBalanceAdjustmentLayer;
                    if (cbLayer != null)
                    {
                        cbLayer.ShadowsCyanRedBalance = 30;
                        cbLayer.ShadowsMagentaGreenBalance = -15;
                        cbLayer.ShadowsYellowBlueBalance = 40;
                        cbLayer.MidtonesCyanRedBalance = -90;
                        cbLayer.MidtonesMagentaGreenBalance = -25;
                        cbLayer.MidtonesYellowBlueBalance = 20;
                        cbLayer.HighlightsCyanRedBalance = -30;
                        cbLayer.HighlightsMagentaGreenBalance = 67;
                        cbLayer.HighlightsYellowBlueBalance = -95;
                        cbLayer.PreserveLuminosity = true;
                    }
                }

                im.Save(outputPath);
            }
            //ExEnd:ColorBalanceAdjustmentLayer


        }
    }
}
