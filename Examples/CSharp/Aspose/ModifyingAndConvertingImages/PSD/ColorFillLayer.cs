using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ColorFillLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ColorFillLayer

            string sourceFileName = dataDir + "ColorFillLayer.psd";
            string exportPath = dataDir + "ColorFillLayer_output.psd";

            var im = (PsdImage)Image.Load(sourceFileName);

            using (im)
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is FillLayer)
                    {
                        var fillLayer = (FillLayer)layer;

                        if (fillLayer.FillSettings.FillType != FillType.Color)
                        {
                            throw new Exception("Wrong Fill Layer");
                        }

                        var settings = (IColorFillSettings)fillLayer.FillSettings;

                        settings.Color = Color.Red;
                        fillLayer.Update();
                        im.Save(exportPath);
                        break;
                    }
                }
            }

            //ExEnd:ColorFillLayer

        }
    }
}
