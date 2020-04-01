using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.ImageOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ImplementPatternFillLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ImplementPatternFillLayer
            string sourceFile = dataDir + "PatternFillLayer.psd";
            string destName = dataDir + "PatternFillLayer_out.psd";

            // Load an existing image into an instance of PsdImage class
            using (var image = (PsdImage)Image.Load(sourceFile))
            {
                foreach (var layer in image.Layers)
                {
                    if (layer is FillLayer)
                    {
                        var fillLayer = (FillLayer)layer;
                        var settings = (IPatternFillSettings)fillLayer.FillSettings;
                        settings.HorizontalOffset = -5;
                        settings.VerticalOffset = 12;
                        settings.Scale = 300;
                        settings.Linked = true;
                        settings.PatternData = new int[]
                                                   {
                                            Color.Black.ToArgb(), Color.Red.ToArgb(),
                                            Color.Green.ToArgb(), Color.Blue.ToArgb(),
                                            Color.White.ToArgb(), Color.AliceBlue.ToArgb(),
                                            Color.Violet.ToArgb(), Color.Chocolate.ToArgb(),
                                            Color.IndianRed.ToArgb(), Color.DarkOliveGreen.ToArgb(),
                                            Color.CadetBlue.ToArgb(), Color.YellowGreen.ToArgb(),
                                            Color.Black.ToArgb(), Color.Azure.ToArgb(),
                                            Color.ForestGreen.ToArgb(), Color.Sienna.ToArgb(),
                                                   };

                        settings.PatternHeight = 4;
                        settings.PatternWidth = 4;

                        settings.PatternName = "$$$/Presets/Patterns/ColorfulSquare=Colorful Square New\0";
                        settings.PatternId = Guid.NewGuid().ToString() + "\0";

                        fillLayer.Update();
                        break;
                    }
                }

                image.Save(destName, new PsdOptions(image));
            }
            //ExEnd:ImplementPatternFillLayer

        }
    }
}
