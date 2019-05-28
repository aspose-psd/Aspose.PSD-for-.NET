using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class PatternFillLayer
    {
        public static void Run()
        {
            //ExStart:PatternFillLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Add support of Fill layers: Pattern
            string sourceFileName = dataDir +"PatternFillLayer.psd";
            string exportPath =     dataDir +"PatternFillLayer_Edited.psd";
            double tolerance = 0.0001;
            var im = (PsdImage)Image.Load(sourceFileName);
            using (im)
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is FillLayer)
                    {
                        FillLayer fillLayer = (FillLayer)layer;
                        PatternFillSettings fillSettings = (PatternFillSettings)fillLayer.FillSettings;
                        if (fillSettings.HorizontalOffset != -46 ||
                            fillSettings.VerticalOffset != -45 ||
                            fillSettings.PatternId != "a6818df2-7532-494e-9615-8fdd6b7f38e5" ||
                            fillSettings.PatternName != "$$$/Presets/Patterns/OpticalSquares=Optical Squares" ||
                            fillSettings.AlignWithLayer != true ||
                            fillSettings.Linked != true ||
                            fillSettings.PatternHeight != 64 ||
                            fillSettings.PatternWidth != 64 ||
                            fillSettings.PatternData.Length != 4096 ||
                            Math.Abs(fillSettings.Scale - 50) > tolerance)
                        {
                            throw new Exception("PSD Image was read wrong");
                        }
                        // Editing 
                        fillSettings.Scale = 300;
                        fillSettings.HorizontalOffset = 2;
                        fillSettings.VerticalOffset = -20;
                        fillSettings.PatternData = new int[]
                        {
                       Color.Red.ToArgb(), Color.Blue.ToArgb(),  Color.Blue.ToArgb(),
                       Color.Blue.ToArgb(), Color.Red.ToArgb(),  Color.Blue.ToArgb(),
                       Color.Blue.ToArgb(), Color.Blue.ToArgb(),  Color.Red.ToArgb()
                        };
                        fillSettings.PatternHeight = 3;
                        fillSettings.PatternWidth = 3;
                        fillSettings.AlignWithLayer = false;
                        fillSettings.Linked = false;
                        fillSettings.PatternId = Guid.NewGuid().ToString();
                        fillLayer.Update();
                        break;
                    }
                }
                im.Save(exportPath);
            }

            //ExEnd:PatternFillLayer
        }
    }
}
