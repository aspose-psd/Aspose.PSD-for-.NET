using System;
using System.Globalization;
using System.IO;
using Aspose.PSD.FileFormats.Ai;
using Aspose.PSD.Xmp;
using Aspose.PSD.Xmp.Schemas.XmpBaseSchema;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI
{
    public class SupportOfAiImageXmpDataProperty
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();

            //ExStart:SupportOfAiImageXmpDataProperty
            //ExSummary:The following code demonstrates the support of AiImage.XmpData property.
            
            string sourceFile = Path.Combine(baseDir, "ai_one.ai");

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception("Objects are not equal.");
                }
            }

            void AssertIsNotNull(object testObject)
            {
                if (testObject == null)
                {
                    throw new Exception("Test object are null.");
                }
            }

            string creatorToolKey = ":CreatorTool";
            string nPagesKey = "xmpTPg:NPages";
            string unitKey = "stDim:unit";
            string heightKey = "stDim:h";
            string widthKey = "stDim:w";

            string expectedCreatorTool = "Adobe Illustrator CC 22.1 (Windows)";
            string expectedNPages = "1";
            string expectedUnit = "Pixels";
            double expectedHeight = 768;
            double expectedWidth = 1366;

            using (AiImage image = (AiImage)Image.Load(sourceFile))
            {
                // Xmp Metadata was added.
                var xmpMetaData = image.XmpData;

                AssertIsNotNull(xmpMetaData);

                // No we can get access to Xmp Packages of AI files.
                var basicPackage = xmpMetaData.GetPackage(Namespaces.XmpBasic) as XmpBasicPackage;
                var package = xmpMetaData.Packages[4];

                // And we have access to the content of these packages.
                var creatorTool = basicPackage[creatorToolKey].ToString();
                var nPages = package[nPagesKey];
                var unit = package[unitKey];
                var height = double.Parse(package[heightKey].ToString(), CultureInfo.InvariantCulture);
                var width = double.Parse(package[widthKey].ToString(), CultureInfo.InvariantCulture);

                AssertAreEqual(creatorTool, expectedCreatorTool);
                AssertAreEqual(nPages, expectedNPages);
                AssertAreEqual(unit, expectedUnit);
                AssertAreEqual(height, expectedHeight);
                AssertAreEqual(width, expectedWidth);
            }
            
            //ExEnd:SupportOfAiImageXmpDataProperty

            Console.WriteLine("SupportOfAiImageXmpDataProperty executed successfully");
        }
    }
}