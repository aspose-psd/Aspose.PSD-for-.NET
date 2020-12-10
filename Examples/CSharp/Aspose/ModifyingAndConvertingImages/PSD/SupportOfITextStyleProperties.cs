using System;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfITextStyleProperties
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string output = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfITextStyleProperties
            //ExSummary:The following code demonstrates the support of the support of new ITextStyle properties.

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new FormatException(
                        string.Format("Actual value {0} are not equal to expected {1}.", actual, expected));
                }
            }

            string srcFile = baseFolder + "A.psd";
            string outputFile = output + "output.psd";

            using (var psdImage = (PsdImage)Image.Load(srcFile))
            {
                var textLayer = (TextLayer)psdImage.Layers[1];
                textLayer.UpdateText("abc");

                psdImage.Save(outputFile);
            }

            // Check values
            using (var srcImage = (PsdImage)Image.Load(srcFile))
            {
                var srcTextLayer = (TextLayer)srcImage.Layers[1];
                var etalonStyle = srcTextLayer.TextData.Items[0].Style;

                using (var outImage = (PsdImage)Image.Load(outputFile))
                {
                    var outTextLayer = (TextLayer)outImage.Layers[1];
                    var resultStyle = outTextLayer.TextData.Items[0].Style;

                    AssertAreEqual(etalonStyle.AutoLeading, resultStyle.AutoLeading);
                    AssertAreEqual(etalonStyle.FontIndex, resultStyle.FontIndex);
                    AssertAreEqual(etalonStyle.Underline, resultStyle.Underline);
                    AssertAreEqual(etalonStyle.Strikethrough, resultStyle.Strikethrough);
                    AssertAreEqual(etalonStyle.AutoKerning, resultStyle.AutoKerning);
                    AssertAreEqual(etalonStyle.StandardLigatures, resultStyle.StandardLigatures);
                    AssertAreEqual(etalonStyle.DiscretionaryLigatures, resultStyle.DiscretionaryLigatures);
                    AssertAreEqual(etalonStyle.ContextualAlternates, resultStyle.ContextualAlternates);
                    AssertAreEqual(etalonStyle.LanguageIndex, resultStyle.LanguageIndex);
                    AssertAreEqual(etalonStyle.VerticalScale, resultStyle.VerticalScale);
                    AssertAreEqual(etalonStyle.HorizontalScale, resultStyle.HorizontalScale);
                    AssertAreEqual(etalonStyle.Fractions, resultStyle.Fractions);
                }
            }

            //ExEnd:SupportOfITextStyleProperties

            Console.WriteLine("SupportOfITextStyleProperties executed successfully");
        }
    }
}
