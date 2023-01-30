using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class SupportTextOrientationPropertyEdit
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportTextOrientationPropertyEdit
            //ExSummary:The following code demonstrates the ability to edit the new TextOrientation property. This does not affect rendering at the moment, but only allows you to edit the property value.

            string src = Path.Combine(baseDir, "1336test.psd");
            string output = Path.Combine(outputDir, "out_1336test.psd");

            using (var image = (PsdImage)Image.Load(src))
            {
                var textLayer = image.Layers[1] as TextLayer;
                if (textLayer.TextData.TextOrientation == TextOrientation.Vertical)
                {
                    // Correct reading
                }
                else
                {
                    throw new Exception("Incorrect reading of TextOrientation property value");
                }
            
                textLayer.TextData.TextOrientation = TextOrientation.Horizontal;
                textLayer.TextData.UpdateLayerData();
            
                image.Save(output);
            }
            
            using (var image = (PsdImage)Image.Load(output))
            {
                var textLayer = image.Layers[1] as TextLayer;
                if (textLayer.TextData.TextOrientation == TextOrientation.Horizontal)
                {
                    // Correct reading
                }
                else
                {
                    throw new Exception("Incorrect reading of TextOrientation property value");
                }
            }

            //ExEnd:SupportTextOrientationPropertyEdit

            File.Delete(output);

            Console.WriteLine("SupportTextOrientationPropertyEdit executed successfully");
        }
    }
}