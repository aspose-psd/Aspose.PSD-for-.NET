using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class CombiningImages
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_DrawingAndFormattingImages();

            //ExStart:CombiningImages

            // Create an instance of PsdOptions and set its various properties
            PsdOptions imageOptions = new PsdOptions();

            // Create an instance of FileCreateSource and assign it to Source property
            imageOptions.Source = new FileCreateSource(dataDir+"Two_images_result_out.psd", false);

            // Create an instance of Image and define canvas size
            using (var image = Image.Create(imageOptions, 600, 600))
            {
                // Create and initialize an instance of Graphics, Clear the image surface with white color and Draw Image
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawImage(Image.Load(dataDir+"example1.psd"), 0, 0, 300, 600);
                graphics.DrawImage(Image.Load(dataDir+"example2.psd"), 300, 0, 300, 600);
                image.Save();
            }


            //ExEnd:CombiningImages

        }
    }
}
