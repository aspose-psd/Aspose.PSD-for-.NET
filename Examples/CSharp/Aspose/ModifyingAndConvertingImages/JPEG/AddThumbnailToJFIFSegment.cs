using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class AddThumbnailToJFIFSegment
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddThumbnailToJFIFSegment

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
                        var jfifData = new FileFormats.Jpeg.JFIFData();
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
                            jfifData.Thumbnail = thumbnailImage;
                            jfifData.XDensity = 1;
                            jfifData.YDensity = 1;
                            thumbnail.JpegOptions.Jfif = jfifData;
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
            //ExEnd:AddThumbnailToJFIFSegment

        }
    }
}
