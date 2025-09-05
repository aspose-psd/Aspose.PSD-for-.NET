using System;
using System.IO;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithPSD
{
    public class EditMetadataInReadonlyMode
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:EditMetadataInReadonlyMode
            //ExSummary:Demonstrates editing and saving PSD metadata using ReadOnlyMode.MetadataEdit.

            string sourceFile = Path.Combine(baseDir, "psdnet2382.psd");
            string outputFile = Path.Combine(outputDir, "output.psd");

            string testMetadata = "Updated metadata text";

            using (PsdImage psdImage = (PsdImage)Image.Load(sourceFile,
                new PsdLoadOptions() { ReadOnlyType = ReadOnlyMode.MetadataEdit })) // Sets the of ReadOnlyMode to true
            {
                AssertAreNotEqual(testMetadata, psdImage.XmpData.Meta.AdobeXmpToolkit);

                // Change metadata in ReadOnlyMode
                psdImage.XmpData.Meta.AdobeXmpToolkit = testMetadata;

                // Save changed metadata in ReadOnlyMode
                psdImage.Save(outputFile);
            }

            using (PsdImage psdImage = (PsdImage)Image.Load(outputFile)) // Sets the of ReadOnlyMode to true
            {
                AssertAreEqual(testMetadata, psdImage.XmpData.Meta.AdobeXmpToolkit);
            }

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects should be equal, but they don't.");
                }
            }

            void AssertAreNotEqual(object obj1, object obj2)
            {
                if (object.Equals(obj1, obj2))
                {
                    throw new Exception("Objects should not be equal, but they are equal.");
                }
            }

            //ExEnd:EditMetadataInReadonlyMode

            File.Delete(outputFile);

            Console.WriteLine("EditMetadataInReadonlyMode executed successfully");
        }
    }
}
