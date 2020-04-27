using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;
using System;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.GlobalResources
{
    class SupportOfBackgroundColorResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfBackgroundColorResource
            //ExSummary:The following example demonstrates the support of BackgroundColorResource resource.
            string sourceFilePath = Path.Combine(SourceDir, "BackgroundColorResourceInput.psd");
            string outputFilePath = Path.Combine(OutputDir, "BackgroundColorResourceOutput.psd");

            using (var image = (PsdImage)Image.Load(sourceFilePath))
            {
                ResourceBlock[] imageResources = image.ImageResources;
                BackgroundColorResource backgroundColorResource = null;
                foreach (var imageResource in imageResources)
                {
                    if (imageResource is BackgroundColorResource)
                    {
                        backgroundColorResource = (BackgroundColorResource)imageResource;
                        break;
                    }
                }

                // update BackgroundColorResource
                backgroundColorResource.Color = Color.DarkRed;

                image.Save(outputFilePath);
            }

            //ExEnd:SupportOfBackgroundColorResource
            Console.WriteLine("SupportOfBackgroundColorResource executed successfully");
        }
    }
}
