using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.Exif;
using Aspose.PSD.FileFormats.Jpeg;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class ReadandModifyJpegEXIFTags
    {
        public static void Run()
        {
            //ExStart:ReadandModifyJpegEXIFTags
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir+"1280px-Zebras_Serengeti.psd"))
            {
                // Iterate over resources.
                foreach (var resource in image.ImageResources)
                {
                    // Find thumbnail resource. Typically they are in the Jpeg file format.
                    if (resource is ThumbnailResource || resource is Thumbnail4Resource)
                    {
                        // Extract thumbnail data and store it as a separate image file.
                        var thumbnail = (ThumbnailResource)resource;
                        var exifData = thumbnail.JpegOptions.ExifData;
                        if (exifData != null)
                        {
                            // extract Exif data and process.
                            Console.WriteLine("Camera Owner Name: " + exifData.CameraOwnerName);
                            Console.WriteLine("Aperture Value: " + exifData.ApertureValue);
                            Console.WriteLine("Orientation: " + exifData.Orientation);
                            Console.WriteLine("Focal Length: " + exifData.FocalLength);
                            Console.WriteLine("Compression: " + exifData.Compression);
                        }
                    }
                }
            }
            //ExEnd:ReadandModifyJpegEXIFTags

        }
    }
}
