using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG
{
    class ChangeBackgroundColor
    {
        public static void Run()
        {
            //ExStart:ChangeBackgroundColor
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                // Convert to PngImage based on PsdImage.
                using (PngImage pngImage = new PngImage(psdImage))
                {
                    int[] pixels = pngImage.LoadArgb32Pixels(pngImage.Bounds);
                    // Iterate through the pixel array and Check the pixel information 
                    //that if it is a transparent color pixel and Change the pixel color to white
                    int transparent = pngImage.TransparentColor.ToArgb();
                    int replacementColor = Color.Yellow.ToArgb();
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        if (pixels[i] == transparent)
                        {
                            pixels[i] = replacementColor;
                        }
                    }
                    // Replace the pixel array into the image.
                    pngImage.SaveArgb32Pixels(pngImage.Bounds, pixels);
                    pngImage.Save(dataDir+"ChangeBackground_out.png");
                }
            }

            //ExEnd:ChangeBackgroundColor
        }
    }
}
