using System;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportOfPlLdResource
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string output = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfPlLdResource
            //ExSummary:The following code demonstrates the support of the PlLdResource resource.

            void AssertAreEqual(object actual, object expected)
            {
                var areEqual = object.Equals(actual, expected);
                if (!areEqual && actual is Array && expected is Array)
                {
                    var actualArray = (Array)actual;
                    var expectedArray = (Array)actual;
                    if (actualArray.Length == expectedArray.Length)
                    {
                        for (int i = 0; i < actualArray.Length; i++)
                        {
                            if (!object.Equals(actualArray.GetValue(i), expectedArray.GetValue(i)))
                            {
                                break;
                            }
                        }

                        areEqual = true;
                    }
                }

                if (!areEqual)
                {
                    throw new FormatException(
                        string.Format("Actual value {0} are not equal to expected {1}.", actual, expected));
                }
            }

            var sourceFilePath = baseFolder + "LayeredSmartObjects8bit2.psd";
            var outputFilePath = output + "LayeredSmartObjects8bit2_output.psd";
            var expectedValues = new object[]
            {
                new object[]
                {
                    true,
                    "76f05a3b-7523-5e42-a1bb-27f4735bffa0",
                    1,
                    1,
                    0x10,
                    PlacedLayerType.Raster,
                    new double[8]
                    {
                        29.937922786050663,
                        95.419959734187131,
                        126.85445817782261,
                        1.0540625423957124,
                        172.20861031651307,
                        47.634102808208553,
                        75.292074924741144,
                        142
                    },
                    0d,
                    0d,
                    0d,
                    0d,
                    0d,
                    149d,
                    310d,
                    4,
                    4,
                    UnitTypes.Pixels,
                    new double[16]
                    {
                        0.0d, 103.33333333333333d, 206.66666666666666d, 310.0d,
                        0.0d, 103.33333333333333d, 206.66666666666666d, 310.0d,
                        0.0d, 103.33333333333333d, 206.66666666666666d, 310.0d,
                        0.0d, 103.33333333333333d, 206.66666666666666d, 310.0d
                    },
                    UnitTypes.Pixels,
                    new double[16]
                    {
                        0.0d, 0.0d, 0.0d, 0.0d,
                        49.666666666666664d, 49.666666666666664d, 49.666666666666664d, 49.666666666666664d,
                        99.333333333333329d, 99.333333333333329d, 99.333333333333329d, 99.333333333333329d,
                        149, 149, 149, 149,
                    },
                },
                new object[]
                {
                    true,
                    "cf0477a8-8f92-ac4f-9462-f78e26234851",
                    1,
                    1,
                    0x10,
                    PlacedLayerType.Raster,
                    new double[8]
                    {
                        37.900314592235681,
                        -0.32118219433001371,
                        185.94210608826535,
                        57.7076819802063,
                        153.32047433609358,
                        140.9311755779743,
                        5.2786828400639294,
                        82.902311403437977,
                    },
                    0d,
                    0d,
                    0d,
                    0d,
                    0d,
                    721d,
                    1280d,
                    4,
                    4,
                    UnitTypes.Pixels,
                    new double[16]
                    {
                        0.0, 426.66666666666663, 853.33333333333326, 1280,
                        0.0, 426.66666666666663, 853.33333333333326, 1280,
                        0.0, 426.66666666666663, 853.33333333333326, 1280,
                        0.0, 426.66666666666663, 853.33333333333326, 1280,
                    },
                    UnitTypes.Pixels,
                    new double[16]
                    {
                        0.0, 0.0, 0.0, 0.0,
                        240.33333333333331, 240.33333333333331, 240.33333333333331, 240.33333333333331,
                        480.66666666666663, 480.66666666666663, 480.66666666666663, 480.66666666666663,
                        721, 721, 721, 721,
                    },
                    0,
                    0
                }
            };

            using (PsdImage image = (PsdImage)Image.Load(sourceFilePath))
            {
                PlLdResource resource = null;
                int index = 0;
                foreach (Layer imageLayer in image.Layers)
                {
                    foreach (var imageResource in imageLayer.Resources)
                    {
                        resource = imageResource as PlLdResource;
                        if (resource != null)
                        {
                            var expectedValue = (object[])expectedValues[index++];
                            AssertAreEqual(expectedValue[0], resource.IsCustom);
                            AssertAreEqual(expectedValue[1], resource.UniqueId.ToString());
                            AssertAreEqual(expectedValue[2], resource.PageNumber);
                            AssertAreEqual(expectedValue[3], resource.TotalPages);
                            AssertAreEqual(expectedValue[4], resource.AntiAliasPolicy);
                            AssertAreEqual(expectedValue[5], resource.PlacedLayerType);
                            AssertAreEqual(8, resource.TransformMatrix.Length);
                            AssertAreEqual((double[])expectedValue[6], resource.TransformMatrix);
                            AssertAreEqual(expectedValue[7], resource.Value);
                            AssertAreEqual(expectedValue[8], resource.Perspective);
                            AssertAreEqual(expectedValue[9], resource.PerspectiveOther);
                            AssertAreEqual(expectedValue[10], resource.Top);
                            AssertAreEqual(expectedValue[11], resource.Left);
                            AssertAreEqual(expectedValue[12], resource.Bottom);
                            AssertAreEqual(expectedValue[13], resource.Right);
                            AssertAreEqual(expectedValue[14], resource.UOrder);
                            AssertAreEqual(expectedValue[15], resource.VOrder);
                            if (resource.IsCustom)
                            {
                                AssertAreEqual(expectedValue[16], resource.HorizontalMeshPointUnit);
                                AssertAreEqual((double[])expectedValue[17], resource.HorizontalMeshPoints);
                                AssertAreEqual(expectedValue[18], resource.VerticalMeshPointUnit);
                                AssertAreEqual((double[])expectedValue[19], resource.VerticalMeshPoints);
                                var temp = resource.VerticalMeshPoints;
                                resource.VerticalMeshPoints = resource.HorizontalMeshPoints;
                                resource.HorizontalMeshPoints = temp;
                            }

                            resource.UniqueId = Guid.NewGuid();
                            resource.PageNumber = 2;
                            resource.TotalPages = 3;
                            resource.AntiAliasPolicy = 30;
                            resource.PlacedLayerType = PlacedLayerType.Vector;
                            resource.Value = 1.23456789;
                            resource.Perspective = 0.123456789;
                            resource.PerspectiveOther = 0.987654321;
                            resource.Top = -126;
                            resource.Left = -215;
                            resource.Bottom = 248;
                            resource.Right = 145;
                            resource.UOrder = 6;
                            resource.VOrder = 9;

                            break;
                        }
                    }
                }

                AssertAreEqual(true, resource != null);
                image.Save(outputFilePath, new PsdOptions(image));
            }

            //ExEnd:SupportOfPlLdResource

            Console.WriteLine("SupportOfPlLdResource executed successfully");
        }
    }
}
