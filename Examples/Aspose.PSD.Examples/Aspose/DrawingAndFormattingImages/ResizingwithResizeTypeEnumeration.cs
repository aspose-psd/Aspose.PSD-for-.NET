using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ResizingwithResizeTypeEnumeration
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ResizingwithResizeTypeEnumeration

            String sourceFile = dataDir + @"sample.psd";
            string destName = dataDir + @"ResizingwithResizeTypeEnumeration_out.jpg";

            // Load an existing image into an instance of RasterImage class
            using (Image image = Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.LanczosResample);
                image.Save(destName, new JpegOptions());
            }

            //ExEnd:ResizingwithResizeTypeEnumeration

        }

    }
}
