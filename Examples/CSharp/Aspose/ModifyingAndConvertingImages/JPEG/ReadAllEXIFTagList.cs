using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class ReadAllEXIFTagList
    {
        public static void Run()
        {
            //ExStart:ReadAllEXIFTagList
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

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
                        var exifData = thumbnail.JpegOptions.ExifData;
                        if (exifData != null)
                        {
                            Type type = exifData.GetType();
                            PropertyInfo[] properties = type.GetProperties();
                            foreach (PropertyInfo property in properties)
                            {
                                Console.WriteLine(property.Name + ":" + property.GetValue(exifData, null));
                            }
                        }
                    }
                }
            }

            //ExEnd:ReadAllEXIFTagList

        }
    }
}
