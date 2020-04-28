
using Aspose.PSD.Examples.Aspose.Ai;
using Aspose.PSD.Examples.Aspose.Conversion;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSB;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD;
using System;
using System.Collections.Generic;

namespace Aspose.PSD.Examples.Runner
{
    class ExamplesRunner
    {
        public ExamplesRunner()
        {
         
        }

        public static int RequestForSections()
        {
            Console.WriteLine(
            "Please select the features you want to test: \n0 - Open/Save Basics, \n1 - Conversion and Export basics, \n2 - Graphic operations basics, \n3 - Psd Format Advanced Features\n4 - Psb Format Advanced Features, \n5 - AI Format Advanced Features");
            Console.WriteLine("=====================================================");

            string key = Console.ReadLine();

            int keyNumber = 0;

            if (keyNumber - 1 >= 0)
            {
                keyNumber = (int)Math.Pow(2, keyNumber);
            }


            if (!int.TryParse(key, out keyNumber)
                || (!typeof(ExamplesMainSection).IsEnumDefined(keyNumber - 1 >= 0 ? keyNumber = (int)Math.Pow(2, keyNumber - 1) : keyNumber = (int)ExamplesMainSection.All)))
            {
                throw new ArgumentException("Please enter your choise as number between [0..5]");
            }

            return keyNumber;

        }

        public static int RequestForSubSection(int mainSection)
        {
            return 0;
        }

        public static void RunExamples(int mainSection, int subSection)
        {
            var section = (ExamplesMainSection)mainSection;
            switch (section)
            {
                case ExamplesMainSection.OpenSaveBasics:
                    RunOpenSaveBasics();
                    break;
                case ExamplesMainSection.ConversionAndExportBasics:
                    ConversionAndExportBasics();
                    break;
                case ExamplesMainSection.GraphicOperationsBasics:
                    GraphicOperationsBasics();
                    break;
                case ExamplesMainSection.Psd:
                    RunPsdSection(subSection);
                    break;
                case ExamplesMainSection.Psb:
                    RunPsbSection();
                    break;
                case ExamplesMainSection.Ai:
                    RunAiSection();
                    break;
                case ExamplesMainSection.All:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Runs the AI section examples
        /// </summary>
        private static void RunAiSection()
        {
            AIToPSD.Run();
            AIToPNG.Run();
            AIToJPG.Run();
            AIToGIF.Run();
            AIToTIFF.Run();
            AIToPDF.Run();
            SupportOfAiFormatVersion8.Run();
            SupportOfRasterImagesInAI.Run();
            SupportOfLayersInAi.Run();
        }

        private static void RunPsbSection()
        {
            //PSB
            PSBToPSD.Run();
            PSBToJPG.Run();
            PSBToPDF.Run();
        }

        private static void RunPsdSection(int subSection)
        {
            var section = (ExamplesSubSectionPsd)subSection;

            switch (section)
            {
                case ExamplesSubSectionPsd.WorkingWithLayerResources:
                    break;
                case ExamplesSubSectionPsd.WorkingWithGlobalResources:
                    break;
                case ExamplesSubSectionPsd.WorkingWithRegularLayers:
                    break;
                case ExamplesSubSectionPsd.WorkingWithTextLayers:
                    break;
                case ExamplesSubSectionPsd.WorkingWithAdjustmentLayers:
                    break;
                case ExamplesSubSectionPsd.WorkingWithFillLayers:
                    break;
                case ExamplesSubSectionPsd.WorkingWithSmartObjectLayers:
                    break;
                case ExamplesSubSectionPsd.WorkingWithSmartFiltersLayers:
                    break;
                case ExamplesSubSectionPsd.WorkingWithMasks:
                    break;
                case ExamplesSubSectionPsd.WorkingWithLayerEffects:
                    break;
                case ExamplesSubSectionPsd.All:
                    break;
                default:
            }
        }

        private static void GraphicOperationsBasics()
        {
            //Drawing Images
            //DrawingLines.Run();
            //DrawingEllipse.Run();
            //DrawingRectangle.Run();
            //DrawingArc.Run();
            //DrawingBezier.Run();
            //CoreDrawingFeatures.Run();
            //DrawingUsingGraphics.Run();
            //DrawingUsingGraphicsPath.Run();


            // Filters
            //ApplyMedianAndWienerFilters.Run();
            //ApplyGausWienerFilters.Run();
            //ApplyGausWienerFiltersForColorImage.Run();
            //ApplyMotionWienerFilters.Run();
            //BinarizationWithFixedThreshold.Run();
            //BinarizationWithOtsuThreshold.Run();
            //Garysacling.Run();
        }

        private static void ConversionAndExportBasics()
        {
            //PSDToPDFWithClippingMask.Run();
            //PSDToPDFWithAdjustmentLayers.Run();
            //ExportImageToPSD.Run();
            //ExportPSDLayerToRasterImage.Run();
            //ImportImageToPSDLayer.Run();
            //LoadImageToPSD.Run();
            //PSDToPSB.Run();
            //PSDToPDF.Run();
            //PSDToPDFWithSelectableText.Run();
            //ExportToMultiPageTiff.Run();
            //TiffOptionsConfiguration.Run();
            //TIFFwithDeflateCompression.Run();
            //TIFFwithAdobeDeflateCompression.Run();
            //CompressingTiff.Run();
        }

        /// <summary>
        /// Runs the examples that demonstrates open/save basics.
        /// </summary>
        private static void RunOpenSaveBasics()
        {
            SavingtoDisk.Run();
            SavingtoStream.Run();
            LoadingFromStream.Run();
            ExportImagesinMultiThreadEnv.Run();
            LoadPSDWithReadOnlyMode.Run();
        }
    }
}
