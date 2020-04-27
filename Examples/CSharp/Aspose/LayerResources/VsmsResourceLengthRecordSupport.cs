using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.VectorPaths;
using System;

namespace Aspose.PSD.Examples.Aspose.LayerResources
{
    class VsmsResourceLengthRecordSupport
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            //ExStart:VsmsResourceLengthRecordSupport
            //ExSummary:The following code example demonstrates the support of new LengthRecord properties, PathOperations (boolean operations), ShapeIndex and BezierKnotRecordsCount.
            string fileName = SourceDir + "PathOperationsShape.psd";
            string outFileName = OutputDir + "out_PathOperationsShape.psd";
            using (var im = (PsdImage)Image.Load(fileName))
            {
                VsmsResource resource = null;
                foreach (var layerResource in im.Layers[1].Resources)
                {
                    if (layerResource is VsmsResource)
                    {
                        resource = (VsmsResource)layerResource;
                        break;
                    }
                }

                LengthRecord lengthRecord0 = (LengthRecord)resource.Paths[2];
                LengthRecord lengthRecord1 = (LengthRecord)resource.Paths[7];
                LengthRecord lengthRecord2 = (LengthRecord)resource.Paths[11];

                // Here we changin the way to combining betwen shapes.
                lengthRecord0.PathOperations = PathOperations.ExcludeOverlappingShapes;
                lengthRecord1.PathOperations = PathOperations.IntersectShapeAreas;
                lengthRecord2.PathOperations = PathOperations.SubtractFrontShape;

                im.Save(outFileName);
            }
            //ExEnd:SupportForClblResource

            Console.WriteLine("VsmsResourceLengthRecordSupport executed successfully");
        }
    }
}