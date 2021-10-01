using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Core.VectorPaths;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.FillSettings;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    class ClassesToManipulateVectorPathObjects
    {
        public static void Run()
        {
            // The path to the documents directory.
            string SourceDir = RunExamples.GetDataDir_PSD();
            string OutputDir = RunExamples.GetDataDir_Output();

            string fileName = Path.Combine(SourceDir, "PathExample2.psd");
            string outputPsd = Path.Combine(OutputDir, "out_CreatingVectorPathExampleTest.psd");
            string outputPng = Path.Combine(OutputDir, "out_CreatingVectorPathExampleTest.png");

            CreatingVectorPathExample(fileName, outputPsd, outputPng);

            Console.WriteLine("ClassesToManipulateVectorPathObjects executed successfully");

            File.Delete(outputPsd);
            File.Delete(outputPng);
        }

        //ExStart:ClassesToManipulateVectorPathObjects
        //ExSummary:The following code example provides classes to manipulate the vector path objects and demonstrates how to use those classes.

        private static void CreatingVectorPathExample(string fileName = "PathExample2.psd", string outputPsd = "out_CreatingVectorPathExampleTest.psd", string outputPng = "out_CreatingVectorPathExampleTest.png")
        {
            using (var psdImage = (PsdImage)Image.Load(fileName))
            {
                VectorDataProvider.RemoveVectorPathDataFromLayer(psdImage.Layers[2]);

                // creating VectorPath object for existing layer without vector path data.
                VectorPath vectorPath = VectorDataProvider.CreateVectorPathForLayer(psdImage.Layers[1]);

                // Set the fill color of vector path
                vectorPath.FillColor = Color.MediumPurple;

                // add new shape
                PathShape newShape = new PathShape();
                newShape.Points.Add(new BezierKnot(new PointF(65, 175), true));
                newShape.Points.Add(new BezierKnot(new PointF(65, 210), true));
                newShape.Points.Add(new BezierKnot(new PointF(190, 210), true));
                newShape.Points.Add(new BezierKnot(new PointF(190, 175), true));
                vectorPath.Shapes.Add(newShape);

                // update path data in layer
                VectorDataProvider.UpdateLayerFromVectorPath(psdImage.Layers[1], vectorPath, true);


                // creating VectorPath object for new layer.
                FillLayer layer2 = FillLayer.CreateInstance(FillType.Color);
                layer2.DisplayName = "Layer 2";
                psdImage.AddLayer(layer2);
                VectorPath vectorPath2 = VectorDataProvider.CreateVectorPathForLayer(layer2);

                // Set the fill color of vector path
                vectorPath2.FillColor = Color.IndianRed;

                // add new shape
                PathShape newShape2 = new PathShape();
                newShape2.Points.Add(new BezierKnot(new PointF(50, 150), true));
                newShape2.Points.Add(new BezierKnot(new PointF(100, 200), true));
                newShape2.Points.Add(new BezierKnot(new PointF(0, 200), true));
                vectorPath2.Shapes.Add(newShape2);

                // update path data in layer
                VectorDataProvider.UpdateLayerFromVectorPath(layer2, vectorPath2, true);

                psdImage.Save(outputPsd);
                psdImage.Save(outputPng, new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }

        #region Vector path editor (Here placed classes for edit vector paths).

        /// <summary>
        /// The class that provides work between <see cref="Layer"/> and <see cref="VectorPath"/>.
        /// </summary>
        public static class VectorDataProvider
        {
            /// <summary>
            /// Creates the <see cref="VectorPath"/> instance based on resources from input layer.
            /// </summary>
            /// <param name="psdLayer">The psd layer.</param>
            /// <returns>the <see cref="VectorPath"/> instance based on resources from input layer.</returns>
            public static VectorPath CreateVectorPathForLayer(Layer psdLayer)
            {
                VectorPathDataResource pathResource = FindVectorPathDataResource(psdLayer, true);
                SoCoResource socoResource = FindSoCoResource(psdLayer, true);
                VectorPath vectorPath = new VectorPath(pathResource);
                if (socoResource != null)
                {
                    vectorPath.FillColor = socoResource.Color;
                }

                return vectorPath;
            }

            /// <summary>
            /// Updates the input layer resources from <see cref="VectorPath"/> instance, or replace by new path resource and updates.
            /// </summary>
            /// <param name="psdLayer">The psd layer.</param>
            /// <param name="vectorPath">The vector path.</param>
            /// <param name="createIfNotExist">If resources not exists, then for <see cref="true"/> creates a new resource, otherwise return <see cref="null"/>.</param>
            public static void UpdateLayerFromVectorPath(Layer psdLayer, VectorPath vectorPath, bool createIfNotExist = false)
            {
                VectorPathDataResource pathResource = FindVectorPathDataResource(psdLayer, createIfNotExist);
                VogkResource vogkResource = FindVogkResource(psdLayer, createIfNotExist);
                SoCoResource socoResource = FindSoCoResource(psdLayer, createIfNotExist);

                UpdateResources(pathResource, vogkResource, socoResource, vectorPath);

                ReplaceVectorPathDataResourceInLayer(psdLayer, pathResource, vogkResource, socoResource);
            }

            /// <summary>
            /// Removes the vector path data from input layer.
            /// </summary>
            /// <param name="psdLayer">The psd layer.</param>
            public static void RemoveVectorPathDataFromLayer(Layer psdLayer)
            {
                List<LayerResource> oldResources = new List<LayerResource>(psdLayer.Resources);
                List<LayerResource> newResources = new List<LayerResource>();
                for (int i = 0; i < oldResources.Count; i++)
                {
                    LayerResource resource = oldResources[i];

                    if (resource is VectorPathDataResource || resource is VogkResource || resource is SoCoResource)
                    {
                        continue;
                    }
                    else
                    {
                        newResources.Add(resource);
                    }
                }

                psdLayer.Resources = newResources.ToArray();
            }

            /// <summary>
            /// Updates resources data from <see cref="VectorPath"/> instance.
            /// </summary>
            /// <param name="pathResource">The path resource.</param>
            /// <param name="vogkResource">The vector origination data resource.</param>
            /// <param name="socoResource">The solid color resource.</param>
            /// <param name="vectorPath">The vector path.</param>
            private static void UpdateResources(VectorPathDataResource pathResource, VogkResource vogkResource, SoCoResource socoResource, VectorPath vectorPath)
            {
                pathResource.Version = vectorPath.Version;
                pathResource.IsNotLinked = vectorPath.IsNotLinked;
                pathResource.IsDisabled = vectorPath.IsDisabled;
                pathResource.IsInverted = vectorPath.IsInverted;

                List<VectorShapeOriginSettings> originSettings = new List<VectorShapeOriginSettings>();
                List<VectorPathRecord> path = new List<VectorPathRecord>();
                path.Add(new PathFillRuleRecord(null));
                path.Add(new InitialFillRuleRecord(vectorPath.IsFillStartsWithAllPixels));
                for (ushort i = 0; i < vectorPath.Shapes.Count; i++)
                {
                    PathShape shape = vectorPath.Shapes[i];
                    shape.ShapeIndex = i;
                    path.AddRange(shape.ToVectorPathRecords());
                    originSettings.Add(new VectorShapeOriginSettings() { IsShapeInvalidated = true, OriginIndex = i });
                }

                pathResource.Paths = path.ToArray();
                vogkResource.ShapeOriginSettings = originSettings.ToArray();

                socoResource.Color = vectorPath.FillColor;
            }

            /// <summary>
            /// Replaces resources in layer by updated or new ones.
            /// </summary>
            /// <param name="psdLayer">The psd layer.</param>
            /// <param name="pathResource">The path resource.</param>
            /// <param name="vogkResource">The vector origination data resource.</param>
            /// <param name="socoResource">The solid color resource.</param>
            private static void ReplaceVectorPathDataResourceInLayer(Layer psdLayer, VectorPathDataResource pathResource, VogkResource vogkResource, SoCoResource socoResource)
            {
                bool pathResourceExist = false;
                bool vogkResourceExist = false;
                bool socoResourceExist = false;

                List<LayerResource> resources = new List<LayerResource>(psdLayer.Resources);
                for (int i = 0; i < resources.Count; i++)
                {
                    LayerResource resource = resources[i];
                    if (resource is VectorPathDataResource)
                    {
                        resources[i] = pathResource;
                        pathResourceExist = true;
                    }
                    else if (resource is VogkResource)
                    {
                        resources[i] = vogkResource;
                        vogkResourceExist = true;
                    }
                    else if (resource is SoCoResource)
                    {
                        resources[i] = socoResource;
                        socoResourceExist = true;
                    }
                }

                if (!pathResourceExist)
                {
                    resources.Add(pathResource);
                }

                if (!vogkResourceExist)
                {
                    resources.Add(vogkResource);
                }

                if (!socoResourceExist)
                {
                    resources.Add(socoResource);
                }

                psdLayer.Resources = resources.ToArray();
            }

            /// <summary>
            /// Finds the <see cref="VectorPathDataResource"/> resource in input layer resources.
            /// </summary>
            /// <param name="psdLayer">The psd layer.</param>
            /// <param name="createIfNotExist">If resource not exists, then for <see cref="true"/> creates a new resource, otherwise return <see cref="null"/>.</param>
            /// <returns>The <see cref="VectorPathDataResource"/> resource.</returns>
            private static VectorPathDataResource FindVectorPathDataResource(Layer psdLayer, bool createIfNotExist = false)
            {
                VectorPathDataResource pathResource = null;
                foreach (var resource in psdLayer.Resources)
                {
                    if (resource is VectorPathDataResource)
                    {
                        pathResource = (VectorPathDataResource)resource;
                        break;
                    }
                }

                if (createIfNotExist && pathResource == null)
                {
                    pathResource = new VmskResource();
                }

                return pathResource;
            }

            /// <summary>
            /// Finds the <see cref="VogkResource"/> resource in input layer resources.
            /// </summary>
            /// <param name="psdLayer">The psd layer.</param>
            /// <param name="createIfNotExist">If resource not exists, then for <see cref="true"/> creates a new resource, otherwise return <see cref="null"/>.</param>
            /// <returns>The <see cref="VogkResource"/> resource.</returns>
            private static VogkResource FindVogkResource(Layer psdLayer, bool createIfNotExist = false)
            {
                VogkResource vogkResource = null;
                foreach (var resource in psdLayer.Resources)
                {
                    if (resource is VogkResource)
                    {
                        vogkResource = (VogkResource)resource;
                        break;
                    }
                }

                if (createIfNotExist && vogkResource == null)
                {
                    vogkResource = new VogkResource();
                }

                return vogkResource;
            }

            /// <summary>
            /// Finds the <see cref="SoCoResource"/> resource in input layer resources.
            /// </summary>
            /// <param name="psdLayer">The psd layer.</param>
            /// <param name="createIfNotExist">If resource not exists, then for <see cref="true"/> creates a new resource, otherwise return <see cref="null"/>.</param>
            /// <returns>The <see cref="SoCoResource"/> resource.</returns>
            private static SoCoResource FindSoCoResource(Layer psdLayer, bool createIfNotExist = false)
            {
                SoCoResource socoResource = null;
                foreach (var resource in psdLayer.Resources)
                {
                    if (resource is SoCoResource)
                    {
                        socoResource = (SoCoResource)resource;
                        break;
                    }
                }

                if (createIfNotExist && socoResource == null)
                {
                    socoResource = new SoCoResource();
                }

                return socoResource;
            }
        }

        /// <summary>
        /// The Bezier curve knot, it contains one anchor point and two control points.
        /// </summary>
        public class BezierKnot
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BezierKnot" /> class.
            /// </summary>
            /// <param name="anchorPoint">The anchor point.</param>
            /// <param name="controlPoint1">The first control point.</param>
            /// <param name="controlPoint2">THe second control point.</param>
            /// <param name="isLinked">The value indicating whether this knot is linked.</param>
            public BezierKnot(PointF anchorPoint, PointF controlPoint1, PointF controlPoint2, bool isLinked)
            {
                this.AnchorPoint = anchorPoint;
                this.ControlPoint1 = controlPoint1;
                this.ControlPoint2 = controlPoint2;
                this.IsLinked = isLinked;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BezierKnot" /> class based on <see cref="BezierKnotRecord"/>.
            /// </summary>
            /// <param name="bezierKnotRecord">The <see cref="BezierKnotRecord"/>.</param>
            public BezierKnot(BezierKnotRecord bezierKnotRecord)
            {
                this.IsLinked = bezierKnotRecord.IsLinked;
                this.ControlPoint1 = ResourcePointToPointF(bezierKnotRecord.Points[0]);
                this.AnchorPoint = ResourcePointToPointF(bezierKnotRecord.Points[1]);
                this.ControlPoint2 = ResourcePointToPointF(bezierKnotRecord.Points[2]);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BezierKnot" /> class.
            /// </summary>
            /// <param name="anchorPoint">The point to be anchor and control points.</param>
            /// <param name="isLinked">The value indicating whether this knot is linked.</param>
            public BezierKnot(PointF anchorPoint, bool isLinked)
            : this(anchorPoint, anchorPoint, anchorPoint, isLinked)
            {
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is linked.
            /// </summary>
            public bool IsLinked { get; set; }

            /// <summary>
            /// Gets or sets the first control point.
            /// </summary>
            public PointF ControlPoint1 { get; set; }

            /// <summary>
            /// Gets or sets the anchor point.
            /// </summary>
            public PointF AnchorPoint { get; set; }

            /// <summary>
            /// Gets or sets the second control point.
            /// </summary>
            public PointF ControlPoint2 { get; set; }

            /// <summary>
            /// Creates the instance of <see cref="BezierKnotRecord"/> based on this instance.
            /// </summary>
            /// <param name="isClosed">Indicating whether this knot is in closed shape.</param>
            /// <returns>The instance of <see cref="BezierKnotRecord"/> based on this instance.</returns>
            public BezierKnotRecord ToBezierKnotRecord(bool isClosed)
            {
                BezierKnotRecord record = new BezierKnotRecord();
                record.Points = new Point[]
                {
                    PointFToResourcePoint(this.ControlPoint1),
                    PointFToResourcePoint(this.AnchorPoint),
                    PointFToResourcePoint(this.ControlPoint2),
                };
                record.IsLinked = this.IsLinked;
                record.IsClosed = isClosed;

                return record;
            }

            /// <summary>
            /// Shifts this knot points by input values.
            /// </summary>
            /// <param name="xOffset">The x offset.</param>
            /// <param name="yOffset">The y offset.</param>
            public void Shift(float xOffset, float yOffset)
            {
                this.ControlPoint1 = new PointF(this.ControlPoint1.X + xOffset, this.ControlPoint1.Y + yOffset);
                this.AnchorPoint = new PointF(this.AnchorPoint.X + xOffset, this.AnchorPoint.Y + yOffset);
                this.ControlPoint2 = new PointF(this.ControlPoint2.X + xOffset, this.ControlPoint2.Y + yOffset);
            }

            /// <summary>
            /// Converts point values from resource to normal.
            /// </summary>
            /// <param name="point">The point with values from resource.</param>
            /// <returns>The converted to normal point.</returns>
            private static PointF ResourcePointToPointF(Point point)
            {
                return new PointF(point.Y / 65535, point.X / 65535);
            }

            /// <summary>
            /// Converts normal point values to resource point.
            /// </summary>
            /// <param name="point">The point.</param>
            /// <returns>The point with values for resource.</returns>
            private static Point PointFToResourcePoint(PointF point)
            {
                return new Point((int)Math.Round(point.Y * 65535), (int)Math.Round(point.X * 65535));
            }
        }

        /// <summary>
        /// The figure from the knots of the Bezier curve.
        /// </summary>
        public class PathShape
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PathShape" /> class.
            /// </summary>
            public PathShape()
            {
                this.Points = new List<BezierKnot>();
                this.PathOperations = PathOperations.CombineShapes;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="PathShape" /> class based on <see cref="VectorPathRecord"/>'s.
            /// </summary>
            /// <param name="lengthRecord">The length record.</param>
            /// <param name="bezierKnotRecords">The bezier knot records.</param>
            public PathShape(LengthRecord lengthRecord, List<BezierKnotRecord> bezierKnotRecords)
            : this()
            {
                this.IsClosed = lengthRecord.IsClosed;
                this.PathOperations = lengthRecord.PathOperations;
                this.ShapeIndex = lengthRecord.ShapeIndex;
                this.InitFromResources(bezierKnotRecords);
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is closed.
            /// </summary>
            /// <value>
            ///   <c>true</c> if this instance is closed; otherwise, <c>false</c>.
            /// </value>
            public bool IsClosed { get; set; }

            /// <summary>
            /// Gets or sets the path operations (Boolean operations).
            /// </summary>
            public PathOperations PathOperations { get; set; }

            /// <summary>
            /// Gets or sets the index of current path shape in layer.
            /// </summary>
            public ushort ShapeIndex { get; set; }

            /// <summary>
            /// Gets the points of the Bezier curve.
            /// </summary>
            public List<BezierKnot> Points { get; private set; }

            /// <summary>
            /// Creates the <see cref="VectorPathRecord"/> records based on this instance.
            /// </summary>
            /// <returns>Returns one <see cref="LengthRecord"/> and <see cref="BezierKnotRecord"/> for each point in this instance.</returns>
            public IEnumerable<VectorPathRecord> ToVectorPathRecords()
            {
                List<VectorPathRecord> shapeRecords = new List<VectorPathRecord>();

                LengthRecord lengthRecord = new LengthRecord();
                lengthRecord.IsClosed = this.IsClosed;
                lengthRecord.BezierKnotRecordsCount = this.Points.Count;
                lengthRecord.PathOperations = this.PathOperations;
                lengthRecord.ShapeIndex = this.ShapeIndex;
                shapeRecords.Add(lengthRecord);

                foreach (var bezierKnot in this.Points)
                {
                    shapeRecords.Add(bezierKnot.ToBezierKnotRecord(this.IsClosed));
                }

                return shapeRecords;
            }

            /// <summary>
            /// Initializes a values based on input records.
            /// </summary>
            /// <param name="bezierKnotRecords">The bezier knot records.</param>
            private void InitFromResources(IEnumerable<BezierKnotRecord> bezierKnotRecords)
            {
                List<BezierKnot> newPoints = new List<BezierKnot>();

                foreach (var record in bezierKnotRecords)
                {
                    newPoints.Add(new BezierKnot(record));
                }

                this.Points = newPoints;
            }
        }

        /// <summary>
        /// The class that contains vector paths.
        /// </summary>
        public class VectorPath
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="VectorPath" /> class based on <see cref="VectorPathDataResource"/>.
            /// </summary>
            /// <param name="vectorPathDataResource">The vector path data resource.</param>
            public VectorPath(VectorPathDataResource vectorPathDataResource)
            {
                this.InitFromResource(vectorPathDataResource);
            }

            /// <summary>
            /// Gets or sets a value indicating whether is fill starts with all pixels.
            /// </summary>
            /// <value>
            /// The is fill starts with all pixels.
            /// </value>
            public bool IsFillStartsWithAllPixels { get; set; }

            /// <summary>
            /// Gets the vector shapes.
            /// </summary>
            public List<PathShape> Shapes { get; private set; }

            /// <summary>
            /// Gets or sets the vector path fill color.
            /// </summary>
            public Color FillColor { get; set; }

            /// <summary>
            /// Gets or sets the version.
            /// </summary>
            /// <value>
            /// The version.
            /// </value>
            public int Version { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is disabled.
            /// </summary>
            /// <value>
            ///   <c>true</c> if this instance is disabled; otherwise, <c>false</c>.
            /// </value>
            public bool IsDisabled { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is not linked.
            /// </summary>
            /// <value>
            ///   <c>true</c> if this instance is not linked; otherwise, <c>false</c>.
            /// </value>
            public bool IsNotLinked { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is inverted.
            /// </summary>
            /// <value>
            ///   <c>true</c> if this instance is inverted; otherwise, <c>false</c>.
            /// </value>
            public bool IsInverted { get; set; }

            /// <summary>
            /// Initializes a values based on input <see cref="VectorPathDataResource"/> resource.
            /// </summary>
            /// <param name="resource">The vector path data resource.</param>
            private void InitFromResource(VectorPathDataResource resource)
            {
                List<PathShape> newShapes = new List<PathShape>();
                InitialFillRuleRecord initialFillRuleRecord = null;
                LengthRecord lengthRecord = null;
                List<BezierKnotRecord> bezierKnotRecords = new List<BezierKnotRecord>();

                foreach (var pathRecord in resource.Paths)
                {
                    if (pathRecord is LengthRecord)
                    {
                        if (bezierKnotRecords.Count > 0)
                        {
                            newShapes.Add(new PathShape(lengthRecord, bezierKnotRecords));
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
                        initialFillRuleRecord = (InitialFillRuleRecord)pathRecord;
                    }
                }

                if (bezierKnotRecords.Count > 0)
                {
                    newShapes.Add(new PathShape(lengthRecord, bezierKnotRecords));
                    lengthRecord = null;
                    bezierKnotRecords.Clear();
                }

                this.IsFillStartsWithAllPixels = initialFillRuleRecord != null ? initialFillRuleRecord.IsFillStartsWithAllPixels : false;
                this.Shapes = newShapes;

                this.Version = resource.Version;
                this.IsNotLinked = resource.IsNotLinked;
                this.IsDisabled = resource.IsDisabled;
                this.IsInverted = resource.IsInverted;
            }
        }

        #endregion

        //ExEnd:ClassesToManipulateVectorPathObjects
    }
}
