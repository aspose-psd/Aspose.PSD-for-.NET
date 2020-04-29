
using Aspose.PSD.Examples.Aspose.Ai;
using Aspose.PSD.Examples.Aspose.Conversion;
using Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages;
using Aspose.PSD.Examples.Aspose.DrawingImages;
using Aspose.PSD.Examples.Aspose.FillLayers;
using Aspose.PSD.Examples.Aspose.GlobalResources;
using Aspose.PSD.Examples.Aspose.LayerEffects;
using Aspose.PSD.Examples.Aspose.LayerResources;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSB;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.TIFF;
using Aspose.PSD.Examples.Aspose.Opening;
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
                case ExamplesMainSection.OpenSaveCreateBasics:
                    RunOpenSaveCreateBasics();
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
                case ExamplesMainSection.CommonAdvancedFeatures:
                    RunAdvancedFeatures();
                    break;
                default:
                    break;
            }
        }

        private static void RunAdvancedFeatures()
        {
            //Technical Articles
            UncompressedImageUsingFile.Run();
            UncompressedImageStreamObject.Run();
            ControllCacheReallocation.Run();
            ColorConversionUsingICCProfiles.Run();
            ColorConversionUsingDefaultProfiles.Run();
            SupportForInterruptMonitor.Run();
            InterruptMonitorTest.Run();
            CreateXMPMetadata.Run();
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
                case ExamplesSubSectionPsd.PsdFormatBasics:
                    RunPsdFormatBasicsExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithLayerResources:
                    RunLayerResourcesExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithGlobalResources:
                    RunGlobalResourcesExamples();
                    break;
                case ExamplesSubSectionPsd.BasicLayersOperations:
                    RunBasicLayersOperationsExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithTextLayers:
                    RunTextLayersExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithAdjustmentLayers:
                    RunAdjustmentLayersExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithFillLayers:
                    RunFillLayersExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithGroupLayers:
                    RunGroupLayersExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithSmartObjectLayers:
                    // Support of Photoshop Smart Object is in the our Roadmap
                    break;
                case ExamplesSubSectionPsd.WorkingWithSmartFilters:
                    // Support of Photoshop Smart Filters is in the our Roadmap
                    break;
                case ExamplesSubSectionPsd.WorkingWithMasks:
                    RunWorkingWithMasksExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithLayerEffects:
                    RunLayerEffectsExamples();
                    break;
                case ExamplesSubSectionPsd.All:
                    break;

                case ExamplesSubSectionPsd.SpecificCases:
                    RunPsdSpecificCases();
                    break;
            }
        }

        private static void RunGroupLayersExamples()
        {
            //ExportLayerGroupToImage.Run();    
            //ChangingGroupVisibility.Run();
            //CreateLayerGroups.Run();
            //SupportOfPassThroughBlendingMode.Run();

        }

        private static void RunBasicLayersOperationsExamples()
        {
            LayerCreationDateTime.Run();
            SheetColorHighlighting.Run();
            FillOpacityOfLayers.Run();
            MergeOnePSDlayerToOther.Run();
            ExtractLayerName.Run();
            SupportOfScaleProperty.Run();
            SupportOfRotateLayer.Run();

        }

        private static void RunPsdSpecificCases()
        {
            SettingforReplacingMissingFonts.Run();
            ImplementBicubicResampler.Run();
            DetectFlattenedPSD.Run();
            ColorReplacementInPSD.Run();
            CreateThumbnailsFromPSDFiles.Run();
            CreateIndexedPSDFiles.Run();
            ExtractThumbnailFromJFIF.Run();
            AddThumbnailToJFIFSegment.Run();
            AddThumbnailToEXIFSegment.Run();
            ReadandModifyJpegEXIFTags.Run();
            ReadAllEXIFTagList.Run();
            ImplementLossyGIFCompressor.Run();
            ForceFontCache.Run();
            FontReplacement.Run();
            ReadAllEXIFTags.Run();
            ReadSpecificEXIFTagsInformation.Run();
            WritingAndModifyingEXIFData.Run(); 
            SupportForJPEG_LSWithCMYK.Run();
            SupportFor2_7BitsJPEG.Run();

        }

        private static void RunPsdFormatBasicsExamples()
        {           
            PSDToRasterImageFormats.Run();
            LoadingImageFromStreamAsALayer.Run();
            CroppingPSDWhenConvertingToPNG.Run();
            CropPSDFile.Run();
            ResizePSDFile.Run();
            PossibilityToFlattenLayers.Run();
            AddNewRegularLayerToPSD.Run();
            SupportOfLinkedLayer.Run();
            MergePSDlayers.Run();
            SupportBlendModes.Run();
            SupportLayerForPSD.Run();
            ExtractThumbnailFromPSD.Run();
            SupportOfRGBColorModeWith16BitPerChannel.Run();
            ColorTypeAndCompressionType.Run();
        }

        /// <summary>
        /// Runs the examples that demostrates how you can work with all types of masks
        /// </summary>
        private static void RunWorkingWithMasksExamples()
        {
            SupportOfLayerMask.Run();
            SupportOfClippingMask.Run();
            SupportOfLayerVectorMask.Run();
        }

        private static void RunAdjustmentLayersExamples()
        {
            SupportOfAdjusmentLayers.Run();
            RenderingOfCurvesAdjustmentLayer.Run();
            AddBlackAndWhiteAdjustmentLayer.Run();
            AddCurvesAdjustmentLayer.Run();
            RenderingOfLevelAdjustmentLayer.Run();
            AddLevelAdjustmentLayer.Run();
            AddChannelMixerAdjustmentLayer.Run();
            AddHueSaturationAdjustmentLayer.Run();
            RenderingExposureAdjustmentLayer.Run();
            ColorBalanceAdjustment.Run();
            InvertAdjustmentLayer.Run();
            RenderingExportOfChannelMixerAdjusmentLyer.Run();
        }

        private static void RunLayerEffectsExamples()
        {
            // Layer Effects
            LayerEffectsForPSD.Run();
            AddStrokeLayer_Pattern.Run();
            AddStrokeLayer_Gradient.Run();
            AddStrokeLayer_Color.Run();
            AddGradientEffects.Run();
            AddPatternEffects.Run();
            SupportOfInnerShadowLayerEffect.Run();
            RenderingDropShadow.Run();

            RenderingColorEffect.Run();
            AddEffectAtRunTime.Run();
            ColorOverLayEffect.Run();
            SupportShadowEffect.Run();

            SupportOfGradientOverlayEffect.Run();
            RenderingOfGradientOverlayEffect.Run();
        }

        private static void RunFillLayersExamples()
        {
            // Fill Layers
            PatternFillLayer.Run();
            GradientFillLayers.Run();
            PatternFillLayer.Run();
            AddingFillLayerAtRuntime.Run();
        }

        private static void RunTextLayersExamples()
        {
            AddTextLayer.Run();
            SetTextLayerPosition.Run();
            GetTextPropertiesFromTextLayer.Run();
            GetPropertiesOfInlineFormattingOfTextLayer.Run();
            RenderingOfDifferentStylesInOneTextLayer.Run();
            UpdateTextLayerInPSDFile.Run();
            TextLayerBoundBox.Run();
            AddTextLayerOnRuntime.Run();
            RenderTextWithDifferentColorsInTextLayer.Run();
        }

        private static void RunGlobalResourcesExamples()
        {
            // Global Resources of Psd Image
            SupportOfBackgroundColorResource.Run();
            SupportOfBorderInformationResource.Run();
        }

        private static void RunLayerResourcesExamples()
        {
            // Layer Resources
            //AddIopaResource.Run();
            SupportOfVogkResource.Run();
            SupportOfLclrResource.Run();
            VsmsResourceLengthRecordSupport.Run();
            SupportForClblResource.Run();
            SupportForBlwhResource.Run();
            SupportForLspfResource.Run();
            SupportForInfxResource.Run();
            SupportOfVsmsResource.Run();
            SupportOfSoCoResource.Run();
            SupportOfPtFlResource.Run();
        }

        private static void GraphicOperationsBasics()
        {
            //Drawing Images
            DrawingLines.Run();
            DrawingEllipse.Run();
            DrawingRectangle.Run();
            DrawingArc.Run();
            DrawingBezier.Run();
            CoreDrawingFeatures.Run();
            DrawingUsingGraphics.Run();
            DrawingUsingGraphicsPath.Run();


            // Filters
            ApplyMedianAndWienerFilters.Run();
            ApplyGausWienerFilters.Run();
            ApplyGausWienerFiltersForColorImage.Run();
            ApplyMotionWienerFilters.Run();
            BinarizationWithFixedThreshold.Run();
            BinarizationWithOtsuThreshold.Run();
            Grayscaling.Run();
            DitheringforRasterImages.Run();
            AdjustingBrightness.Run();
            AdjustingContrast.Run();
            AdjustingGamma.Run();
            BluranImage.Run();

            // Crop, Resize, Rotate
            CroppingbyShifts.Run();
            CroppingbyRectangle.Run();
            RotatinganImage.Run();
            RotatinganImageonaSpecificAngle.Run();
            SimpleResizing.Run();
            ResizingwithResizeTypeEnumeration.Run();
            ResizeImageProportionally.Run();

            // Common operations
            VerifyImageTransparency.Run();
            AddSignatureToImage.Run();
            AddWatermark.Run();
            AddDiagnolWatermark.Run();

            CombiningImages.Run();
            ExpandandCropImages.Run();
        }

        private static void ConversionAndExportBasics()
        {
            PSDToPDFWithClippingMask.Run();
            PSDToPDFWithAdjustmentLayers.Run();
            ExportImageToPSD.Run();
            ExportPSDLayerToRasterImage.Run();
            ImportImageToPSDLayer.Run();
            LoadImageToPSD.Run();
            PSDToPSB.Run();
            PSDToPDF.Run();
            PSDToPDFWithSelectableText.Run();
            ExportToMultiPageTiff.Run();
            TiffOptionsConfiguration.Run();
            TIFFwithDeflateCompression.Run();
            TIFFwithAdobeDeflateCompression.Run();
            CompressingTiff.Run();

            GIFImageLayersToTIFF.Run();
            CMYKPSDtoCMYKTiff.Run();

            // Png export abilities
            SpecifyTransparencyOfPngOnExport.Run();
            SettingResolutionOfPngOnExport.Run();
            SetPngCompressingOnExport.Run();
            SpecifyBitDepthOnPng.Run();
            ApplyFilterMethodOnPng.Run();
            ChangeBackgroundColorOfPng.Run();
        }

        /// <summary>
        /// Runs the examples that demonstrates open/save basics.
        /// </summary>
        private static void RunOpenSaveCreateBasics()
        {
            //Opening and saving
            SavingtoDisk.Run();
            SavingtoStream.Run();
            LoadingFromStream.Run();
            ExportImagesinMultiThreadEnv.Run();
            LoadPSDWithReadOnlyMode.Run();
            CreatingbySettingPath.Run();

        }
    }
}
