using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfPtFlResource
    {
        public static void Run()
        {

            //ExStart:SupportOfPtFlResource
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();
            // Support of PtFlResource
            string sourceFileName = dataDir + "PatternFillLayer.psd";
            string exportPath = dataDir +"PtFlResource_Edited.psd";
            double tolerance = 0.0001;
            var im = (PsdImage)Image.Load(sourceFileName);
            using (im)
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is FillLayer)
                    {
                        var fillLayer = (FillLayer)layer;
                        var resources = fillLayer.Resources;
                        foreach (var res in resources)
                        {
                            if (res is PtFlResource)
                            {
                                // Reading
                                PtFlResource resource = (PtFlResource)res;
                                if (
                                    resource.Offset.X != -46 ||
                                    resource.Offset.Y != -45 ||
                                    resource.PatternId != "a6818df2-7532-494e-9615-8fdd6b7f38e5\0" ||
                                    resource.PatternName != "$$$/Presets/Patterns/OpticalSquares=Optical Squares\0" ||
                                    resource.AlignWithLayer != true ||
                                    resource.IsLinkedWithLayer != true ||
                                    !(Math.Abs(resource.Scale - 50) < tolerance))
                                {
                                    throw new Exception("PtFl Resource was read incorrect");
                                }
                                // Editing
                                resource.Offset = new Point(-11, 13);
                                resource.Scale = 200;
                                resource.AlignWithLayer = false;
                                resource.IsLinkedWithLayer = false;
                                fillLayer.Resources = fillLayer.Resources;
                                // We haven't pattern data in PattResource, so we can add it.
                                var fillSettings = (PatternFillSettings)fillLayer.FillSettings;
                                fillSettings.PatternData = new int[]
                                {
                           Color.Black.ToArgb(),
                           Color.White.ToArgb(),
                           Color.White.ToArgb(),
                           Color.White.ToArgb(),
                                };
                                fillSettings.PatternHeight = 1;
                                fillSettings.PatternWidth = 4;
                                fillSettings.PatternName = "$$$/Presets/Patterns/VerticalLine=Vertical Line New\0";
                                fillSettings.PatternId = Guid.NewGuid().ToString() + "\0";
                                fillLayer.Update();
                            }
                            break;
                        }
                        break;
                    }
                }
                im.Save(exportPath);
            }

            //ExEnd:SupportOfPtFlResource


        }

    }
}
