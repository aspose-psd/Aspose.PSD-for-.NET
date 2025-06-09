using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Opening;

public class SupportOfAllowNonChangedLayerRepaint
{
    public static void Run()
    {
        // The path to the documents directory.
        string baseDir = RunExamples.GetDataDir_PSD();
        string outputDir = RunExamples.GetDataDir_Output();

        //ExStart:SupportOfAllowNonChangedLayerRepaint
        //ExSummary:The following code demonstrates the new behaviour that prevent auto repaint of layers before changes.

        string srcFile = Path.Combine(baseDir, "psdnet2400.psd");
        string output1 = Path.Combine(outputDir, "unchanged-2400.png");
        string output2 = Path.Combine(outputDir, "updated-2400.png");

        using (var psdImage = (PsdImage)Image.Load(srcFile,
            new PsdLoadOptions() { AllowNonChangedLayerRepaint = false /* The new default behaviour */ }))
        {
            psdImage.Save(output1, new PngOptions());

            ((TextLayer)psdImage.Layers[1]).TextData.UpdateLayerData();

            psdImage.Save(output2, new PngOptions());
        }

        //ExEnd:SupportOfAllowNonChangedLayerRepaint

        File.Delete(output1);
        File.Delete(output2);

        Console.WriteLine("SupportOfAllowNonChangedLayerRepaint executed successfully");
    }

}
