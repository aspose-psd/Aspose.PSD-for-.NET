using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Tiff;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.TIFF
{
    class ExportToMultiPageTiff
    {
        public static void Run()
        {

            //ExStart:ExportToMultiPageTiff
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            // Load a PSD file as an image and cast it into PsdImage
            using (PsdImage psdImage = (PsdImage)Image.Load(dataDir + "layers.psd"))
            {

                // Initialize tiff frame list.
                //List<TiffFrame> frames = new List<TiffFrame>();

                // Iterate over each layer of PsdImage and convert it to Tiff frame.
                //foreach (var layer in psdImage.Layers)
                //{
                //    TiffFrame frame = new TiffFrame(layer, new TiffOptions(FileFormats.Tiff.Enums.TiffExpectedFormat.TiffLzwCmyk));
                //    frames.Add(frame);
                //}

                // Create a new TiffImage with frames created earlier and save to disk.
                //TiffImage tiffImage = new TiffImage(frames.ToArray());
                //tiffImage.Save(dataDir+ "ExportToMultiPageTiff_output.tif");
            }
            //ExEnd:ExportToMultiPageTiff
        }
    }
}
