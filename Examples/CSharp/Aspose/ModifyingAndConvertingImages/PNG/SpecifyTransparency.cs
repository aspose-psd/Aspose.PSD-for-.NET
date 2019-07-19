﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG
{
    class SpecifyTransparency
    {
        public static void Run()
        {
            //ExStart:SpecifyTransparency
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {

                // specify the PNG image transparency options and save to file.
                psdImage.TransparentColor = Color.White;
                psdImage.HasTransparentColor = true;
                PngOptions opt = new PngOptions();
                psdImage.Save(dataDir+"Specify_Transparency_result.png", new PngOptions());
                
            }

            //ExEnd:SpecifyTransparency
        }
    }
}
