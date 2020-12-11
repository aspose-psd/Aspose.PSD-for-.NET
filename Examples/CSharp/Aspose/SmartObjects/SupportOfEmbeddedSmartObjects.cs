using System;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    class SupportOfEmbeddedSmartObjects
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string output = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfEmbeddedSmartObjects
            //ExSummary:The following code demonstrates the support of Embedded Smart objects.

            void AssertAreEqual(object actual, object expected)
            {
                if (!object.Equals(actual, expected))
                {
                    throw new FormatException(string.Format("Actual value {0} are not equal to expected {1}.", actual, expected));
                }
            }

            // This example demonstrates how to change the smart object layer in the PSD file and export / update smart object original embedded contents.
            const int left = 0;
            const int top = 0;
            const int right = 0xb;
            const int bottom = 0x10;
            FileFormat[] formats = new[]
            {
                FileFormat.Png, FileFormat.Psd, FileFormat.Bmp, FileFormat.Jpeg, FileFormat.Gif, FileFormat.Tiff, FileFormat.Jpeg2000
            };
            foreach (FileFormat format in formats)
            {
                string formatString = format.ToString().ToLowerInvariant();
                string formatExt = format == FileFormat.Jpeg2000 ? "jpf" : formatString;
                string fileName = "r-embedded-" + formatString;
                string sourceFilePath = baseFolder + fileName + ".psd";
                string pngOutputPath = output + fileName + "_output.png";
                string psdOutputPath = output + fileName + "_output.psd";
                string png2OutputPath = output + fileName + "_updated.png";
                string psd2OutputPath = output + fileName + "_updated.psd";
                string exportPath = output + fileName + "_export." + formatExt;
                using (PsdImage image = (PsdImage)Image.Load(sourceFilePath))
                {
                    var smartObjectLayer = (SmartObjectLayer)image.Layers[0];

                    AssertAreEqual(left, smartObjectLayer.ContentsBounds.Left);
                    AssertAreEqual(top, smartObjectLayer.ContentsBounds.Top);
                    AssertAreEqual(right, smartObjectLayer.ContentsBounds.Right);
                    AssertAreEqual(bottom, smartObjectLayer.ContentsBounds.Bottom);

                    // Let's export the embedded smart object image from the PSD smart object layer
                    smartObjectLayer.ExportContents(exportPath);

                    // Let's check if the original image is saved correctly
                    image.Save(psdOutputPath, new PsdOptions(image));
                    image.Save(pngOutputPath, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });

                    using (var innerImage = (RasterImage)smartObjectLayer.LoadContents(null))
                    {
                        AssertAreEqual(format, innerImage.FileFormat);

                        // Let's invert original smart object image
                        var pixels = innerImage.LoadArgb32Pixels(innerImage.Bounds);
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            var pixel = pixels[i];
                            var alpha = (int)(pixel & 0xff000000);
                            pixels[i] = (~(pixel & 0x00ffffff)) | alpha;
                        }

                        innerImage.SaveArgb32Pixels(innerImage.Bounds, pixels);

                        // Let's replace the embedded smart object image in the PSD layer
                        smartObjectLayer.ReplaceContents(innerImage);
                    }

                    // Let's check if the updated image is saved correctly
                    image.Save(psd2OutputPath, new PsdOptions(image));
                    image.Save(png2OutputPath, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            //ExEnd:SupportOfEmbeddedSmartObjects

            Console.WriteLine("SupportOfEmbeddedSmartObjects executed successfully");
        }
    }
}
