using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.FileFormats.Psd.Layers.Warp;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects;

public class SupportOfProcessingAreaProperty
{
    public static void Run()
    {
        // The path to the documents directory.
        string baseDir = RunExamples.GetDataDir_PSD();
        string outputDir = RunExamples.GetDataDir_Output();

        //ExStart:SupportOfProcessingAreaProperty
        //ExSummary:The following code demonstrates WarpSettings.ProcessingArea property to configure warp deformation.

        string sourceFile = Path.Combine(baseDir, "Warping.psd");
        List<string> outputFiles = new List<string>();

        PsdLoadOptions loadOptions = new PsdLoadOptions() { LoadEffectsResource = true, AllowWarpRepaint = true };

        int[] areaValues = { 5, 10, 25, 40 };

        for (int i = 0; i < 4; i++)
        {
            using (var psdImage = (PsdImage)Image.Load(sourceFile, loadOptions))
            {
                // It gets WarpSettings from Smart Layer
                WarpSettings warpSettings = ((SmartObjectLayer)psdImage.Layers[1]).WarpSettings;

                // It sets size of warp processing area
                warpSettings.ProcessingArea = areaValues[i];
                ((SmartObjectLayer)psdImage.Layers[1]).WarpSettings = warpSettings;

                string outputFile = Path.Combine(outputDir, "export" + areaValues[i] + ".png");
                outputFiles.Add(outputFile);

                // There should no error here
                psdImage.Save(outputFile, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }

        //ExEnd:SupportOfProcessingAreaProperty

        foreach (string outputFile in outputFiles)
        {
            File.Delete(outputFile);
        }

        Console.WriteLine("SupportOfProcessingAreaProperty executed successfully");
    }
}
