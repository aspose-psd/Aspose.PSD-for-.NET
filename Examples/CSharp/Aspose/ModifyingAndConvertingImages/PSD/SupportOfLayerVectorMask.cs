using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.VectorPaths;
using Aspose.PSD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfLayerVectorMask
    {
        public static void Run() {

            //ExStart:SupportOfLayerVectorMask
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir + "DifferentLayerMasks_Source.psd";
            string exportPath = dataDir + "DifferentLayerMasks_Export.psd";
            string exportPathPng = dataDir + "DifferentLayerMasks_Export.png";
            // reading
            using (PsdImage image = (PsdImage)Image.Load(sourceFileName))
            {
                // make changes to the vector path points
                foreach (var layer in image.Layers)
                {
                    foreach (var layerResource in layer.Resources)
                    {
                        var resource = layerResource as VectorPathDataResource;
                        if (resource != null)
                        {
                            foreach (var pathRecord in resource.Paths)
                            {
                                var bezierKnotRecord = pathRecord as BezierKnotRecord;
                                if (bezierKnotRecord != null)
                                {
                                    Point p0 = bezierKnotRecord.Points[0];
                                    bezierKnotRecord.Points[0] = bezierKnotRecord.Points[2];
                                    bezierKnotRecord.Points[2] = p0;
                                    break;
                                }
                            }
                        }
                    }
                }
                // exporting
                image.Save(exportPath);
                image.Save(exportPathPng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }


            //ExEnd:SupportOfLayerVectorMask

        }
    }
}
