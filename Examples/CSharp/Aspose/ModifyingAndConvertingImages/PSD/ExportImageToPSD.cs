using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Bmp;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ExportImageToPSD
    {
        public static void Run()
        {
            //ExStart:ExportImageToPSD
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Create a new image from scratch.
            using (BmpImage bmpImage = new BmpImage(300, 300))
            {
                // Fill image data.
                Graphics graphics = new Graphics(bmpImage);
                graphics.Clear(Color.White);
                var pen = new Pen(Color.Brown);
                graphics.DrawRectangle(pen, bmpImage.Bounds);

                // Create an instance of PsdOptions, Set it's various properties Save image to disk in PSD format
                PsdOptions psdOptions = new PsdOptions();
                psdOptions.ColorMode = ColorModes.Rgb;
                psdOptions.CompressionMethod = CompressionMethod.Raw;
                psdOptions.Version = 4;
                bmpImage.Save(dataDir+"ExportImageToPSD_output.psd", psdOptions);
            }

            //ExEnd:ExportImageToPSD

        }
    }
}
