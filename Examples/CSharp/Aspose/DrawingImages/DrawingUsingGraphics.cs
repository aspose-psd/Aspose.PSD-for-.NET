using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class DrawingUsingGraphics
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DrawingUsingGraphics

            // Create an instance of Image
            using (PsdImage image = new PsdImage(500, 500))
            {
                var graphics = new Graphics(image);

                // Clear the image surface with white color and Create and initialize a Pen object with blue color
                graphics.Clear(Color.White);
                var pen = new Pen(Color.Blue);

                // Draw Ellipse by defining the bounding rectangle of width 150 and height 100 also Draw a polygon using the LinearGradientBrush
                graphics.DrawEllipse(pen, new Rectangle(10, 10, 150, 100));
                using (var linearGradientBrush = new LinearGradientBrush(image.Bounds, Color.Red, Color.White, 45f))
                {
                    graphics.FillPolygon(linearGradientBrush, new[] { new Point(200, 200), new Point(400, 200), new Point(250, 350) });
                }

                // export modified image.
                image.Save(dataDir + "DrawingUsingGraphics_output.bmp", new BmpOptions());
            }


            //ExEnd:DrawingUsingGraphics

        }
    }
}
