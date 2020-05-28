using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class Saving16BitGrayscalePsdTo8BitGrayscale
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();
            string outputFolder = RunExamples.GetDataDir_Output();

            //ExStart:Saving16BitGrayscalePsdTo8BitGrayscale

            //The following example demonstrates that reading and saving the Grayscale 16 bit PSD files to 8 bit per channel Grayscale works correctly and without an exception.
            string sourceFilePath = Path.Combine(dataDir, "grayscale16bit.psd");
            string exportFilePath = Path.Combine(outputFolder, "grayscale16bit_Grayscale8_2_RLE.psd");
            PsdOptions psdOptions = new PsdOptions()
            {
                ColorMode = ColorModes.Grayscale,
                ChannelBitsCount = 8,
                ChannelsCount = 2
            };

            using (PsdImage image = (PsdImage)Image.Load(sourceFilePath))
            {
                RasterCachedImage raster = image.Layers[0];
                Graphics graphics = new Graphics(raster);
                int width = raster.Width;
                int height = raster.Height;
                Rectangle rect = new Rectangle(width / 3, height / 3, width - (2 * (width / 3)) - 1, height - (2 * (height / 3)) - 1);
                graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);
                image.Save(exportFilePath, psdOptions);
            }

            string pngExportPath = Path.ChangeExtension(exportFilePath, "png");
            using (PsdImage image = (PsdImage)Image.Load(exportFilePath))
            {
                // Here should be no exception.
                image.Save(pngExportPath, new PngOptions() { ColorType = PngColorType.GrayscaleWithAlpha });
            }
            //ExEnd:Saving16BitGrayscalePsdTo8BitGrayscale

            Console.WriteLine("Saving16BitGrayscalePsdTo8BitGrayscale executed successfully");
        }

    }
}