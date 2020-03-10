using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class CreateIndexedPSDFiles
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:CreateIndexedPSDFiles

            // Create an instance of PsdOptions and set it's properties
            var createOptions = new PsdOptions();
            createOptions.Source = new FileCreateSource(dataDir + "Newsample_out.psd", false);
            createOptions.ColorMode = ColorModes.Indexed;
            createOptions.Version = 5;

            // Create a new color palette having RGB colors, Set Palette property & compression method
            Color[] palette = { Color.Red, Color.Green, Color.Blue, Color.Yellow };
            createOptions.Palette = new PsdColorPalette(palette);
            createOptions.CompressionMethod = CompressionMethod.RLE;

            // Create a new PSD with PsdOptions created previously
            using (var psd = Image.Create(createOptions, 500, 500))
            {
                // Draw some graphics over the newly created PSD
                var graphics = new Graphics(psd);
                graphics.Clear(Color.White);
                graphics.DrawEllipse(new Pen(Color.Red, 6), new Rectangle(0, 0, 400, 400));
                psd.Save();
            }

            //ExEnd:CreateIndexedPSDFiles

        }
    }
}
