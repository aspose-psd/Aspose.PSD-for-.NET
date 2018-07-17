using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class DrawingArc
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DrawingArc
            // Create an instance of BmpOptions and set its various properties
            string outpath = dataDir + "Arc.bmp";
            // Create an instance of BmpOptions and set its various properties
            BmpOptions saveOptions = new BmpOptions();
            saveOptions.BitsPerPixel = 32;

            // Create an instance of Image
            using (Image image = new PsdImage(100, 100))
            {
                // Create and initialize an instance of Graphics class and clear Graphics surface
                Graphics graphic = new Graphics(image);
                graphic.Clear(Color.Yellow);

                // Draw an arc shape by specifying the Pen object having red black color and coordinates, height, width, start & end angles                 
                int width = 100;
                int height = 200;
                int startAngle = 45;
                int sweepAngle = 270;

                // Draw arc to screen and save all changes.
                graphic.DrawArc(new Pen(Color.Black), 0, 0, width, height, startAngle, sweepAngle);

                // export image to bmp file format.
                image.Save(outpath, saveOptions);
            }

            //ExEnd:DrawingArc

        }
    }
}
