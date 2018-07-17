using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.Exif;
using Aspose.PSD.FileFormats.Jpeg;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class ReadAllEXIFTags
    {
        public static void Run()
        {
            //ExStart:ReadAllEXIFTags
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
                        // Extract exif data and print to the console.
                        var exif = ((ThumbnailResource)resource).JpegOptions.ExifData;
                        if (exif != null)
                        {
                            Type type = exif.GetType();
                            PropertyInfo[] properties = type.GetProperties();
                            foreach (PropertyInfo property in properties)
                            {
                                Console.WriteLine(property.Name + ":" + property.GetValue(exif, null));
                            }
                        }
                    }
                }
            }
            //ExEnd:ReadAllEXIFTags
        }
    }
}
