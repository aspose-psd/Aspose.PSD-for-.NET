using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples
{
    class GetPropertiesOfInlineFormattingOfTextLayer
    {

        public static void Run()
        {
            //ExStart:GetPropertiesOfInlineFormattingOfTextLayer

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            using (var psdImage = (PsdImage)Image.Load(dataDir + "inline_formatting.psd"))
            {
                List<ITextPortion> regularText = new List<ITextPortion>();
                List<ITextPortion> boldText = new List<ITextPortion>();
                List<ITextPortion> italicText = new List<ITextPortion>();
                var layers = psdImage.Layers;
                for (int index = 0; index < layers.Length; index++)
                {
                    var layer = layers[index];
                    if (!(layer is TextLayer))
                    {
                        continue;
                    }

                    var textLayer = (TextLayer)layer;
                    // gets fonts that contains in text layer
                    var fonts = textLayer.GetFonts();
                    var textPortions = textLayer.TextData.Items;

                    foreach (var textPortion in textPortions)
                    {
                        TextFontInfo font = fonts[textPortion.Style.FontIndex];
                        if (font != null)
                        {
                            switch (font.Style)
                            {
                                case FontStyle.Regular:
                                    regularText.Add(textPortion);
                                    break;
                                case FontStyle.Bold:
                                    boldText.Add(textPortion);
                                    break;
                                case FontStyle.Italic:
                                    italicText.Add(textPortion);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                    }
                }
            }

            //ExEnd:GetPropertiesOfInlineFormattingOfTextLayer
        }
    }
}
