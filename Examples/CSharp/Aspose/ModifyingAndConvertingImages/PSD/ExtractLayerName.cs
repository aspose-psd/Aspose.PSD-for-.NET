using Aspose.PSD.FileFormats.Psd;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ExtractLayerName
    {

        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ExtractLayerName

            // make changes in layer names and save it
            using (var image = (PsdImage)Image.Load(dataDir + "Korean_layers.psd"))
            {
                for (int i = 0; i < image.Layers.Length; i++)
                {
                    var layer = image.Layers[i];
                    // set new value into DisplayName property
                    layer.DisplayName += "_changed";
                }

                image.Save(dataDir + "Korean_layers_output.psd");
            }

            //ExEnd:ExtractLayerName
        }
    }
}
