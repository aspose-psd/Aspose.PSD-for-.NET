using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class RenderTextWithDifferentColorsInTextLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:1
            string sourceFile = SourceDir + @"text_ethalon_different_colors.psd";
            string destName = OutputDir + @"RenderTextWithDifferentColorsInTextLayer_out.png";

            // Load the noisy image 
            using (var psdImage = (PsdImage)Image.Load(sourceFile))
            {
                var txtLayer = (TextLayer)psdImage.Layers[1];
                txtLayer.TextData.UpdateLayerData();
                PngOptions pngOptions = new PngOptions();
                pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
                psdImage.Save(destName, pngOptions);
            }
            //ExEnd:1

            Console.WriteLine("RenderTextWithDifferentColorsInTextLayer executed successfully");
        }
    }
}
