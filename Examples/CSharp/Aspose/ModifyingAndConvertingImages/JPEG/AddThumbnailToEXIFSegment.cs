using Aspose.PSD.Exif;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class AddThumbnailToEXIFSegment
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddThumbnailToEXIFSegment

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
                        var exifData = new JpegExifData();
                        var thumbnailImage = new PsdImage(100, 100);
                        try
                        {
                            // Fill thumbnail data.
                            int[] pixels = new int[thumbnailImage.Width * thumbnailImage.Height];
                            for (int i = 0; i < pixels.Length; i++)
                            {
                                pixels[i] = i;
                            }

                            // Assign thumbnail data.
                            thumbnailImage.SaveArgb32Pixels(thumbnailImage.Bounds, pixels);
                            exifData.Thumbnail = thumbnailImage;
                            thumbnail.JpegOptions.ExifData = exifData;
                        }
                        catch
                        {
                            thumbnailImage.Dispose();
                            throw;
                        }
                    }
                }

                image.Save();

            }

            //ExEnd:AddThumbnailToEXIFSegment

        }
    }
}
