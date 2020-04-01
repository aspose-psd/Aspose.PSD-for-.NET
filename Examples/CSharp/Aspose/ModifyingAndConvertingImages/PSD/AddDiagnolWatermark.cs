using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddDiagnolWatermark
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddDiagnolWatermark

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            {
                // Create graphics object to perform draw operations.
                Graphics graphics = new Graphics(psdImage);

                // Create font to draw watermark with.
                Font font = new Font("Arial", 20.0f);

                // Create a solid brush with color alpha set near to 0 to use watermarking effect.
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, 128, 128, 128)))
                {
                    // specify transform matrix to rotate watermark.
                    graphics.Transform = new Matrix();
                    graphics.Transform.RotateAt(45, new PointF(psdImage.Width / 2, psdImage.Height / 2));

                    // Specify string alignment to put watermark at the image center.
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;

                    // Draw watermark using font, partly-transparent brush at the image center.
                    graphics.DrawString("Some watermark text", font, brush, new RectangleF(0, psdImage.Height / 2, psdImage.Width, psdImage.Height / 2), sf);
                }

                // Export the image into PNG file format.
                psdImage.Save(dataDir + "AddDiagnolWatermark_output.png", new PngOptions());
            }


            //ExEnd:AddDiagnolWatermark
        }

    }
}
