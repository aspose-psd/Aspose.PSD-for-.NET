using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.ProgressManagement;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class UsingDocumentConversionProgressHandler
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:UpdateTextLayerInPSDFile

            //The following example demonstrates how you can obtain the document conversion progress 
            string sourceFilePath = Path.Combine(dataDir, "Apple.psd");
            Stream outputStream = new MemoryStream();

            ProgressEventHandler localProgressEventHandler = delegate (ProgressEventHandlerInfo progressInfo)
            {
                string message = string.Format(
                    "{0} {1}: {2} out of {3}",
                    progressInfo.Description,
                    progressInfo.EventType,
                    progressInfo.Value,
                    progressInfo.MaxValue);
                Console.WriteLine(message);
            };

            Console.WriteLine("---------- Loading Apple.psd ----------");
            var loadOptions = new PsdLoadOptions() { ProgressEventHandler = localProgressEventHandler };
            using (PsdImage image = (PsdImage)Image.Load(sourceFilePath, loadOptions))
            {
                Console.WriteLine("---------- Saving Apple.psd to PNG format ----------");
                image.Save(
                    outputStream,
                    new PngOptions()
                    {
                        ColorType = PngColorType.Truecolor,
                        ProgressEventHandler = localProgressEventHandler
                    });

                Console.WriteLine("---------- Saving Apple.psd to PSD format ----------");
                image.Save(
                    outputStream,
                    new PsdOptions()
                    {
                        ColorMode = ColorModes.Rgb,
                        ChannelsCount = 4,
                        ProgressEventHandler = localProgressEventHandler
                    });
            }

            //ExEnd:UpdateTextLayerInPSDFile

            Console.WriteLine("UsingDocumentConversionProgressHandler example executed successfully");
        }
    }
}
