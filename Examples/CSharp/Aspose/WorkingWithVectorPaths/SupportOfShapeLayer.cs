using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.ImageLoadOptions;

namespace Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths
{
    public class SupportOfShapeLayer
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();

            //ExStart:SupportOfShapeLayer
            //ExSummary:The following code shows support for the ShapeLayer layer.
            
            string srcFile = Path.Combine(baseDir, "ShapeLayerTest.psd");
            string outFile = Path.Combine(outputDir, "ShapeLayerTest-out.psd");

            using (PsdImage image = (PsdImage)Image.Load(srcFile, new PsdLoadOptions { LoadEffectsResource = true }))
            {
                ShapeLayer shapeLayer = (ShapeLayer)image.Layers[1];
                IPath layerPath = shapeLayer.Path;

                IPathShape[] pathShapeSource = layerPath.GetItems();
                List<IPathShape> pathShapesDest = new List<IPathShape>(pathShapeSource);

                // Source file contains 2 figures. Remove the seconds one.
                pathShapesDest.RemoveAt(1);

                layerPath.SetItems(pathShapesDest.ToArray());

                shapeLayer.Update();

                image.Save(outFile);
            }
            
            //ExEnd:SupportOfShapeLayer

            File.Delete(outFile);

            Console.WriteLine("SupportOfShapeLayer executed successfully");
        }
    }
}