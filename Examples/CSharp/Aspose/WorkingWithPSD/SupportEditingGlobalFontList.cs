using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    internal class SupportEditingGlobalFontList
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportEditingGlobalFontList
            //ExSummary:The following code demonstrates the ability to programmatically limit fonts using.

            string srcFile = Path.Combine(SourceDir, "fonts_com_updated.psd");
            string output = Path.Combine(OutputDir, "etalon_fonts_com_updated.psd.png");

            try
            {
                var fontList = new string[] { "Courier New", "Webdings", "Bookman Old Style" };
                FontSettings.SetAllowedFonts(fontList);

                var myriadReplacement = new string[] { "Courier New", "Webdings", "Bookman Old Style" };
                var calibriReplacement = new string[] { "Webdings", "Courier New", "Bookman Old Style" };
                var arialReplacement = new string[] { "Bookman Old Style", "Courier New", "Webdings" };
                var timesReplacement = new string[] { "Arial", "NotExistedFont", "Courier New" };

                FontSettings.SetFontReplacements("MyriadPro-Regular", myriadReplacement);
                FontSettings.SetFontReplacements("Calibri", calibriReplacement);
                FontSettings.SetFontReplacements("Arial", arialReplacement);
                FontSettings.SetFontReplacements("Times New Roman", timesReplacement);

                using (PsdImage image = (PsdImage)Image.Load(srcFile,
                    new PsdLoadOptions() { AllowNonChangedLayerRepaint = false }))
                {
                    image.Save(output, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
            finally
            {
                FontSettings.SetAllowedFonts(null);
                FontSettings.ClearFontReplacements();
            }

            //ExEnd:SupportEditingGlobalFontList

            Console.WriteLine("SupportEditingGlobalFontList executed successfully");

            File.Delete(output);
        }
    }
}
