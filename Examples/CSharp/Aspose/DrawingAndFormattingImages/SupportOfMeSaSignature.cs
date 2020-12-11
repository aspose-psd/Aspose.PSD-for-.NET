using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class SupportOfMeSaSignature
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string outputFolder = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfMeSaSignature
            //ExSummary:The next code example demonstrates ability to correct load and save PSD files with resources with MeSa signature.

            void AreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Values are not equal.");
                }
            }

            string srcFile = baseFolder + "GST-CHALLAN(2)1..psd";
            string output = outputFolder + "output.psd";

            using (PsdImage psdImage = (PsdImage)Image.Load(srcFile))
            {
                AreEqual(ResourceBlock.ResouceBlockMeSaSignature, psdImage.ImageResources[23].Signature);
                AreEqual(ResourceBlock.ResouceBlockMeSaSignature, psdImage.ImageResources[24].Signature);
                psdImage.Save(output);
            }

            //ExEnd:SupportOfMeSaSignature

            Console.WriteLine("SupportOfMeSaSignature executed successfully");
        }
    }
}
