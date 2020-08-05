using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.VectorPaths;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.GlobalResources
{
    class SupportOfWorkingPathResource
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string outputFolder = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfWorkingPathResource
            //ExSummary:This example demonstrates the support of 'WorkingPathResource' resource in PsdImage.ImageResources fo correct working of Crop operation.

            string sourceFile = Path.Combine(baseFolder, "WorkingPathResourceInput.psd");
            string outputFile = Path.Combine(outputFolder, "WorkingPathResourceOutput.psd");

            // Crop image and save.
            using (var psdImage = (PsdImage)Image.Load(sourceFile))
            {
                // Search WorkingPathResource resource.
                ResourceBlock[] imageResources = psdImage.ImageResources;
                WorkingPathResource workingPathResource = null;
                foreach (var imageResource in imageResources)
                {
                    if (imageResource is WorkingPathResource)
                    {
                        workingPathResource = (WorkingPathResource)imageResource;
                        break;
                    }
                }
                BezierKnotRecord record = workingPathResource.Paths[3] as BezierKnotRecord;

                if (record.Points[0].X != 2572506 || record.Points[0].Y != 8535408)
                {
                    throw new Exception("Values is incorrect.");
                }

                // Crop and save.
                psdImage.Crop(0, 500, 0, 200);
                psdImage.Save(outputFile);
            }

            // Load saved image and check the changes.
            using (var psdImage = (PsdImage)Image.Load(outputFile))
            {
                // Search WorkingPathResource resource.
                ResourceBlock[] imageResources = psdImage.ImageResources;
                WorkingPathResource workingPathResource = null;
                foreach (var imageResource in imageResources)
                {
                    if (imageResource is WorkingPathResource)
                    {
                        workingPathResource = (WorkingPathResource)imageResource;
                        break;
                    }
                }
                BezierKnotRecord record = workingPathResource.Paths[3] as BezierKnotRecord;

                if (record.Points[0].X != 4630510 || record.Points[0].Y != 22761088)
                {
                    throw new Exception("Values is incorrect.");
                }
            }

            //ExEnd:SupportOfWorkingPathResource

            Console.WriteLine("SupportOfWorkingPathResource executed successfully");
        }
    }
}
