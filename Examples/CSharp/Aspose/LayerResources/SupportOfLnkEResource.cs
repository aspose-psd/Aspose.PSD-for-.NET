using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.AdjustmentLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class SupportOfLnkEResource
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseFolder = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfLnkEResource

            string message = "The example works incorrectly.";
            void AssertAreEqual(object actual, object expected)
            {
                if (!object.Equals(actual, expected))
                {
                    throw new FormatException(message);
                }
            }

            // This example demonstrates how to get and set properties of the Psd LnkE Resource that contains information about an external linked file.
            void ExampleOfLnkEResourceSupport(
                string fileName,
                int length,
                int length2,
                int length3,
                int length4,
                string fullPath,
                string date,
                double assetModTime,
                string childDocId,
                bool locked,
                string uid,
                string name,
                string originalFileName,
                string fileType,
                long size,
                int version)
            {
                string outputPath = Path.Combine(outputDir, fileName);
                using (PsdImage image = (PsdImage) Image.Load(Path.Combine(baseFolder, fileName)))
                {
                    LnkeResource lnkeResource = null;
                    foreach (var resource in image.GlobalLayerResources)
                    {
                        lnkeResource = resource as LnkeResource;
                        if (lnkeResource != null)
                        {
                            LiFeDataSource lifeSource = lnkeResource[0];
                            AssertAreEqual(lnkeResource.Length, length);
                            AssertAreEqual(lifeSource.UniqueId, new Guid(uid));
                            AssertAreEqual(lifeSource.FullPath, fullPath);
                            AssertAreEqual(lifeSource.Date.ToString(CultureInfo.InvariantCulture), date);
                            AssertAreEqual(lifeSource.AssetModTime, assetModTime);
                            AssertAreEqual(lifeSource.FileName, name);
                            AssertAreEqual(lifeSource.FileSize, size);
                            AssertAreEqual(lifeSource.ChildDocId, childDocId);
                            AssertAreEqual(lifeSource.Version, version);
                            AssertAreEqual(lifeSource.FileType.TrimEnd(' '), fileType);
                            AssertAreEqual(lifeSource.FileCreator.TrimEnd(' '), string.Empty);
                            AssertAreEqual(lifeSource.OriginalFileName, originalFileName);
                            AssertAreEqual(false, lnkeResource.IsEmpty);
                            AssertAreEqual(true, lifeSource.Type == LinkDataSourceType.liFE);
                            if (version == 7)
                            {
                                AssertAreEqual(lifeSource.AssetLockedState, locked);
                            }

                            if (lifeSource.HasFileOpenDescriptor)
                            {
                                AssertAreEqual(lifeSource.CompId, -1);
                                AssertAreEqual(lifeSource.OriginalCompId, -1);
                            }

                            lifeSource.FullPath =
                                @"file:///C:/Aspose/net/Aspose.Psd/test/testdata/Images/Psd/SmartObjects/rgb8_2x2.png";
                            AssertAreEqual(lnkeResource.Length, length2);
                            lifeSource.FileName = "rgb8_2x23.png";
                            AssertAreEqual(lnkeResource.Length, length3);
                            lifeSource.ChildDocId = Guid.NewGuid().ToString();
                            AssertAreEqual(lnkeResource.Length, length4);
                            lifeSource.Date = DateTime.Now;
                            lifeSource.AssetModTime = double.MaxValue;
                            lifeSource.FileSize = long.MaxValue;
                            lifeSource.FileType = "test";
                            lifeSource.FileCreator = "file";
                            lifeSource.CompId = int.MaxValue;
                            break;
                        }
                    }

                    AssertAreEqual(true, lnkeResource != null);

                    image.Save(outputPath, new PsdOptions(image));
                }
            }

            // This example demonstrates how to get and set properties of the Psd LnkeResource that contains information about external linked JPEG file.
            ExampleOfLnkEResourceSupport(
                @"photooverlay_5_new.psd",
                0x21c,
                0x26c,
                0x274,
                0x27c,
                @"file:///C:/Users/cvallejo/Desktop/photo.jpg",
                "05/09/2017 22:24:51",
                0,
                "F062B9DB73E8D124167A4186E54664B0",
                false,
                "02df245c-36a2-11e7-a9d8-fdb2b61f07a7",
                "photo.jpg",
                "photo.jpg",
                "JPEG",
                0x1520d,
                7);

            // This example demonstrates how to get and set properties of the PSD LnkeResource that contains information about an external linked PNG file.
            ExampleOfLnkEResourceSupport(
                "rgb8_2x2_linked.psd",
                0x284,
                0x290,
                0x294,
                0x2dc,
                @"file:///C:/Aspose/net/Aspose.Psd/test/testdata/Issues/PSDNET-491/rgb8_2x2.png",
                "04/14/2020 14:23:44",
                0,
                string.Empty,
                false,
                "5867318f-3174-9f41-abca-22f56a75247e",
                "rgb8_2x2.png",
                "rgb8_2x2.png",
                "png",
                0x53,
                7);

            // This example demonstrates how to get and set properties of the PSD LnkeResource that contains information about two external linked PNG and PSD files.
            ExampleOfLnkEResourceSupport(
                "rgb8_2x2_linked2.psd",
                0x590,
                0x580,
                0x554,
                0x528,
                @"file:///C:/Aspose/net/Aspose.Psd/test/testdata/Images/Psd/AddColorBalanceAdjustmentLayer.psd",
                "01/15/2020 13:02:00",
                0,
                "adobe:docid:photoshop:9312f484-3403-a644-8973-e725abc95fb7",
                false,
                "78a5b588-364f-0940-a2e5-a450a031aa48",
                "AddColorBalanceAdjustmentLayer.psd",
                "AddColorBalanceAdjustmentLayer.psd",
                "8BPS",
                0x4aea,
                7);

            // This example demonstrates how to get and set properties of the Photoshop Psd LnkeResource that contains information about an external linked CC Libraries Asset.
            ExampleOfLnkEResourceSupport(
                "rgb8_2x2_asset_linked.psd",
                0x398,
                0x38c,
                0x388,
                0x3d0,
                @"CC Libraries Asset “rgb8_2x2_linked/rgb8_2x2” (Feature is available in Photoshop CC 2015)",
                "01/01/0001 00:00:00",
                1588890915488.0d,
                string.Empty,
                false,
                "ec15f0a8-7f13-a640-b928-7d29c6e9859c",
                "rgb8_2x2_linked",
                "rgb8_2x2.png",
                "png",
                0,
                7);

            //ExEnd:SupportOfLnkEResource

            Console.WriteLine("SupportOfLnkEResource executed successfully");
        }
    }
}
