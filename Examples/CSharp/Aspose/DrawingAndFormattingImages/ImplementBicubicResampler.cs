using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class ImplementBicubicResampler
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:ImplementBicubicResampler
            string sourceFile = baseDir + "sample_bicubic.psd";
            string destNameCubicConvolution = outputDir + "ResamplerCubicConvolutionStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.CubicConvolution);
                image.Save(destNameCubicConvolution, new PsdOptions(image));
            }


            string destNameCatmullRom = outputDir + "ResamplerCatmullRomStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.CatmullRom);
                image.Save(destNameCatmullRom, new PsdOptions(image));
            }


            string destNameMitchell = outputDir + "ResamplerMitchellStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.Mitchell);
                image.Save(destNameMitchell, new PsdOptions(image));
            }


            string destNameCubicBSpline = outputDir + "ResamplerCubicBSplineStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.CubicBSpline);
                image.Save(destNameCubicBSpline, new PsdOptions(image));
            }


            string destNameSinC = outputDir + "ResamplerSinCStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.SinC);
                image.Save(destNameSinC, new PsdOptions(image));
            }


            string destNameBell = outputDir + "ResamplerBellStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.Bell);
                image.Save(destNameBell, new PsdOptions(image));
            }


            string destNameLanczos = outputDir + "ResamplerLanczosStripes_after.psd";

            // Load an existing image into an instance of PsdImage class
            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                image.Resize(300, 300, ResizeType.LanczosResample);
                image.Save(destNameLanczos, new PsdOptions(image));
            }


            //ExEnd:ImplementBicubicResampler
        }
    }
}
