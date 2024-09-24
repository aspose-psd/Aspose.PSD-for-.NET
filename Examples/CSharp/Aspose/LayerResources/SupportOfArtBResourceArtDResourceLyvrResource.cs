using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    public class SupportOfArtBResourceArtDResourceLyvrResource
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfArtBResourceArtDResourceLyvrResource
            //ExSummary:The following code demonstrates the support of Artboard resources.
            
            string srcFile = Path.Combine(baseDir, "artboard1.psd");

            using (PsdImage psdImage = (PsdImage)Image.Load(srcFile))
            {
                ArtDResource artDResource = (ArtDResource)psdImage.GlobalLayerResources[2];

                ArtBResource artBResource1 = (ArtBResource)psdImage.Layers[2].Resources[7];
                ArtBResource artBResource2 = (ArtBResource)psdImage.Layers[5].Resources[7];

                LyvrResource lyvrResource1 = (LyvrResource)psdImage.Layers[2].Resources[9];
                LyvrResource lyvrResource2 = (LyvrResource)psdImage.Layers[5].Resources[9];

                var countStruct = (IntegerStructure)artDResource.Items[0];
                AssertAreEqual(2, countStruct.Value);

                var presetNameStruct1 = (StringStructure)artBResource1.Items[2];
                AssertAreEqual("iPhone X\0", presetNameStruct1.Value);

                var presetNameStruct2 = (StringStructure)artBResource2.Items[2];
                AssertAreEqual("iPhone X\0", presetNameStruct2.Value);

                AssertAreEqual(160, lyvrResource1.Version);
                AssertAreEqual(160, lyvrResource2.Version);
            }

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }
            
            //ExEnd:SupportOfArtBResourceArtDResourceLyvrResource

            Console.WriteLine("SupportOfArtBResourceArtDResourceLyvrResource executed successfully");
        }
    }
}