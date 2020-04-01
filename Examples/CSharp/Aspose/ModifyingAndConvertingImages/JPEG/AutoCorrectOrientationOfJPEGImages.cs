using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class AutoCorrectOrientationOfJPEGImages
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AutoCorrectOrientationOfJPEGImages

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "aspose_out.psd"))
            {
                // Iterate over resources.
                foreach (var resource in image.ImageResources)
                {
                    // Find thumbnail resource. Typically they are in the Jpeg file format.
                    if (resource is ThumbnailResource || resource is Thumbnail4Resource)
                    {
                        // Adjust thumbnail data.
                        var thumbnail = (ThumbnailResource)resource;
                        var exifData = thumbnail.JpegOptions.ExifData;
                        if (exifData != null && exifData.Thumbnail != null)
                        {
                            // If there is thumbnail stored then auto-rotate it.
                            // JpegImage jpegImage = exifData.Thumbnail as JpegImage;
                            // if (jpegImage != null)
                            // {
                            //    jpegImage.AutoRotate();
                            // }
                        }
                    }
                }

                // Save image.
                image.Save();
            }

            //ExEnd:AutoCorrectOrientationOfJPEGImages

        }
    }
}
