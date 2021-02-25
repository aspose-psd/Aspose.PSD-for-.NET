using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    class SupportOfConvertingLayerToSmartObject
    {
        public static void Run()
        {
            //ExStart:SupportOfConvertingLayerToSmartObject

            // Tests that the layer, imported from an image, is converted to smart object layer and the saved PSD file is correct.

            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            string outputFilePath = OutputDir + "layerTest2.psd";
            string outputPngFilePath = Path.ChangeExtension(outputFilePath, ".png");
            using (PsdImage image = (PsdImage)Image.Load(SourceDir + "layerTest1.psd"))
            {
                string layerFilePath = SourceDir + "picture.jpg";
                using (var stream = new FileStream(layerFilePath, FileMode.Open))
                {
                    Layer layer = null;
                    try
                    {
                        layer = new Layer(stream);
                        image.AddLayer(layer);
                    }
                    catch (Exception)
                    {
                        if (layer != null)
                        {
                            layer.Dispose();
                        }

                        throw;
                    }

                    var layer2 = image.Layers[2];
                    var layer3 = image.SmartObjectProvider.ConvertToSmartObject(image.Layers.Length - 1);
                    var bounds = layer3.Bounds;
                    layer3.Left = (image.Width - layer3.Width) / 2;
                    layer3.Top = layer2.Top;
                    layer3.Right = layer3.Left + bounds.Width;
                    layer3.Bottom = layer3.Top + bounds.Height;

                    image.Save(outputFilePath);
                    image.Save(outputPngFilePath, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            //ExEnd:SupportOfConvertingLayerToSmartObject

            File.Delete(outputFilePath);
            File.Delete(outputPngFilePath);

            Console.WriteLine("SupportOfConvertingLayerToSmartObject executed successfully");
        }
    }
}
