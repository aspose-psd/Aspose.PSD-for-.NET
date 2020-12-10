using System;
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

            using (PsdImage image = (PsdImage)Image.Load(baseFolder + "cub16bit_cmyk.psd"))
            {
                RasterCachedImage raster = image.Layers[0];
                Graphics graphics = new Graphics(raster);
                int width = raster.Width;
                int height = raster.Height;
                Rectangle rect = new Rectangle(width / 3, height / 3, width - (2 * (width / 3)) - 1, height - (2 * (height / 3)) - 1);
                graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);
                image.Save(output + "output.psd");
                image.Save(output + "output.png", new PngOptions());
            }

            //ExEnd:SupportOfCMYKColorMode16bit

            Console.WriteLine("SupportOfCMYKColorMode16bit executed successfully");
        }
    }
}
