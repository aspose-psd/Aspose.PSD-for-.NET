using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class AddTextLayerOnRuntime
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:AddTextLayerOnRuntime

            string sourceFileName = dataDir + "OneLayer.psd";
            string psdPath = dataDir + "ImageWithTextLayer.psd";

            using (var img = Image.Load(sourceFileName))
            {
                PsdImage im = (PsdImage)img;
                var rect = new Rectangle(
                    (int)(im.Width * 0.25),
                    (int)(im.Height * 0.25),
                    (int)(im.Width * 0.5),
                    (int)(im.Height * 0.5));

                var layer = im.AddTextLayer("Added text", rect);

                im.Save(psdPath);
            }
            //ExEnd:AddTextLayerOnRuntime

        }

    }
}
