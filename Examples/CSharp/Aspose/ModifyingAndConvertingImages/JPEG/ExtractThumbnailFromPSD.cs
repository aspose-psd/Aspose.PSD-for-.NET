using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG
{
    class ExtractThumbnailFromPSD
    {
        public static void Run()
        {
            //ExStart:ExtractThumbnailFromPSD
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
                        var data = ((ThumbnailResource)resource).ThumbnailArgb32Data;
                        using (PsdImage extractedThumnailImage = new PsdImage(thumbnail.Width, thumbnail.Height))
                        {
                            extractedThumnailImage.SaveArgb32Pixels(extractedThumnailImage.Bounds, data);
                            extractedThumnailImage.Save(dataDir+"extracted_thumbnail.jpg", new JpegOptions());
                        }
                    }
                }
            }
            //ExEnd:ExtractThumbnailFromPSD

        }
    }
}
