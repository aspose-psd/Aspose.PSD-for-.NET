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
    class DrawingRectangle
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DrawingRectangle
            // Create an instance of BmpOptions and set its various properties
            string outpath = dataDir + "Rectangle.bmp";
            // Create an instance of BmpOptions and set its various properties
            BmpOptions saveOptions = new BmpOptions();
            saveOptions.BitsPerPixel = 32;

            // Create an instance of Image
            using (Image image = new PsdImage(100, 100))
            {
                // Create and initialize an instance of Graphics class,  Clear Graphics surface, Draw a rectangle shapes and  save all changes.
                Graphics graphic = new Graphics(image);
                graphic.Clear(Color.Yellow);
                graphic.DrawRectangle(new Pen(Color.Red), new Rectangle(30, 10, 40, 80));
                graphic.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), new Rectangle(10, 30, 80, 40));

                // export image to bmp file format.
                image.Save(outpath, saveOptions);
            }

            //ExEnd:DrawingRectangle

        }
    }
}
