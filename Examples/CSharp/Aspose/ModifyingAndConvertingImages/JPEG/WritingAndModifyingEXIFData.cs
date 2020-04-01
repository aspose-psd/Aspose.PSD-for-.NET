using Aspose.PSD.Exif.Enums;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class WritingAndModifyingEXIFData
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:WritingAndModifyingEXIFData

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                // Iterate over resources.
                foreach (var resource in image.ImageResources)
                {
                    // Find thumbnail resource. Typically they are in the Jpeg file format.
                    if (resource is ThumbnailResource || resource is Thumbnail4Resource)
                    {
                        // Extract exif data and print to the console.
                        var exif = ((ThumbnailResource)resource).JpegOptions.ExifData;
                        if (exif != null)
                        {
                            // Set LensMake, WhiteBalance, Flash information Save the image
                            exif.LensMake = "Sony";
                            exif.WhiteBalance = ExifWhiteBalance.Auto;
                            exif.Flash = ExifFlash.Fired;
                        }
                    }
                }

                image.Save(dataDir + "aspose_out.psd");
            }
            //ExEnd:WritingAndModifyingEXIFData
        }
    }
}
