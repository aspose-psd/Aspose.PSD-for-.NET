using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Jpeg;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class ColorConversionUsingICCProfiles
    {
        public static void Run()
        {

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ModifyingAndConvertingImages();

            //ExStart:ColorConversionUsingICCProfiles

            // Create a new JpegImage.
            using (JpegImage image = new JpegImage(500, 500))
            {
                // Fill image data.
                int count = image.Width * image.Height;
                int[] pixels = new int[count];
                int r = 0;
                int g = 0;
                int b = 0;
                int channel = 0;
                for (int i = 0; i < count; i++)
                {
                    if (channel % 3 == 0)
                    {
                        r++;
                        if (r == 256)
                        {
                            r = 0;
                            channel++;
                        }
                    }
                    else if (channel % 3 == 1)
                    {
                        g++;
                        if (g == 256)
                        {
                            g = 0;
                            channel++;
                        }
                    }
                    else
                    {
                        b++;
                        if (b == 256)
                        {
                            b = 0;
                            channel++;
                        }
                    }

                    pixels[i] = Color.FromArgb(r, g, b).ToArgb();
                }

                // Save the newly created pixels.
                image.SaveArgb32Pixels(image.Bounds, pixels);

                // Save the resultant image with default Icc profiles.
                image.Save(dataDir+"Default_profiles.jpg");

                // Update color profile.
                StreamSource rgbprofile = new StreamSource(File.OpenRead("eciRGB_v2.icc"));
                StreamSource cmykprofile = new StreamSource(File.OpenRead("ISOcoated_v2_FullGamut4.icc"));
                image.RgbColorProfile = rgbprofile;
                image.CmykColorProfile = cmykprofile;

                // Save the resultant image with new YCCK profiles. You will notice differences in color values if compare the images.
                JpegOptions options = new JpegOptions();
                options.ColorType = JpegCompressionColorMode.Ycck;
                image.Save(dataDir + "Ycck_profiles.jpg", options);
            }


            //ExEnd:ColorConversionUsingICCProfiles
        }
    }
}
