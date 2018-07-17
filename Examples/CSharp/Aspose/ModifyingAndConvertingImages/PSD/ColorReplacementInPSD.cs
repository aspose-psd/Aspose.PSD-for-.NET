using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ColorReplacementInPSD
    {
        public static void Run()
        {
            //ExStart:ColorReplacementInPSD
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and caste it into PsdImage
            using (PsdImage image = (PsdImage)Image.Load(dataDir + "sample.psd"))
            {
                foreach (var layer in image.Layers)
                {
                    if (layer.Name == "Rectangle 1")
                    {
                        int dd = 0;
                        layer.HasBackgroundColor = true;
                        layer.BackgroundColor = Color.Orange;
                    }

                }

                image.Save(dataDir + "asposeImage02.psd");
            }
            
            //ExEnd:ColorReplacementInPSD

        }
    }
}
