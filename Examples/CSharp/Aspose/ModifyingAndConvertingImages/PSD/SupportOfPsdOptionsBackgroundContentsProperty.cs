using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Core.RawColor;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfPsdOptionsBackgroundContentsProperty
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfPsdOptionsBackgroundContentsProperty
            //ExSummary:The following code demonstrates support of BackgroundContents property in PsdOptions.
            
            // Semi transparency is processed wrong on the psd file preview.
            // BackgroundContents assigned to White. Transparent areas should have white color.

            string sourceFile = Path.Combine(baseDir, "frog_nosymb.psd");
            string outputFile = Path.Combine(outputDir, "frog_nosymb_backgroundcontents_output.psd");

            using (PsdImage psdImage = (PsdImage)Image.Load(sourceFile))
            {
                RawColor backgroundColor = new RawColor(PixelDataFormat.Rgb32Bpp);
                int argbValue = 255 << 24 | 255 << 16 | 255 << 8 | 255;
                backgroundColor.SetAsInt(argbValue); // White

                PsdOptions psdOptions = new PsdOptions(psdImage)
                {
                    ColorMode = ColorModes.Rgb,
                    CompressionMethod = CompressionMethod.RLE,
                    ChannelsCount = 4,
                    BackgroundContents = backgroundColor,
                };

                psdImage.Save(outputFile, psdOptions);
            }
            //ExEnd:SupportOfPsdOptionsBackgroundContentsProperty

            File.Delete(outputFile);

            Console.WriteLine("SupportOfPsdOptionsBackgroundContentsProperty executed successfully");
        }
    }
}