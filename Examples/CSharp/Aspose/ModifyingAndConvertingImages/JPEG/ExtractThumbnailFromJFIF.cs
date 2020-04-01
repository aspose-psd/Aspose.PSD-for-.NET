using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class ExtractThumbnailFromJFIF
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ExtractThumbnailFromJFIF

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "1280px-Zebras_Serengeti.psd"))
            {
                // Iterate over resources.
                foreach (var resource in image.ImageResources)
                {
                    // Find thumbnail resource. Typically they are in the Jpeg file format.
                    if (resource is ThumbnailResource || resource is Thumbnail4Resource)
                    {
                        // Extract thumbnail data and store it as a separate image file.
                        var thumbnail = (ThumbnailResource)resource;
                        var jfif = thumbnail.JpegOptions.Jfif;
                        if (jfif != null)
                        {
                            // extract JFIF data and process.
                        }

                        var exif = thumbnail.JpegOptions.ExifData;
                        if (exif != null)
                        {
                            // extract Exif data and process.
                        }
                    }
                }
            }
            //ExEnd:ExtractThumbnailFromJFIF

        }
    }
}
