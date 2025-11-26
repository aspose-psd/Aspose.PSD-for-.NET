using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.FileFormats.Psd.Layers.Warp;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    public class SupportOfRenderQualityProperty
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfRenderQualityProperty
            //ExSummary:The following code demonstrates WarpSettings.RenderQuality property to configure warp deformation.

            string sourceFile = Path.Combine(baseDir, "Warping.psd");
            List<string> outputFiles = new List<string>();

            PsdLoadOptions loadOptions = new PsdLoadOptions() { LoadEffectsResource = true, AllowWarpRepaint = true };

            RenderQuality[] qualityValues = { RenderQuality.Turbo, RenderQuality.Fast, RenderQuality.Normal, RenderQuality.Excellent };

            for (int i = 0; i < 4; i++)
            {
                using (var psdImage = (PsdImage)Image.Load(sourceFile, loadOptions))
                {
                    // It gets WarpSettings from Smart Layer
                    WarpSettings warpSettings = ((SmartObjectLayer)psdImage.Layers[1]).WarpSettings;

                    // It sets size of warp processing area
                    warpSettings.RenderQuality = qualityValues[i];
                    ((SmartObjectLayer)psdImage.Layers[1]).WarpSettings = warpSettings;

                    string outputFile = Path.Combine(outputDir, "export" + qualityValues[i].ToString() + ".png");
                    outputFiles.Add(outputFile);

                    // There should no error here
                    psdImage.Save(outputFile, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            //ExEnd:SupportOfRenderQualityProperty

            foreach (string outputFile in outputFiles)
            {
                File.Delete(outputFile);
            }

            Console.WriteLine("SupportOfRenderQualityProperty executed successfully");
        }
    }
}
