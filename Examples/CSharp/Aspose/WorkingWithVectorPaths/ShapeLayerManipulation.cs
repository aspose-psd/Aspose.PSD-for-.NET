using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Core.VectorPaths;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    public class ShapeLayerManipulation
    {
        public static void Run()
        {
            // The path to the document's directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:ShapeLayerManipulation
            //ExSummary:The following code demonstrates how to add ShapeLayer.

            string sourceFileName = Path.Combine(baseDir, "ShapeLayerTest.psd");
            string updatedOutput = Path.Combine(outputDir, "ShapeLayerTest_Res_up.psd");

            using (PsdImage im = (PsdImage)Image.Load(sourceFileName))
            {
                foreach (var layer in im.Layers)
                {
                    // Finding Shape Layer
                    if (layer is ShapeLayer shapeLayer)
                    {
                        var path = shapeLayer.Path;
                        IPathShape[] pathShapes = path.GetItems();
                        List<BezierKnotRecord> knotsList = new List<BezierKnotRecord>();
                        foreach (var pathShape in pathShapes)
                        {
                            var knots = pathShape.GetItems();
                            knotsList.AddRange(knots);
                        }

                        // Change Path Shape properties
                        PathShape newShape = new PathShape();

                        BezierKnotRecord bn1 = new BezierKnotRecord
                        {
                            IsLinked = true,
                            Points = new Point[]
                            {
                                PointFToResourcePoint(new PointF(20, 100), shapeLayer.Container.Size),
                                PointFToResourcePoint(new PointF(20, 100), shapeLayer.Container.Size),
                                PointFToResourcePoint(new PointF(20, 100), shapeLayer.Container.Size)
                            }
                        };

                        BezierKnotRecord bn2 = new BezierKnotRecord
                        {
                            IsLinked = true,
                            Points = new Point[]
                            {
                                PointFToResourcePoint(new PointF(20, 490), shapeLayer.Container.Size),
                                PointFToResourcePoint(new PointF(20, 490), shapeLayer.Container.Size),
                                PointFToResourcePoint(new PointF(20, 490), shapeLayer.Container.Size)
                            }
                        };

                        BezierKnotRecord bn3 = new BezierKnotRecord
                        {
                            IsLinked = true,
                            Points = new Point[]
                            {
                                PointFToResourcePoint(new PointF(490, 20), shapeLayer.Container.Size),
                                PointFToResourcePoint(new PointF(490, 20), shapeLayer.Container.Size),
                                PointFToResourcePoint(new PointF(490, 20), shapeLayer.Container.Size)
                            }
                        };

                        List<BezierKnotRecord> bezierKnots = new List<BezierKnotRecord> { bn1, bn2, bn3 };
                        newShape.SetItems(bezierKnots.ToArray());

                        List<IPathShape> newShapes = new List<IPathShape>(pathShapes)
                        {
                            newShape
                        };

                        path.SetItems(newShapes.ToArray());

                        shapeLayer.Update();

                        im.Save(updatedOutput);

                        break;
                    }
                }
            }

            Point PointFToResourcePoint(PointF point, Size imageSize)
            {
                const int ImgToPsdRatio = 256 * 65535;
                return new Point((int)(point.Y * (ImgToPsdRatio / imageSize.Height)),
                    (int)(point.X * (ImgToPsdRatio / imageSize.Width)));
            }

            //ExEnd:ShapeLayerManipulation

            File.Delete(updatedOutput);

            Console.WriteLine("ShapeLayerManipulation executed successfully");
        }
    }
}