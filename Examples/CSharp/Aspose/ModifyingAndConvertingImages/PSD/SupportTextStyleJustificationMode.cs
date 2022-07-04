using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportTextStyleJustificationMode
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportTextStyleJustificationMode
            //ExSummary:The following code demonstrates support of JustificationMode enum to set the text alignment for text portions.

            string src = Path.Combine(baseDir, "source1107.psd");
            string outputPsd = Path.Combine(outputDir, "output.psd");
            string outputPng = Path.Combine(outputDir, "output.png");

            using (var image = (PsdImage) Image.Load(src))
            {
                var txtLayer = image.AddTextLayer("Text line1\rText line2\rText line3",
                    new Rectangle(200, 200, 500, 500));
                var portions = txtLayer.TextData.Items;

                portions[0].Paragraph.Justification = JustificationMode.Left;
                portions[1].Paragraph.Justification = JustificationMode.Right;
                portions[2].Paragraph.Justification = JustificationMode.Center;

                foreach (var portion in portions)
                {
                    portion.Style.FontSize = 24;
                }

                txtLayer.TextData.UpdateLayerData();

                image.Save(outputPsd);
                image.Save(outputPng, new PngOptions());
            }

            //ExEnd:SupportTextStyleJustificationMode

            File.Delete(outputPsd);
            File.Delete(outputPng);
            
            Console.WriteLine("SupportTextStyleJustificationMode executed successfully");
        }
    }
}