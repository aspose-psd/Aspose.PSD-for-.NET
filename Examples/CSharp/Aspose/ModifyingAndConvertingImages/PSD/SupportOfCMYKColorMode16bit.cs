using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfCMYKColorMode16bit
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string output = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfCMYKColorMode16bit
            //ExSummary:The following code demonstrates the support of the CMYK ColorMode 16 bit and the ability to drawing by using Aspose.PSD.Graphics class.

            string srcFile = Path.Combine(baseFolder, "cub16bit_cmyk.psd");
            string outputPsd = Path.Combine(output, "output.psd");
            string outputPng = Path.Combine(output, "output.png");

            using (PsdImage image = (PsdImage)Image.Load(srcFile))
            {
                RasterCachedImage raster = image.Layers[0];
                Graphics graphics = new Graphics(raster);
                int width = raster.Width;
                int height = raster.Height;
                Rectangle rect = new Rectangle(width / 3, height / 3, width - (2 * (width / 3)) - 1, height - (2 * (height / 3)) - 1);
                graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);
                image.Save(outputPsd);
                image.Save(outputPng, new PngOptions());
            }

            //ExEnd:SupportOfCMYKColorMode16bit
            
            File.Delete(outputPsd);
            File.Delete(outputPng);

            Console.WriteLine("SupportOfCMYKColorMode16bit executed successfully");
        }
    }
}
