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
    class DrawingLines
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DrawingLines
            // Create an instance of BmpOptions and set its various properties
            string outpath = dataDir + "Lines.bmp";
            BmpOptions saveOptions = new BmpOptions();
            saveOptions.BitsPerPixel = 32;

            // Create an instance of Image
            using (Image image = new PsdImage(100, 100))
            {
                // Create and initialize an instance of Graphics class and Clear Graphics surface
                Graphics graphic = new Graphics(image);
                graphic.Clear(Color.Yellow);

                // Draw two dotted diagonal lines by specifying the Pen object having blue color and co-ordinate Points
                graphic.DrawLine(new Pen(Color.Blue), 9, 9, 90, 90);
                graphic.DrawLine(new Pen(Color.Blue), 9, 90, 90, 9);

                // Draw a four continuous line by specifying the Pen object having Solid Brush with red color and two point structures
                graphic.DrawLine(new Pen(new SolidBrush(Color.Red)), new Point(9, 9), new Point(9, 90));
                graphic.DrawLine(new Pen(new SolidBrush(Color.Aqua)), new Point(9, 90), new Point(90, 90));
                graphic.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(90, 90), new Point(90, 9));
                graphic.DrawLine(new Pen(new SolidBrush(Color.White)), new Point(90, 9), new Point(9, 9));
                image.Save(outpath, saveOptions);
            }

            //ExEnd:DrawingLines

        }
    }
}
