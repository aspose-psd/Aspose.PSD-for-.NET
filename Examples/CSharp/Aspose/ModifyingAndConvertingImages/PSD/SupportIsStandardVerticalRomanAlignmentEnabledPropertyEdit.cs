using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportIsStandardVerticalRomanAlignmentEnabledPropertyEdit
    {
        
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportIsStandardVerticalRomanAlignmentEnabledPropertyEdit
            //ExSummary:The following code demonstrates the support of the new IsStandardVerticalRomanAlignmentEnabled property.

            // The following code demonstrates the ability to edit the new IsStandardVerticalRomanAlignmentEnabled property.
            // This does not affect rendering at the moment, but only allows you to edit the property value.

            string src = Path.Combine(baseDir, "1346test.psd");
            string output = Path.Combine(outputDir, "out_1346test.psd");

            using (var image = (PsdImage)Image.Load(src))
            {
                var textLayer = image.Layers[1] as TextLayer;
                var textPortion = textLayer.TextData.Items[0];
                if (textPortion.Style.IsStandardVerticalRomanAlignmentEnabled)
                {
                    // Correct reading
                }
                else
                {
                    throw new Exception("Incorrect reading of IsStandardVerticalRomanAlignmentEnabled property value");
                }

                textPortion.Style.IsStandardVerticalRomanAlignmentEnabled = false;
                textLayer.TextData.UpdateLayerData();

                image.Save(output);
            }

            using (var image = (PsdImage)Image.Load(output))
            {
                var textLayer = image.Layers[1] as TextLayer;
                var textPortion = textLayer.TextData.Items[0];
                if (!textPortion.Style.IsStandardVerticalRomanAlignmentEnabled)
                {
                    // Correct reading
                }
                else
                {
                    throw new Exception("Incorrect reading of IsStandardVerticalRomanAlignmentEnabled property value");
                }
            }

            //ExEnd:SupportIsStandardVerticalRomanAlignmentEnabledPropertyEdit

            File.Delete(output);

            Console.WriteLine("SupportIsStandardVerticalRomanAlignmentEnabledPropertyEdit executed successfully");
        }
    }
}