using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.Text;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class RenderingOfDifferentStylesInOneTextLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:RenderingOfDifferentStylesInOneTextLayer
            //ExSummary:The following example demonstrates how you can render different styles in one text layer in Aspose.PSD
            string sourceFile = dataDir + "text212.psd";
            string outputFile = dataDir + "Output_text212.psd";

            using (var img = (PsdImage)Image.Load(sourceFile))
            {
                TextLayer textLayer = (TextLayer)img.Layers[1];
                IText textData = textLayer.TextData;
                ITextStyle defaultStyle = textData.ProducePortion().Style;
                ITextParagraph defaultParagraph = textData.ProducePortion().Paragraph;
                defaultStyle.FillColor = Color.DimGray;
                defaultStyle.FontSize = 51;

                textData.Items[1].Style.Strikethrough = true;

                ITextPortion[] newPortions = textData.ProducePortions(
                    new string[]
                    {
                      "E=mc", "2\r", "Bold", "Italic\r",
                      "Lowercasetext"
                    },
                    defaultStyle,
                    defaultParagraph);

                newPortions[0].Style.Underline = true; // edit text style "E=mc"
                newPortions[1].Style.FontBaseline = FontBaseline.Superscript; // edit text style "2\r"
                newPortions[2].Style.FauxBold = true; // edit text style "Bold"
                newPortions[3].Style.FauxItalic = true; // edit text style "Italic\r"
                newPortions[3].Style.BaselineShift = -25; // edit text style "Italic\r"
                newPortions[4].Style.FontCaps = FontCaps.SmallCaps; // edit text style "Lowercasetext"

                foreach (var newPortion in newPortions)
                {
                    textData.AddPortion(newPortion);
                }

                textData.UpdateLayerData();
                img.Save(outputFile);
            }

            //ExEnd:RenderingOfDifferentStylesInOneTextLayer
        }
    }
}
