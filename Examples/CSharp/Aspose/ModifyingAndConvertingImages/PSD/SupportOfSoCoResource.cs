﻿using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers.FillLayers;
using Aspose.PSD.FileFormats.Psd.Layers.LayerResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class SupportOfSoCoResource
    {


        public static void Run() {

            //ExStart:SupportOfSoCoResource

            string dataDir = RunExamples.GetDataDir_PSD();
            string sourceFileName = dataDir + "ColorFillLayer.psd";
            string exportPath = dataDir +"SoCoResource_Edited.psd";

            var im = (PsdImage)Image.Load(sourceFileName);

            using (im)
            {
                foreach (var layer in im.Layers)
                {
                    if (layer is FillLayer)
                    {
                        var fillLayer = (FillLayer)layer;
                        foreach (var resource in fillLayer.Resources)
                        {
                            if (resource is SoCoResource)
                            {
                                var socoResource = (SoCoResource)resource;
                                Assert.AreEqual(Color.FromArgb(63, 83, 141), socoResource.Color);
                                socoResource.Color = Color.Red;
                                break;
                            }
                        }
                        break;
                    }
                    im.Save(exportPath);
                }
            }

            //ExEnd:SupportOfSoCoResource


        }
    }
}