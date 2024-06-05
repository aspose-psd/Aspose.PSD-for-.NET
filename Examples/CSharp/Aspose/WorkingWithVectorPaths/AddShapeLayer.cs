using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Core.VectorPaths;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerEffects;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.StrokeResources;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    public class AddShapeLayer
    {
        public static void Run()
        {
            // The path to the document's directory.
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:AddShapeLayer
            //ExSummary:The following code demonstrates how to add ShapeLayer.

            string outputFile = Path.Combine(outputDir, "AddShapeLayer_output.psd");

            const int ImgToPsdRatio = 256 * 65535;

            using (PsdImage newPsd = new PsdImage(600, 400))
            {
                ShapeLayer layer = newPsd.AddShapeLayer();

                var newShape = GenerateNewShape(newPsd.Size);
                List<IPathShape> newShapes = new List<IPathShape>();
                newShapes.Add(newShape);
                layer.Path.SetItems(newShapes.ToArray());

                layer.Update();

                newPsd.Save(outputFile);
            }

            using (PsdImage image = (PsdImage)Image.Load(outputFile))
            {
                AssertAreEqual(2, image.Layers.Length);

                ShapeLayer shapeLayer = image.Layers[1] as ShapeLayer;
                ColorFillSettings internalFill = shapeLayer.Fill as ColorFillSettings;
                IStrokeSettings strokeSettings = shapeLayer.Stroke;
                ColorFillSettings strokeFill = shapeLayer.Stroke.Fill as ColorFillSettings;

                AssertAreEqual(1, shapeLayer.Path.GetItems().Length); // 1 Shape
                AssertAreEqual(3, shapeLayer.Path.GetItems()[0].GetItems().Length); // 3 knots in a shape

                AssertAreEqual(-16127182, internalFill.Color.ToArgb()); // ff09eb32

                AssertAreEqual(7.41, strokeSettings.Size);
                AssertAreEqual(false, strokeSettings.Enabled);
                AssertAreEqual(StrokePosition.Center, strokeSettings.LineAlignment);
                AssertAreEqual(LineCapType.ButtCap, strokeSettings.LineCap);
                AssertAreEqual(LineJoinType.MiterJoin, strokeSettings.LineJoin);
                AssertAreEqual(-16777216, strokeFill.Color.ToArgb()); // ff000000
            }

            PathShape GenerateNewShape(Size imageSize)
            {
                var newShape = new PathShape();

                PointF point1 = new PointF(20, 100);
                PointF point2 = new PointF(200, 100);
                PointF point3 = new PointF(300, 10);

                BezierKnotRecord[] bezierKnots = new BezierKnotRecord[]
                {
                     new BezierKnotRecord()
                     {
                         IsLinked = true,
                         Points = new Point[3]
                                  {
                                      PointFToResourcePoint(point1, imageSize),
                                      PointFToResourcePoint(point1, imageSize),
                                      PointFToResourcePoint(point1, imageSize),
                                  }
                     },
                     new BezierKnotRecord()
                     {
                         IsLinked = true,
                         Points = new Point[3]
                                  {
                                      PointFToResourcePoint(point2, imageSize),
                                      PointFToResourcePoint(point2, imageSize),
                                      PointFToResourcePoint(point2, imageSize),
                                  }
                     },
                     new BezierKnotRecord()
                     {
                         IsLinked = true,
                         Points = new Point[3]
                                  {
                                      PointFToResourcePoint(point3, imageSize),
                                      PointFToResourcePoint(point3, imageSize),
                                      PointFToResourcePoint(point3, imageSize),
                                  }
                     },
                };

                newShape.SetItems(bezierKnots);

                return newShape;
            }

            Point PointFToResourcePoint(PointF point, Size imageSize)
            {
                return new Point(
                    (int)Math.Round(point.Y * (ImgToPsdRatio / imageSize.Height)),
                    (int)Math.Round(point.X * (ImgToPsdRatio / imageSize.Width)));
            }

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }
            
            //ExEnd:AddShapeLayer

            File.Delete(outputFile);

            Console.WriteLine("AddShapeLayer executed successfully");
        }
    }
}