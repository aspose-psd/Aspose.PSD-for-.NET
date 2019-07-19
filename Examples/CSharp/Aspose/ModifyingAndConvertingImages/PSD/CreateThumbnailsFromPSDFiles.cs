using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Bmp;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Resources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class CreateThumbnailsFromPSDFiles
    {
        public static void Run()
        {
            //ExStart:CreateThumbnailsFromPSDFiles
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and caste it into PsdImage
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                int index = 0;
                // Iterate over the PSD resources
                foreach (var resource in image.ImageResources)
                {
                    index++;
                    // Check if the resource is of thumbnail type
                    if (resource is ThumbnailResource)
                    {
                        // Retrieve the ThumbnailResource and Check the format of the ThumbnailResource
                        var thumbnail = (ThumbnailResource)resource;
                        if (thumbnail.Format == ThumbnailFormat.KJpegRgb)
                        {
                            // Create a new image by specifying the width and height,  Store the pixels of thumbnail on to the newly created image and save image
                           PsdImage thumnailImage = new PsdImage(thumbnail.Width, thumbnail.Height);

                            thumnailImage.SavePixels(thumnailImage.Bounds, thumbnail.ThumbnailData);
                            thumnailImage.Save(dataDir + "CreateThumbnailsFromPSDFiles_out_"+index.ToString()+".bmp", new BmpOptions());
                        }
                    }
                }
            }

            //ExEnd:CreateThumbnailsFromPSDFiles

        }
    }
}
