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
    class DrawingBezier
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DrawingBezier
            // Create an instance of BmpOptions and set its various properties
            string outpath = dataDir + "Bezier.bmp";
            // Create an instance of BmpOptions and set its various properties
            BmpOptions saveOptions = new BmpOptions();
            saveOptions.BitsPerPixel = 32;

            // Create an instance of Image
            using (Image image = new PsdImage(100, 100))
            {
                // Create and initialize an instance of Graphics class and clear Graphics surface
                Graphics graphic = new Graphics(image);
                graphic.Clear(Color.Yellow);

                // Initializes the instance of PEN class with black color and width
                Pen BlackPen = new Pen(Color.Black, 3);
                float startX = 10;
                float startY = 25;
                float controlX1 = 20;
                float controlY1 = 5;
                float controlX2 = 55;
                float controlY2 = 10;
                float endX = 90;
                float endY = 25;

                // Draw a Bezier shape by specifying the Pen object having black color and co-ordinate Points and save all changes.
                graphic.DrawBezier(BlackPen, startX, startY, controlX1, controlY1, controlX2, controlY2, endX, endY);

                // export image to bmp file format.
                image.Save(outpath, saveOptions);
            }

            //ExEnd:DrawingBezier

        }
    }
}
