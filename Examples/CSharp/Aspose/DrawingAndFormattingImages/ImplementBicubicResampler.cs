using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ImplementBicubicResampler
    {
        public static void Run()
        {
            // Add color overlay layer effect at runtime
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ImplementBicubicResampler
            string sourceFile = dataDir + "sample_bicubic.psd";
            string destNameCubicConvolution = dataDir + "ResamplerCubicConvolutionStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.CubicConvolution);
                image.Save(destNameCubicConvolution, new PsdOptions(image));
            }


            string destNameCatmullRom = dataDir + "ResamplerCatmullRomStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.CatmullRom);
                image.Save(destNameCatmullRom, new PsdOptions(image));
            }


            string destNameMitchell = "ResamplerMitchellStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.Mitchell);
                image.Save(destNameMitchell, new PsdOptions(image));
            }


            string destNameCubicBSpline = "ResamplerCubicBSplineStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.CubicBSpline);
                image.Save(destNameCubicBSpline, new PsdOptions(image));
            }


            string destNameSinC = "ResamplerSinCStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.SinC);
                image.Save(destNameSinC, new PsdOptions(image));
            }


            string destNameBell = "ResamplerBellStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.Bell);
                image.Save(destNameBell, new PsdOptions(image));
            }


            //ExEnd:ImplementBicubicResampler


        }
    }
}
