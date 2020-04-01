using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.Shapes;
using System;

namespace Aspose.PSD.Examples.Aspose.DrawingImages
{
    class DrawingUsingGraphicsPath
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:DrawingUsingGraphicsPath

            // Create an instance of Image and initialize an instance of Graphics
            using (PsdImage image = new PsdImage(500, 500))
            {
                // create graphics surface.
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create an instance of GraphicsPath and Instance of Figure, add EllipseShape, RectangleShape and TextShape to the figure
                GraphicsPath graphicspath = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(0, 0, 499, 499)));
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, 499, 499)));
                figure.AddShape(new TextShape("Aspose.PSD", new RectangleF(170, 225, 170, 100), new Font("Arial", 20), StringFormat.GenericTypographic));
                graphicspath.AddFigures(new[] { figure });
                graphics.DrawPath(new Pen(Color.Blue), graphicspath);

                // Create an instance of HatchBrush and set its properties also Fill path by supplying the brush and GraphicsPath objects
                HatchBrush hatchbrush = new HatchBrush();
                hatchbrush.BackgroundColor = Color.Brown;
                hatchbrush.ForegroundColor = Color.Blue;
                hatchbrush.HatchStyle = HatchStyle.Vertical;
                graphics.FillPath(hatchbrush, graphicspath);
                image.Save(dataDir + "DrawingUsingGraphicsPath_output.psd");
                Console.WriteLine("Processing completed successfully.");
            }

            //ExEnd:DrawingUsingGraphicsPath

        }
    }
}
