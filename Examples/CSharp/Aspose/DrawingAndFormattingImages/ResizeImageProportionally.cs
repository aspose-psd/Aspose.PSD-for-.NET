using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ResizeImageProportionally
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ResizeImageProportionally

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"SimpleResizeImageProportionally_out.png";

            // Load an existing image into an instance of RasterImage class
            using (Image image = Image.Load(sourceFile))
            {
                if (!image.IsCached)
                {
                    image.CacheData();
                }
                // Specifying width and height
                int newWidth = image.Width / 2;
                image.ResizeWidthProportionally(newWidth);
                int newHeight = image.Height / 2;
                image.ResizeHeightProportionally(newHeight);
                image.Save(destName, new PngOptions());
            }


            //ExEnd:ResizeImageProportionally

        }

    }
}
