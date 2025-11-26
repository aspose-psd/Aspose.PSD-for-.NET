using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.FileFormats.Psd.Layers.Warp;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    public class SupportOfGridSizeProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfGridSizeProperty
            //ExSummary:The following code demonstrates support of WarpSettings.GridSize property.

            string sourceFile = Path.Combine(baseDir, "pirate_x3.psd");
            string outputFile = Path.Combine(outputDir, "export.png");

            using (var psdImage = (PsdImage)Image.Load(sourceFile, new PsdLoadOptions() { AllowWarpRepaint = true, LoadEffectsResource = true }))
            {
                // Get warp settings
                WarpSettings warpSettings = ((SmartObjectLayer)(psdImage.Layers[0])).WarpSettings;

                // Set new size
                // For the Photoshop value can be between 1 and 50 and you can not save PSD file correctly.
                warpSettings.GridSize = new Size(100, 100);

                // Set valid value
                warpSettings.GridSize = new Size(3, 3);

                // Render example file with x3 grid
                psdImage.Save(outputFile, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
            }

            //ExEnd:SupportOfGridSizeProperty

            File.Delete(outputFile);

            Console.WriteLine("SupportOfGridSizeProperty executed successfully");
        }
    }
}
