using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Core.VectorPaths;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    public class SupportIPathToManipulateVectorPathObjects
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportIPathToManipulateVectorPathObjects
            //ExSummary:The following code demonstrates path objects from vsms or vmsk resources for ShapeLayer.

            string srcFile = Path.Combine(baseDir, "ShapeLayerTest.psd");
            string outFile = Path.Combine(outputDir, "ShapeLayerTest-out.psd");

            using (PsdImage image = (PsdImage)Image.Load(srcFile, new PsdLoadOptions { LoadEffectsResource = true }))
            {
                Layer shapeLayer = image.Layers[1];
                VectorPathDataResource vectorPathDataResource = (VectorPathDataResource)shapeLayer.Resources[1];

                bool isFillStartsWithAllPixels;
                List<IPathShape> shapes = GetShapesFromResource(vectorPathDataResource, out isFillStartsWithAllPixels);

                // Remove one shape
                shapes.RemoveAt(1);

                // Save changed data to resource
                List<VectorPathRecord> path = new List<VectorPathRecord>();
                path.Add(new PathFillRuleRecord(null));
                path.Add(new InitialFillRuleRecord(isFillStartsWithAllPixels));

                for (ushort i = 0; i < shapes.Count; i++)
                {
                    PathShape shape = (PathShape)shapes[i];
                    shape.ShapeIndex = i;
                    path.AddRange(shape.ToVectorPathRecords());
                }

                vectorPathDataResource.Paths = path.ToArray();

                image.Save(outFile);
            }

            // Check changed values in saved file
            using (PsdImage image = (PsdImage)Image.Load(outFile, new PsdLoadOptions { LoadEffectsResource = true }))
            {
                Layer shapeLayer = image.Layers[1];
                VectorPathDataResource vectorPathDataResource = (VectorPathDataResource)shapeLayer.Resources[1];

                bool isFillStartsWithAllPixels;
                List<IPathShape> shapes = GetShapesFromResource(vectorPathDataResource, out isFillStartsWithAllPixels);

                // Saved file should have 1 shape
                AssertAreEqual(1, shapes.Count);
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            List<IPathShape> GetShapesFromResource(
                VectorPathDataResource vectorPathDataResource,
                out bool isFillStartsWithAllPixels)
            {
                List<IPathShape> shapes = new List<IPathShape>();
                LengthRecord lengthRecord = null;
                isFillStartsWithAllPixels = false;
                List<BezierKnotRecord> bezierKnotRecords = new List<BezierKnotRecord>();

                foreach (var pathRecord in vectorPathDataResource.Paths)
                {
                    if (pathRecord is LengthRecord)
                    {
                        if (bezierKnotRecords.Count > 0)
                        {
                            shapes.Add(new PathShape(lengthRecord, bezierKnotRecords.ToArray()));
                            lengthRecord = null;
                            bezierKnotRecords.Clear();
                        }

                        lengthRecord = (LengthRecord)pathRecord;
                    }
                    else if (pathRecord is BezierKnotRecord)
                    {
                        bezierKnotRecords.Add((BezierKnotRecord)pathRecord);
                    }
                    else if (pathRecord is InitialFillRuleRecord)
                    {
                        InitialFillRuleRecord initialFillRuleRecord = (InitialFillRuleRecord)pathRecord;
                        isFillStartsWithAllPixels = initialFillRuleRecord.IsFillStartsWithAllPixels;
                    }
                }

                if (bezierKnotRecords.Count > 0)
                {
                    shapes.Add(new PathShape(lengthRecord, bezierKnotRecords.ToArray()));
                    lengthRecord = null;
                    bezierKnotRecords.Clear();
                }

                return shapes;
            }
            
            //ExEnd:SupportIPathToManipulateVectorPathObjects

            File.Delete(outFile);

            Console.WriteLine("SupportIPathToManipulateVectorPathObjects executed successfully");
        }
    }
}