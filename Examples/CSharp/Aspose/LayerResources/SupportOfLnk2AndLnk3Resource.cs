using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportOfLnk2AndLnk3Resource
    {
        public static void Run()
        {
            string baseFolder = RunExamples.GetDataDir_PSD();
            string output = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfLnk2AndLnk3Resource
            //ExSummary:This example demonstrates how to get and set properties of the Lnk2Resource and Lnk3Resource.

            void AssertAreEqual(object expected, object actual)
            {
                if (!object.Equals(actual, expected))
                {
                    throw new FormatException(string.Format("Actual value {0} are not equal to expected {1}.", actual, expected));
                }
            }

            object[] Lnk2ResourceSupportCases = new object[]
            {
                new object[]
                {
                    "00af34a0-a90b-674d-a821-73ee508c5479",
                    "rgb8_2x2.png",
                    "png",
                    string.Empty,
                    0x53,
                    0d,
                    string.Empty,
                    7,
                    true,
                    0x124L,
                    0x74cL
                }
            };

            object[] LayeredLnk2ResourceSupportCases = new object[]
            {
                new object[]
                {
                    "69ac1c0d-1b74-fd49-9c7e-34a7aa6299ef",
                    "huset.jpg",
                    "JPEG",
                    string.Empty,
                    0x9d46,
                    0d,
                    "xmp.did:0F94B342065B11E395B1FD506DED6B07",
                    7,
                    true,
                    0x9E60L,
                    0xc60cL
                },
                new object[]
                {
                    "5a7d1965-0eae-b24e-a82f-98c7646424c2",
                    "panama-papers.jpg",
                    "JPEG",
                    string.Empty,
                    0xF56B,
                    0d,
                    "xmp.did:BDE940CBF51B11E59D759CDA690663E3",
                    7,
                    true,
                    0xF694L,
                    0x10dd4L
                },
            };

            object[] LayeredLnk3ResourceSupportCases = new object[]
            {
                new object[]
                {
                    "2fd7ba52-0221-de4c-bdc4-1210580c6caa",
                    "panama-papers.jpg",
                    "JPEG",
                    string.Empty,
                    0xF56B,
                    0d,
                    "xmp.did:BDE940CBF51B11E59D759CDA690663E3",
                    7,
                    true,
                    0xF694L,
                    0x10dd4L
                },
                new object[]
                {
                    "372d52eb-5825-8743-81a7-b6f32d51323d",
                    "huset.jpg",
                    "JPEG",
                    string.Empty,
                    0x9d46,
                    0d,
                    "xmp.did:0F94B342065B11E395B1FD506DED6B07",
                    7,
                    true,
                    0x9E60L,
                    0xc60cL
                },
            };

            var basePath = Path.Combine(baseFolder, "") + Path.DirectorySeparatorChar;

            // Saves the data of a smart object in PSD file to a file.
            void SaveSmartObjectData(string prefix, string fileName, byte[] data)
            {
                var filePath = prefix + "_" + fileName;

                using (var container = FileStreamContainer.CreateFileStream(filePath, false))
                {
                    container.Write(data);
                }
            }

            // Loads the new data for a smart object in PSD file.
            byte[] LoadNewData(string fileName)
            {
                using (var container = FileStreamContainer.OpenFileStream(basePath + fileName))
                {
                    return container.ToBytes();
                }
            }

            // Gets and sets properties of the PSD Lnk2 / Lnk3 Resource and its liFD data sources in PSD image
            void ExampleOfLnk2ResourceSupport(
                string fileName,
                int dataSourceCount,
                int length,
                int newLength,
                object[] dataSourceExpectedValues)
            {
                using (PsdImage image = (PsdImage)Image.Load(basePath + fileName))
                {
                    Lnk2Resource lnk2Resource = null;
                    foreach (var resource in image.GlobalLayerResources)
                    {
                        lnk2Resource = resource as Lnk2Resource;
                        if (lnk2Resource != null)
                        {
                            AssertAreEqual(lnk2Resource.DataSourceCount, dataSourceCount);
                            AssertAreEqual(lnk2Resource.Length, length);
                            AssertAreEqual(lnk2Resource.IsEmpty, false);

                            for (int i = 0; i < lnk2Resource.DataSourceCount; i++)
                            {
                                LiFdDataSource lifdSource = lnk2Resource[i];
                                object[] expected = (object[])dataSourceExpectedValues[i];
                                AssertAreEqual(LinkDataSourceType.liFD, lifdSource.Type);
                                AssertAreEqual(new Guid((string)expected[0]), lifdSource.UniqueId);
                                AssertAreEqual(expected[1], lifdSource.OriginalFileName);
                                AssertAreEqual(expected[2], lifdSource.FileType.TrimEnd(' '));
                                AssertAreEqual(expected[3], lifdSource.FileCreator.TrimEnd(' '));
                                AssertAreEqual(expected[4], lifdSource.Data.Length);
                                AssertAreEqual(expected[5], lifdSource.AssetModTime);
                                AssertAreEqual(expected[6], lifdSource.ChildDocId);
                                AssertAreEqual(expected[7], lifdSource.Version);
                                AssertAreEqual((bool)expected[8], lifdSource.HasFileOpenDescriptor);
                                AssertAreEqual(expected[9], lifdSource.Length);

                                if (lifdSource.HasFileOpenDescriptor)
                                {
                                    AssertAreEqual(-1, lifdSource.CompId);
                                    AssertAreEqual(-1, lifdSource.OriginalCompId);
                                    lifdSource.CompId = int.MaxValue;
                                }

                                SaveSmartObjectData(
                                    output + fileName,
                                    lifdSource.OriginalFileName,
                                    lifdSource.Data);
                                lifdSource.Data = LoadNewData("new_" + lifdSource.OriginalFileName);
                                AssertAreEqual(expected[10], lifdSource.Length);

                                lifdSource.ChildDocId = Guid.NewGuid().ToString();
                                lifdSource.AssetModTime = double.MaxValue;
                                lifdSource.FileType = "test";
                                lifdSource.FileCreator = "me";
                            }

                            AssertAreEqual(newLength, lnk2Resource.Length);
                            break;
                        }
                    }

                    AssertAreEqual(true, lnk2Resource != null);
                    if (image.BitsPerChannel < 32) // 32 bit per channel saving is not supported yet
                    {
                        image.Save(output + fileName, new PsdOptions(image));
                    }
                }
            }

            // This example demonstrates how to get and set properties of the PSD Lnk2 Resource and its liFD data sources for 8 bit per channel.
            ExampleOfLnk2ResourceSupport("rgb8_2x2_embedded_png.psd", 1, 0x12C, 0x0000079c, Lnk2ResourceSupportCases);

            // This example demonstrates how to get and set properties of the PSD Lnk3 Resource and its liFD data sources for 32 bit per channel.
            ExampleOfLnk2ResourceSupport("Layered PSD file smart objects.psd", 2, 0x19504, 0x0001d3e0, LayeredLnk3ResourceSupportCases);

            // This example demonstrates how to get and set properties of the PSD Lnk2 Resource and its liFD data sources for 16 bit per channel.
            ExampleOfLnk2ResourceSupport("LayeredSmartObjects16bit.psd", 2, 0x19504, 0x0001d3e0, LayeredLnk2ResourceSupportCases);

            //ExEnd:SupportOfLnk2AndLnk3Resource

            Console.WriteLine("SupportOfLnk2AndLnk3Resource executed successfully");
        }
    }
}
