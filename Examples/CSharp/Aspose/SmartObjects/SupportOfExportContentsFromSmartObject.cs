using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.SmartObjects;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.SmartObjects
{
    public class SupportOfExportContentsFromSmartObject
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string output = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfExportContentsFromSmartObject
            string source = Path.Combine(baseFolder, "new_panama-papers-8-trans4.psd");
            string exportContentPath = Path.Combine(output, "export_content.jpg");
            string outputUpdated = Path.Combine(output, "smart_object.psd");

            using (PsdImage im = (PsdImage)Image.Load(source))
            {
                SmartObjectLayer smartLayer = (SmartObjectLayer)im.Layers[0];

                // How to export content of Smart Object
                smartLayer.ExportContents(exportContentPath);

                // Creating Smart Object as a Copy
                SmartObjectLayer newLayer = smartLayer.NewSmartObjectViaCopy();
                newLayer.IsVisible = false;
                newLayer.DisplayName = "Duplicate";

                // Get the content of Smart Object for manipulation
                using (RasterImage innerImage = (RasterImage)smartLayer.LoadContents(null))
                {
                    InvertImage(innerImage);
                    smartLayer.ReplaceContents(innerImage);
                }

                im.SmartObjectProvider.UpdateAllModifiedContent();

                PsdOptions psdOptions = new PsdOptions(im);
                im.Save(outputUpdated, psdOptions);
            }
         
            void InvertImage(RasterImage image)
            {
                int[] pixels = image.LoadArgb32Pixels(image.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int alpha = pixel & unchecked((int)0xff000000);
                    pixels[i] = (~(pixel & 0x00ffffff)) | alpha;
                }
                image.SaveArgb32Pixels(image.Bounds, pixels);
            }
            //ExEnd:SupportOfExportContentsFromSmartObject
            
            File.Delete(outputUpdated);
            File.Delete(exportContentPath);

            Console.WriteLine("SupportOfExportContentsFromSmartObject executed successfully");
        }
    }
}