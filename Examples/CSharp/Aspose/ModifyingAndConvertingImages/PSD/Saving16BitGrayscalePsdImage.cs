using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class Saving16BitGrayscalePsdImage
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();
            string outputFolder = RunExamples.GetDataDir_Output();

            //ExStart:Saving16BitGrayscalePsdImage
            
            Stack<string> outputFilePathStack = new Stack<string>();

            //The following example demonstrates that reading and saving the Grayscale 16 bit PSD files works correctly and without an exception.
            void SaveToPsdThenLoadAndSaveToPng(
                string file,
                ColorModes colorMode,
                short channelBitsCount,
                short channelsCount,
                CompressionMethod compression,
                int layerNumber)
            {
                string filePath = Path.Combine(dataDir, file + ".psd");
                string postfix = colorMode.ToString() + channelBitsCount + "_" + channelsCount + "_" + compression;
                string exportPath = Path.Combine(outputFolder, file + postfix + ".psd");
                PsdOptions psdOptions = new PsdOptions()
                {
                    ColorMode = colorMode,
                    ChannelBitsCount = channelBitsCount,
                    ChannelsCount = channelsCount,
                    CompressionMethod = compression
                };

                using (PsdImage image = (PsdImage)Image.Load(filePath))
                {
                    RasterCachedImage raster = layerNumber >= 0 ? (RasterCachedImage)image.Layers[layerNumber] : image;

                    Graphics graphics = new Graphics(raster);
                    int width = raster.Width;
                    int height = raster.Height;
                    Rectangle rect = new Rectangle(
                        width / 3,
                        height / 3,
                        width - (2 * (width / 3)) - 1,
                        height - (2 * (height / 3)) - 1);
                    graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);

                    image.Save(exportPath, psdOptions);
                }

                string pngExportPath = Path.ChangeExtension(exportPath, "png");
                using (PsdImage image = (PsdImage)Image.Load(exportPath))
                {
                    // Here should be no exception.
                    image.Save(pngExportPath, new PngOptions() { ColorType = PngColorType.GrayscaleWithAlpha });
                }

                outputFilePathStack.Push(exportPath);
            }

            SaveToPsdThenLoadAndSaveToPng("grayscale5x5", ColorModes.Cmyk, 16, 5, CompressionMethod.RLE, 0);
            SaveToPsdThenLoadAndSaveToPng("argb16bit_5x5", ColorModes.Grayscale, 16, 2, CompressionMethod.RLE, 0);
            SaveToPsdThenLoadAndSaveToPng("argb16bit_5x5_no_layers", ColorModes.Grayscale, 16, 2, CompressionMethod.RLE, -1);
            SaveToPsdThenLoadAndSaveToPng("argb8bit_5x5", ColorModes.Grayscale, 16, 2, CompressionMethod.RLE, 0);
            SaveToPsdThenLoadAndSaveToPng("argb8bit_5x5_no_layers", ColorModes.Grayscale, 16, 2, CompressionMethod.RLE, -1);
            SaveToPsdThenLoadAndSaveToPng("cmyk16bit_5x5_no_layers", ColorModes.Grayscale, 16, 2, CompressionMethod.RLE, -1);
            SaveToPsdThenLoadAndSaveToPng("index8bit_5x5", ColorModes.Grayscale, 16, 2, CompressionMethod.RLE, -1);

            //ExEnd:Saving16BitGrayscalePsdImage

            Console.WriteLine("Saving16BitGrayscalePsdImage executed successfully");
        }

    }
}