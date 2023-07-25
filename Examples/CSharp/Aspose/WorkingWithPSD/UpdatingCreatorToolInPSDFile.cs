using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Xmp;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    public class UpdatingCreatorToolInPSDFile
    {
        public static void Run()
        {
            // The path to the documents directory.
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:UpdatingCreatorToolInPSDFile
            //ExSummary:The following code demonstrates the using UpdateMetadata option to update CreatorTool value in xmp data.
            
            string path = Path.Combine(outputDir, "output.psd");
            
            using (var image = new PsdImage(100, 100))
            {
                // If you want the creator tool to change, make sure that the "UpdateMetadata" property is set to true. It's set to true by default.
                var psdOptions = new PsdOptions();
                psdOptions.UpdateMetadata = true;

                // Saving the image. 
                image.Save(path, psdOptions);

                // Checking creator tool in code.
                var xmpData = image.XmpData;
                var basicPackage = image.XmpData.GetPackage(Namespaces.XmpBasic);

                // Here will be updated creator tool info.
                var currentCreatorTool = (string)basicPackage[":CreatorTool"];
            }
            
            //ExEnd:UpdatingCreatorToolInPSDFile

            File.Delete(path);
            
            Console.WriteLine("UpdatingCreatorToolInPSDFile executed successfully");
        }
    }
}