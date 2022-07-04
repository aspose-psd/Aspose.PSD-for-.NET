using System;
using System.Collections.Generic;
using System.IO;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources.TypeToolInfoStructures;
using Aspose.PSD.FileFormats.Psd.Resources;

namespace Aspose.PSD.Examples.Aspose.Animation
{
    public class SupportOfAnimatedDataSection
    {
        public static void Run()
        {
            // The path to the documents directory.
            string baseDir = RunExamples.GetDataDir_PSD();
            string outputDir = RunExamples.GetDataDir_Output();
            
            //ExStart:SupportOfAnimatedDataSection
            //ExSummary:The following code demonstrates how to set/update delay time in the timeline frame of animated data.
            
            string sourceFile = Path.Combine(baseDir, "3_animated.psd");
            string outputPsd = Path.Combine(outputDir, "output_3_animated.psd");

            T FindStructure<T>(IEnumerable<OSTypeStructure> structures, string keyName) where T : OSTypeStructure
            {
                foreach (var structure in structures)
                {
                    if (structure.KeyName.ClassName == keyName)
                    {
                        return structure as T;
                    }
                }

                return null;
            }

            OSTypeStructure[] AddOrReplaceStructure(IEnumerable<OSTypeStructure> structures, OSTypeStructure newStructure)
            {
                List<OSTypeStructure> listOfStructures = new List<OSTypeStructure>(structures);

                for (int i = 0; i < listOfStructures.Count; i++)
                {
                    OSTypeStructure structure = listOfStructures[i];
                    if (structure.KeyName.ClassName == newStructure.KeyName.ClassName)
                    {
                        listOfStructures.RemoveAt(i);
                        break;
                    }
                }

                listOfStructures.Add(newStructure);

                return listOfStructures.ToArray();
            }

            using (PsdImage image = (PsdImage)Image.Load(sourceFile))
            {
                foreach (var imageResource in image.ImageResources)
                {
                    if (imageResource is AnimatedDataSectionResource)
                    {
                        var animatedData =
                            (AnimatedDataSectionStructure) (imageResource as AnimatedDataSectionResource).AnimatedDataSection;
                        var framesList = FindStructure<ListStructure>(animatedData.Items, "FrIn");

                        var frame1 = (DescriptorStructure)framesList.Types[1];

                        // Creates the frame delay record with value 100 centi-second that is equal to 1 second.
                        var frameDelay = new IntegerStructure(new ClassID("FrDl"));
                        frameDelay.Value = 100; // set time in centi-seconds.

                        frame1.Structures = AddOrReplaceStructure(frame1.Structures, frameDelay);

                        break;
                    }
                }

                image.Save(outputPsd);
            }
            
            //ExEnd:SupportOfAnimatedDataSection
            
            File.Delete(outputPsd);
            
            Console.WriteLine("SupportOfAnimatedDataSection executed successfully");
        }
    }
}