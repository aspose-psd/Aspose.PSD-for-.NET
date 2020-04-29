using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class LoadPSDWithReadOnlyMode
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:LoadPSDWithReadOnlyMode

            string sourceFileName = dataDir + "White 3D Text Effect.psd";
            string outFileName = dataDir + "Exported.png";

            LoadOptions loadOptions = new PsdLoadOptions() { ReadOnlyMode = true };
            ImageOptionsBase saveOptions = new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha };
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName, loadOptions))
            {
                image.Save(outFileName, saveOptions);
            }
            double memoryUsed = (GC.GetTotalMemory(false) / 1024.0) / 1024.0;

            // Memory usage must be less then 100 MB for this examples
            if (memoryUsed > 100)
            {
                throw new Exception("Usage of memory is too big");
            }
            //ExEnd:LoadPSDWithReadOnlyMode
        }
    }
}