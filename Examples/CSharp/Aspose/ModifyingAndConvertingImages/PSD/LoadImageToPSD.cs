using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class LoadImageToPSD
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:LoadImageToPSD

            string filePath = dataDir + "PsdExample.psd";
            string outputFilePath = dataDir + "PsdResult.psd";
            using (var image = new PsdImage(200, 200))
            {
                using (var im = Image.Load(filePath))
                {
                    Layer layer = null;
                    try
                    {
                        layer = new Layer((RasterImage)im);
                        image.AddLayer(layer);
                    }
                    catch (Exception e)
                    {
                        if (layer != null)
                        {
                            layer.Dispose();
                        }
                        throw;
                    }
                }
                image.Save(outputFilePath);
            }

            //ExEnd:LoadImageToPSD
        }
    }
}