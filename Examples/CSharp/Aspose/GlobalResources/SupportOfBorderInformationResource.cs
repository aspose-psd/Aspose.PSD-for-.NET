using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;
using Aspose.PSD.FileFormats.Psd.Resources.ResolutionEnums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.GlobalResources
{
    class SupportOfBorderInformationResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart
            //ExSummary:The following example demonstrates the support of BorderInformationResource resource.

            string sourceFilePath = Path.Combine(SourceDir, "BorderInformationResourceInput.psd");
            string outputFilePath = Path.Combine(OutputDir, "BorderInformationResourceOutput.psd");

            using (var image = (PsdImage)Image.Load(sourceFilePath))
            {
                ResourceBlock[] imageResources = image.ImageResources;
                BorderInformationResource borderInfoResource = null;
                foreach (var imageResource in imageResources)
                {
                    if (imageResource is BorderInformationResource)
                    {
                        borderInfoResource = (BorderInformationResource)imageResource;
                        break;
                    }
                }

                // update BorderInformationResource
                borderInfoResource.Width = 0.1;
                borderInfoResource.Unit = PhysicalUnit.Inches;

                image.Save(outputFilePath);
            }

            //ExEnd
            Console.WriteLine("SupportOfBackgroundColorResource executed successfully");
        }
    }
}
