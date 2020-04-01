using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class GetTextPropertiesFromTextLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:GetTextPropertiesFromTextLayer

            const double Tolerance = 0.0001;
            var filePath = dataDir + "ThreeColorsParagraphs.psd";
            var outputPath = dataDir + "ThreeColorsParagraph_out.psd";
            using (var im = (PsdImage)Image.Load(filePath))
            {
                for (int i = 0; i < im.Layers.Length; i++)
                {
                    var layer = im.Layers[i] as TextLayer;

                    if (layer != null)
                    {
                        var portions = layer.TextData.Items;

                        if (portions.Length != 4)
                        {
                            throw new Exception();
                        }

                        // Checking text of every portion
                        if (portions[0].Text != "Old " ||
                            portions[1].Text != "color" ||
                            portions[2].Text != " text\r" ||
                            portions[3].Text != "Second paragraph\r")
                        {
                            throw new Exception();
                        }

                        // Checking paragraphs data
                        // Paragraphs have different justification
                        if (
                            portions[0].Paragraph.Justification != 0 ||
                            portions[1].Paragraph.Justification != 0 ||
                            portions[2].Paragraph.Justification != 0 ||
                            portions[3].Paragraph.Justification != 2)
                        {
                            throw new Exception();
                        }

                        // All other properties of first and second paragraph are equal
                        for (int j = 0; j < portions.Length; j++)
                        {
                            var paragraph = portions[j].Paragraph;

                            if (Math.Abs(paragraph.AutoLeading - 1.2) > Tolerance ||
                                paragraph.AutoHyphenate != false ||
                                paragraph.Burasagari != false ||
                                paragraph.ConsecutiveHyphens != 8 ||
                                Math.Abs(paragraph.StartIndent) > Tolerance ||
                                Math.Abs(paragraph.EndIndent) > Tolerance ||
                                paragraph.EveryLineComposer != false ||
                                Math.Abs(paragraph.FirstLineIndent) > Tolerance ||
                                paragraph.GlyphSpacing.Length != 3 ||
                                Math.Abs(paragraph.GlyphSpacing[0] - 1) > Tolerance ||
                                Math.Abs(paragraph.GlyphSpacing[1] - 1) > Tolerance ||
                                Math.Abs(paragraph.GlyphSpacing[2] - 1) > Tolerance ||
                                paragraph.Hanging != false ||
                                paragraph.HyphenatedWordSize != 6 ||
                                paragraph.KinsokuOrder != 0 ||
                                paragraph.LetterSpacing.Length != 3 ||
                                Math.Abs(paragraph.LetterSpacing[0]) > Tolerance ||
                                Math.Abs(paragraph.LetterSpacing[1]) > Tolerance ||
                                Math.Abs(paragraph.LetterSpacing[2]) > Tolerance ||
                                paragraph.LeadingType != LeadingMode.Auto ||
                                paragraph.PreHyphen != 2 ||
                                paragraph.PostHyphen != 2 ||
                                Math.Abs(paragraph.SpaceBefore) > Tolerance ||
                                Math.Abs(paragraph.SpaceAfter) > Tolerance ||
                                paragraph.WordSpacing.Length != 3 ||
                                Math.Abs(paragraph.WordSpacing[0] - 0.8) > Tolerance ||
                                Math.Abs(paragraph.WordSpacing[1] - 1.0) > Tolerance ||
                                Math.Abs(paragraph.WordSpacing[2] - 1.33) > Tolerance ||
                                Math.Abs(paragraph.Zone - 36.0) > Tolerance)
                            {
                                throw new Exception();
                            }
                        }

                        // Checking style data
                        // Styles have different colors and font size
                        if (Math.Abs(portions[0].Style.FontSize - 12) > Tolerance ||
                            Math.Abs(portions[1].Style.FontSize - 12) > Tolerance ||
                            Math.Abs(portions[2].Style.FontSize - 12) > Tolerance ||
                            Math.Abs(portions[3].Style.FontSize - 10) > Tolerance)
                        {
                            throw new Exception();
                        }

                        if (portions[0].Style.FillColor != Color.FromArgb(255, 145, 0, 0) ||
                            portions[1].Style.FillColor != Color.FromArgb(255, 201, 128, 2) ||
                            portions[2].Style.FillColor != Color.FromArgb(255, 18, 143, 4) ||
                            portions[3].Style.FillColor != Color.FromArgb(255, 145, 42, 100))
                        {
                            throw new Exception();
                        }

                        for (int j = 0; j < portions.Length; j++)
                        {
                            var style = portions[j].Style;

                            if (style.AutoLeading != false ||
                                style.HindiNumbers != false ||
                                style.Kerning != 0 ||
                                style.Leading != 0 ||
                                style.StrokeColor != Color.FromArgb(255, 175, 90, 163) ||
                                style.Tracking != 50)
                            {
                                throw new Exception();
                            }
                        }

                        // Example of text editing
                        portions[0].Text = "Hello ";
                        portions[1].Text = "World";

                        // Example of text portions removing
                        layer.TextData.RemovePortion(3);
                        layer.TextData.RemovePortion(2);

                        // Example of adding new text portion
                        var createdPortion = layer.TextData.ProducePortion();
                        createdPortion.Text = "!!!\r";
                        layer.TextData.AddPortion(createdPortion);

                        portions = layer.TextData.Items;

                        // Example of paragraph and style editing for portions
                        // Set right justification
                        portions[0].Paragraph.Justification = 1;
                        portions[1].Paragraph.Justification = 1;
                        portions[2].Paragraph.Justification = 1;

                        // Different colors for each style. The will be changed, but rendering is not fully supported
                        portions[0].Style.FillColor = Color.Aquamarine;
                        portions[1].Style.FillColor = Color.Violet;
                        portions[2].Style.FillColor = Color.LightBlue;

                        // Different font. The will be changed, but rendering is not fully supported
                        portions[0].Style.FontSize = 6;
                        portions[1].Style.FontSize = 8;
                        portions[2].Style.FontSize = 10;

                        layer.TextData.UpdateLayerData();

                        im.Save(outputPath, new PsdOptions(im));

                        break;
                    }
                }
            }

            //ExEnd:GetTextPropertiesFromTextLayer



        }

    }
}
