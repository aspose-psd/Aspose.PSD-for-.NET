using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.VectorPaths;
using System;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfVsmsResource
    {
        //ExStart:SupportOfVsmsResource
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            string sourceFileName = dataDir + "EmptyRectangle.psd";
            string exportPath = dataDir + "EmptyRectangle_changed.psd";
            var im = (PsdImage)Image.Load(sourceFileName);
            using (im)
            {
                var resource = GetVsmsResource(im);
                // Reading
                if (resource.IsDisabled != false ||
                    resource.IsInverted != false ||
                    resource.IsNotLinked != false ||
                    resource.Paths.Length != 7 ||
                    resource.Paths[0].Type != VectorPathType.PathFillRuleRecord ||
                    resource.Paths[1].Type != VectorPathType.InitialFillRuleRecord ||
                    resource.Paths[2].Type != VectorPathType.ClosedSubpathLengthRecord ||
                    resource.Paths[3].Type != VectorPathType.ClosedSubpathBezierKnotUnlinked ||
                    resource.Paths[4].Type != VectorPathType.ClosedSubpathBezierKnotUnlinked ||
                    resource.Paths[5].Type != VectorPathType.ClosedSubpathBezierKnotUnlinked ||
                    resource.Paths[6].Type != VectorPathType.ClosedSubpathBezierKnotUnlinked)
                {
                    throw new Exception("VsmsResource was read wrong");
                }
                var pathFillRule = (PathFillRuleRecord)resource.Paths[0];
                var initialFillRule = (InitialFillRuleRecord)resource.Paths[1];
                var subpathLength = (LengthRecord)resource.Paths[2];

                // Path fill rule doesn't contain any additional information
                if (pathFillRule.Type != VectorPathType.PathFillRuleRecord ||
                initialFillRule.Type != VectorPathType.InitialFillRuleRecord ||
                initialFillRule.IsFillStartsWithAllPixels != false ||
                subpathLength.Type != VectorPathType.ClosedSubpathLengthRecord ||
                subpathLength.IsClosed != true ||
                subpathLength.IsOpen != false)
                {
                    throw new Exception("VsmsResource paths were read wrong");
                }

                // Editing
                resource.IsDisabled = true;
                resource.IsInverted = true;
                resource.IsNotLinked = true;
                var bezierKnot = (BezierKnotRecord)resource.Paths[3];
                bezierKnot.Points[0] = new Point(0, 0);
                bezierKnot = (BezierKnotRecord)resource.Paths[4];
                bezierKnot.Points[0] = new Point(8039798, 10905191);
                initialFillRule.IsFillStartsWithAllPixels = true;
                subpathLength.IsClosed = false;
                im.Save(exportPath);
            }
        }

        static VsmsResource GetVsmsResource(PsdImage image)
        {
            var layer = image.Layers[1];
            VsmsResource resource = null;
            var resources = layer.Resources;
            for (int i = 0; i < resources.Length; i++)
            {
                if (resources[i] is VsmsResource)
                {
                    resource = (VsmsResource)resources[i];
                    break;
                }
            }
            if (resource == null)
            {
                throw new Exception("VsmsResource not found");
            }
            return resource;
        }

        //ExEnd:GetVsmsResource
    }
}
