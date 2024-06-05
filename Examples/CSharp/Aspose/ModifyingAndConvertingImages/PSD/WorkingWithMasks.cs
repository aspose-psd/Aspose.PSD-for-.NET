using System;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    public class WorkingWithMasks
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:WorkingWithMasks
            string source = Path.Combine(baseDir, "example.psd");
            string outputUpdated = Path.Combine(outputDir, "updated_mask_features.psd");

            using (PsdImage image = (PsdImage)Image.Load(source))
            {
                // The most simple is the using of Clipping masks
                // Some Layer and Adjustment Layer Become Clipping Masks
                image.Layers[4].Clipping = 1;
                image.Layers[5].Clipping = 1;

                // Example how to add Mask to Layer
                LayerMaskDataShort mask = new LayerMaskDataShort
                {
                    Left = 50,
                    Top = 213,
                    Right = 50 + 150,
                    Bottom = 213 + 150
                };
                byte[] maskData = new byte[(mask.Right - mask.Left) * (mask.Bottom - mask.Top)];
                for (int index = 0; index < maskData.Length; index++)
                {
                    maskData[index] = (byte)(100 + index % 100);
                }

                mask.ImageData = maskData;
                image.Layers[2].AddLayerMask(mask);

                image.Save(outputUpdated);
            }
            //ExEnd:WorkingWithMasks
            
            File.Delete(outputUpdated);

            Console.WriteLine("WorkingWithMasks executed successfully");
        }
    }
}