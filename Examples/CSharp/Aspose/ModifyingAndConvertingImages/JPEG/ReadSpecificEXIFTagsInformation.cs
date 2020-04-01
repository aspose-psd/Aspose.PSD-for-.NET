using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class ReadSpecificEXIFTagsInformation
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ReadSpecificEXIFTagsInformation

            // Load PSD image.
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "1280px-Zebras_Serengeti.psd"))
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
                            Console.WriteLine("Exif WhiteBalance: " + exif.WhiteBalance);
                            Console.WriteLine("Exif PixelXDimension: " + exif.PixelXDimension);
                            Console.WriteLine("Exif PixelYDimension: " + exif.PixelYDimension);
                            Console.WriteLine("Exif ISOSpeed: " + exif.ISOSpeed);
                            Console.WriteLine("Exif FocalLength: " + exif.FocalLength);
                        }
                    }
                }
            }
            //ExEnd:ReadSpecificEXIFTagsInformation
        }
    }
}
