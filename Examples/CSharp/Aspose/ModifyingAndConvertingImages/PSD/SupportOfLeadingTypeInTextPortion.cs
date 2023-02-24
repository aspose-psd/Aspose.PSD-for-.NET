using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.Text;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportOfLeadingTypeInTextPortion
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfLeadingTypeInTextPortion
            //ExSummary:The following code demonstrates the support of Bottom-to-bottom and Top-to-Top leading modes from Paragraph settings.

            string input = Path.Combine(baseDir, "leadingMode.psd");
            string output = Path.Combine(outputDir, "output_leadingMode.png");
            
            using (var psdImage = (PsdImage)Image.Load(input, new PsdLoadOptions()))
            {
                IText text1 = ((TextLayer)psdImage.Layers[1]).TextData;
                foreach (var textPortion in text1.Items)
                {
                    textPortion.Paragraph.LeadingType = LeadingType.TopToTop; // Change LeadingType value   
                }
                text1.Items[8].Text = "TopToTop";
                text1.Items[8].Style.FillColor = Color.ForestGreen;
                text1.UpdateLayerData();

                IText text2 = ((TextLayer)psdImage.Layers[2]).TextData;
                foreach (var textPortion in text2.Items)
                {
                    textPortion.Paragraph.LeadingType = LeadingType.BottomToBottom; // Change LeadingType value   
                }
                text2.Items[8].Text = "BottomToBottom";
                text2.Items[8].Style.FillColor = Color.ForestGreen;
                text2.UpdateLayerData();

                psdImage.Save(output, new PngOptions());
            }

            //ExEnd:SupportOfLeadingTypeInTextPortion

            File.Delete(output);

            Console.WriteLine("SupportOfLeadingTypeInTextPortion executed successfully");
        }
    }
}