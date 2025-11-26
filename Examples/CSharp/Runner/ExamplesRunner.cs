
using System;
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
using Aspose.PSD.Examples.Aspose.WorkingWithPSD;
using Aspose.PSD.Examples.Aspose.Animation;
using Aspose.PSD.Examples.Aspose.LayerResources.Structures;
using Aspose.PSD.Examples.Aspose.SmartObjects;
using Aspose.PSD.Examples.Aspose.WorkingWithVectorPaths;
using Aspose.PSD.Examples.Aspose.SmartFilters;

namespace Aspose.PSD.Examples.Runner
{
    class ExamplesRunner
    {
        /// <summary>
        /// Requests for examples sections of Aspose.PSD
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Please enter your choise as number between [0..13]</exception>
        public static int RequestForSections()
        {
            Console.WriteLine("================================================");
            Console.WriteLine(
                       "Please select the Aspose.PSD features you want to test: \n" +
                       "0 - Test all features of PSD format,  \n" +
                       "1 - Open/Save Basics, \n" +
                       "2 - Conversion and Export Basics, \n" +
                       "3 - Graphic operations basics, \n" +
                       "4 - Psd Format Features\n" +
                       "5 - Psb Format Features, \n" +
                       "6 - AI Format Features, \n" +
                       "7 - AI Common Advanced Features");
            Console.WriteLine("================================================");
            Console.Write("Enter section number: ");
            string key = Console.ReadLine();

            int keyNumber = 0;

            if (keyNumber - 1 >= 0)
            {
                keyNumber = (int)Math.Pow(2, keyNumber);
            }

            if (!int.TryParse(key, out keyNumber)
                || (!typeof(ExamplesMainSection).IsEnumDefined(keyNumber - 1 >= 0 ? keyNumber = (int)Math.Pow(2, keyNumber - 1) : keyNumber = (int)ExamplesMainSection.All)))
            {
                throw new ArgumentException("Please enter your choise as number between [0..7]");
            }

            return keyNumber;
        }

        /// <summary>
        /// Requests for Examples Sub Sections of Aspose.PSD
        /// </summary>
        /// <param name="subSection">The sub section.</param>
        /// <returns>Number of selected Sub Section or 0</returns>
        public static int RequestForSubSection(int subSection)
        {
            switch ((ExamplesMainSection)subSection)
            {
                case ExamplesMainSection.Psd:
                    return RequestForPsdSection();
            }

            return 0;
        }

        /// <summary>
        /// Requests for PSD section of Aspose.PSD
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Please enter your choise as number between [0..5]</exception>
        private static int RequestForPsdSection()
        {
            Console.WriteLine("================================================");
            Console.WriteLine(
            "Please select the PSD features you want to test: \n" +
            "0 - Test all features of PSD format,  \n" +
            "1 - Psd Format Basics,  \n" +
            "2 - Layer Resources, \n" +
            "3 - Global PSD Image Resources, \n" +
            "4 - Layers Operations, \n" +
            "5 - Text Layers\n" +
            "6 - Adjustment Layers, \n" +
            "7 - Fill Layers, \n" +
            "8 - Group Layers, \n" +
            "9 - Smart Objects, \n" +
            "10 - Smart Filters, \n" +
            "11 - Working with Masks, \n" +
            "12 - Layer Effects, \n" +
            "13 - Specific Cases, \n");
            Console.WriteLine("================================================");
            Console.Write("Enter section number: ");

            string key = Console.ReadLine();

            int keyNumber = 0;

            if (keyNumber - 1 >= 0)
            {
                keyNumber = (int)Math.Pow(2, keyNumber);
            }


            if (!int.TryParse(key, out keyNumber)
                || (!typeof(ExamplesSubSectionPsd).IsEnumDefined(keyNumber - 1 >= 0 ? keyNumber = (int)Math.Pow(2, keyNumber - 1) : keyNumber = (int)ExamplesSubSectionPsd.All)))
            {
                throw new ArgumentException("Please enter your choise as number between [0..13]");
            }

            return keyNumber;
        }

        /// <summary>
        /// Runs the selected examples.
        /// </summary>
        /// <param name="mainSection">The main section.</param>
        /// <param name="subSection">The sub section.</param>
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
                    foreach (ExamplesMainSection main in Enum.GetValues(typeof(ExamplesMainSection)))
                    {
                        if (main == ExamplesMainSection.All)
                        {
                            continue;
                        }

                        RunExamples((int)main, 0);
                    }
                    break;
                case ExamplesMainSection.CommonAdvancedFeatures:
                    RunAdvancedFeatures();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Runs the advanced features examples
        /// </summary>
        private static void RunAdvancedFeatures()
        {
            Console.WriteLine("Starting Advanced Features");

            //Technical Articles
            UncompressedImageUsingFile.Run();
            UncompressedImageStreamObject.Run();

            ControllCacheReallocation.Run();
            ColorConversionUsingICCProfiles.Run();
            ColorConversionUsingDefaultProfiles.Run();
            SupportForInterruptMonitor.Run();
            InterruptMonitorTest.Run();
            CreateXMPMetadata.Run();
            UpdatingCreatorToolInPSDFile.Run();
        }

        /// <summary>
        /// Runs the AI section examples
        /// </summary>
        private static void RunAiSection()
        {
            Console.WriteLine("Starting AI (Adobe Illustrator Format) Examples");

            AIToPSD.Run();
            AIToPNG.Run();
            AIToJPG.Run();
            AIToGIF.Run();
            AIToTIFF.Run();
            AIToPDF.Run();
            AIToPDFA1a.Run();
            SupportOfAiFormatVersion8.Run();
            SupportOfRasterImagesInAI.Run();
            SupportOfLayersInAi.Run();
            SupportOfActivePageIndex.Run();
            SupportOfHasMultiLayerMasksAndColorIndexProperties.Run();
            SupportOfAiImageXmpDataProperty.Run();
            SupportAiImagePageCountProperty.Run();
        }

        /// <summary>
        /// Runs the PSB section examples.
        /// </summary>
        private static void RunPsbSection()
        {
            Console.WriteLine("Starting PSB Image Examples");

            //PSB
            PSBToPSD.Run();
            PSBToJPG.Run();
            PSBToPDF.Run();
        }

        /// <summary>
        /// Runs the PSD section examples
        /// </summary>
        /// <param name="subSection">The sub section.</param>
        private static void RunPsdSection(int subSection)
        {
            ExamplesSubSectionPsd section = CorrectAllSectionSelect(subSection);

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
                    RunSmartObjectsExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithSmartFilters:
                    RunSmartFiltersExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithMasks:
                    RunWorkingWithMasksExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithLayerEffects:
                    RunLayerEffectsExamples();
                    break;
                case ExamplesSubSectionPsd.WorkingWithAnimationAndTimeLine:
                    RunAnimationExamples();
                    break;
                case ExamplesSubSectionPsd.All:
                    foreach (ExamplesSubSectionPsd sub in Enum.GetValues(typeof(ExamplesSubSectionPsd)))
                    {
                        if (sub == ExamplesSubSectionPsd.All)
                        {
                            continue;
                        }

                        RunPsdSection((int)sub);
                    }
                    break;

                case ExamplesSubSectionPsd.SpecificCases:
                    RunPsdSpecificCases();
                    break;
            }
        }

        /// <summary>
        /// Corrects "all" section select.
        /// </summary>
        /// <param name="subSection">The sub section.</param>
        /// <returns></returns>
        private static ExamplesSubSectionPsd CorrectAllSectionSelect(int subSection)
        {
            ExamplesSubSectionPsd section;
            if (subSection == 0)
            {
                section = ExamplesSubSectionPsd.All;
            }
            else
            {
                section = (ExamplesSubSectionPsd)subSection;
            }

            return section;
        }

        /// <summary>
        /// Runs the group layers examples.
        /// </summary>
        private static void RunGroupLayersExamples()
        {
            Console.WriteLine("Starting Group Layers Examples");

            ExportLayerGroupToImage.Run();
            ChangingGroupVisibility.Run();
            CreateLayerGroups.Run();
            SupportOfPassThroughBlendingMode.Run();
            SupportOfSectionDividerLayer.Run();
            LayerGroupIsOpenSupport.Run();
            SupportOfArtboardLayer.Run();
        }

        /// <summary>
        /// Runs the basic layers operations examples.
        /// </summary>
        private static void RunBasicLayersOperationsExamples()
        {
            Console.WriteLine("Starting Basic Layer Operation Examples");

            LayerCreationDateTime.Run();
            SheetColorHighlighting.Run();
            FillOpacityOfLayers.Run();
            MergeOnePSDlayerToOther.Run();
            ExtractLayerName.Run();
            SupportOfScaleProperty.Run();
            SupportOfRotateLayer.Run();
            SupportOfUpdatingLinkedSmartObjects.Run();
            SupportOfApplyLayerMask.Run();
        }

        /// <summary>
        /// Runs the PSD specific cases examples
        /// </summary>
        private static void RunPsdSpecificCases()
        {
            Console.WriteLine("Starting PSD Specific Cases Examples");

            SettingforReplacingMissingFonts.Run();
            SupportEditingGlobalFontList.Run();
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
            RemoveFontCacheFile.Run();
            ReadAllEXIFTags.Run();
            ReadSpecificEXIFTagsInformation.Run();
            WritingAndModifyingEXIFData.Run();
            SupportForJPEG_LSWithCMYK.Run();
            SupportFor2_7BitsJPEG.Run();
            ClassesToManipulateVectorPathObjects.Run();
            SupportIPathToManipulateVectorPathObjects.Run();
            ResizeLayersWithVogkResourceAndVectorPaths.Run();
            ResizeLayersWithVectorPaths.Run();
            GettingUniqueHashForSimilarLayers.Run();
            SupportOfShapeLayer.Run();
            AddShapeLayer.Run();
            ShapeLayerManipulation.Run();
            SupportShapeLayerFillProperty.Run();
            SupportOfShapeLayerRendering.Run();
        }

        /// <summary>
        /// Runs the PSD format basics examples.
        /// </summary>
        private static void RunPsdFormatBasicsExamples()
        {
            Console.WriteLine("Starting PSD Format Basics Examples");

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
            SupportOfCMYKColorMode16bit.Run();
            SupportOfObArAndUnFlSignatures.Run();
            SupportOfMeSaSignature.Run();
            SupportOfAllowNonChangedLayerRepaint.Run();
        }

        /// <summary>
        /// Runs the examples that demonstrates how you can work with all types of masks
        /// </summary>
        private static void RunWorkingWithMasksExamples()
        {
            Console.WriteLine("Starting Working with masks Examples");

            SupportOfLayerMask.Run();
            SupportOfClippingMask.Run();
            SupportOfLayerVectorMask.Run();
            WorkingWithMasks.Run();
            SupportOfBlendClippedElementsProperty.Run();
        }

        private static void RunAdjustmentLayersExamples()
        {
            Console.WriteLine("Starting Adjustment Layers Examples");

            SupportOfAdjusmentLayers.Run();
            RenderingOfCurvesAdjustmentLayer.Run();
            AddBlackAndWhiteAdjustmentLayer.Run();
            AddCurvesAdjustmentLayer.Run();
            RenderingOfLevelAdjustmentLayer.Run();
            AddLevelAdjustmentLayer.Run();
            AddChannelMixerAdjustmentLayer.Run();
            AddHueSaturationAdjustmentLayer.Run();
            RenderingExposureAdjustmentLayer.Run();
            RenderingOfPosterizeAdjustmentLayer.Run();
            ColorBalanceAdjustment.Run();
            InvertAdjustmentLayer.Run();
            RenderingExportOfChannelMixerAdjusmentLyer.Run();
            AddVibranceAdjustmentLayer.Run();
            SupportOfPosterizeAdjustmentLayer.Run();
            SupportOfThresholdAdjustmentLayer.Run();
            SupportOfSelectiveColorAdjustmentLayer.Run();
            UsingAdjustmentLayers.Run();
            AddGradientMapAdjustmentLayer.Run();
        }

        private static void RunLayerEffectsExamples()
        {
            Console.WriteLine("Starting Layer Effects Examples");

            // Layer Effects
            LayerEffectsForPSD.Run();
            SupportOfEffectTypeProperty.Run();
            AddStrokeLayer_Pattern.Run();
            AddStrokeLayer_Gradient.Run();
            AddStrokeLayer_Color.Run();
            AddStrokeEffect.Run();
            AddGradientEffects.Run();
            AddPatternEffects.Run();
            SupportOfInnerShadowLayerEffect.Run();
            RenderingDropShadow.Run();

            RenderingColorEffect.Run();
            AddEffectAtRunTime.Run();
            ColorOverLayEffect.Run();
            SupportShadowEffect.Run();
            SupportShadowEffectOpacity.Run();

            SupportOfGradientOverlayEffect.Run();
            RenderingOfGradientOverlayEffect.Run();
            SupportOfOuterGlowEffect.Run();
            SupportOfAreEffectsEnabledProperty.Run();
            SupportOfGradientPropery.Run();
        }

        private static void RunFillLayersExamples()
        {
            Console.WriteLine("Starting Fill Layers Examples");

            // Fill Layers
            PatternFillLayer.Run();
            GradientFillLayers.Run();
            PatternFillLayer.Run();
            AddingFillLayerAtRuntime.Run();
        }

        private static void RunSmartObjectsExamples()
        {
            Console.WriteLine("Starting Smart objects Examples");

            // Smart objects
            SupportOfEmbeddedSmartObjects.Run();
            SupportOfCopyingOfSmartObjectLayers.Run();
            SupportOfConvertingLayerToSmartObject.Run();
            SupportOfReplaceContentsInSmartObjects.Run();
            SupportOfReplaceContentsByLink.Run();
            SupportOfWarpTransformationToSmartObject.Run();
            SupportOfExportContentsFromSmartObject.Run();
            WarpSettingsForSmartObjectLayerAndTextLayer.Run();
            SupportOfRenderQualityProperty.Run();
            SupportOfGridSizeProperty.Run();
        }

        private static void RunSmartFiltersExamples()
        {
            Console.WriteLine("Starting Smart filters Examples");

            // Smart filters
            SupportAccessToSmartFilters.Run();
            SupportCustomSmartFilterRenderer.Run();
            SupportSharpenSmartFilter.Run();
            DirectlyApplySmartFilter.Run();
            ManipulatingSmartFiltersInSmartObjects.Run();
        }

        private static void RunTextLayersExamples()
        {
            Console.WriteLine("Starting Text Layer Examples");

            AddTextLayer.Run();
            SetTextLayerPosition.Run();
            GetTextPropertiesFromTextLayer.Run();
            GetPropertiesOfInlineFormattingOfTextLayer.Run();
            RenderingOfDifferentStylesInOneTextLayer.Run();
            UpdateTextLayerInPSDFile.Run();
            TextLayerBoundBox.Run();
            AddTextLayerOnRuntime.Run();
            RenderTextWithDifferentColorsInTextLayer.Run();
            SupportOfITextStyleProperties.Run();
            SupportOfEditFontNameInTextPortionStyle.Run();
            SupportTextStyleJustificationMode.Run();
            SupportTextOrientationPropertyEdit.Run();
            SupportIsStandardVerticalRomanAlignmentEnabledPropertyEdit.Run();
            SupportOfLeadingTypeInTextPortion.Run();
        }

        private static void RunGlobalResourcesExamples()
        {
            Console.WriteLine("Starting Gloabal PSD Resources Examples");

            // Global Resources of Psd Image
            SupportOfBackgroundColorResource.Run();
            SupportOfBorderInformationResource.Run();
            SupportOfWorkingPathResource.Run();
        }

        /// <summary>
        /// Runs the layer resources examples.
        /// </summary>
        private static void RunLayerResourcesExamples()
        {
            Console.WriteLine("Starting Layer Resources Examples");

            // Layer Resources
            AddIopaResource.Run();
            SupportOfVogkResource.Run();
            SupportOfVogkResourceProperties.Run();
            SupportOfVectorShapeTransformOfVogkResource.Run();
            SupportOfLclrResource.Run();
            VsmsResourceLengthRecordSupport.Run();
            SupportForClblResource.Run();
            SupportForBlwhResource.Run();
            SupportForLspfResource.Run();
            SupportForInfxResource.Run();
            SupportOfVsmsResource.Run();
            SupportOfSoCoResource.Run();
            SupportOfPtFlResource.Run();
            SupportOfNvrtResource.Run();
            SupportOfBritResource.Run();
            SupportOfLnkEResource.Run();
            SupportOfLnk2AndLnk3Resource.Run();
            SupportOfPlLdResource.Run();
            SupportOfSoLdResource.Run();
            SupportOfPlacedResource.Run();
            SupportOfFXidResource.Run();
            SupportOfVibAResource.Run();
            SupportOfVstkResource.Run();
            SupportOfVscgResource.Run();
            SupportOfPostResource.Run();
            SupportOfGrdmResource.Run();
            SupportOfLMskResource.Run();
            SupportOfArtBResourceArtDResourceLyvrResource.Run();
            SupportForImfxResource.Run();
            SupportOfNameStructure.Run();
        }

        /// <summary>
        /// Graphics operations basics examples.
        /// </summary>
        private static void GraphicOperationsBasics()
        {
            Console.WriteLine("Starting Graphic Operations Basics Example");

            //Drawing Images
            DrawingLines.Run();
            DrawingEllipse.Run();
            DrawingRectangle.Run();
            DrawingArc.Run();
            DrawingBezier.Run();
            CoreDrawingFeatures.Run();
            DrawingUsingGraphics.Run();
            DrawingUsingGraphicsPath.Run();
            PixelDataManipulation.Run();

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
            CroppingbyRectangle.Run();
            RotatinganImage.Run();
            RotatinganImageonaSpecificAngle.Run();
            ResizeImageProportionally.Run();
            RotatePatternSupport.Run();

            // Common operations
            VerifyImageTransparency.Run();
            AddSignatureToImage.Run();
            AddWatermark.Run();
            AddDiagnolWatermark.Run();
            RawColorClass.Run();

            CombiningImages.Run();
            ExpandandCropImages.Run();
        }

        /// <summary>
        /// Conversions and export basics examples
        /// </summary>
        private static void ConversionAndExportBasics()
        {
            Console.WriteLine("Starting Conversion and Export Basics Examples");
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
            Saving16BitGrayscalePsdImage.Run();
            Saving16BitGrayscalePsdTo8BitGrayscale.Run();
            Saving16BitGrayscalePsdTo8BitRgb.Run();
            ConvertPsdToJpg.Run();
            ConvertPsdToPng.Run();
            ConvertPsdToPdf.Run();

            GIFImageLayersToTIFF.Run();
            CMYKPSDtoCMYKTiff.Run();
            ConversionPSDToGrayscaleRgbCmyk.Run();

            // Png export abilities
            SpecifyTransparencyOfPngOnExport.Run();
            SettingResolutionOfPngOnExport.Run();
            SetPngCompressingOnExport.Run();
            SpecifyBitDepthOnPng.Run();
            ApplyFilterMethodOnPng.Run();
            ChangeBackgroundColorOfPng.Run();

            SupportOfPsdOptionsBackgroundContentsProperty.Run();
            SupportOfExportLayerWithEffects.Run();
        }

        /// <summary>
        /// Runs the examples that demonstrates open/save basics.
        /// </summary>
        private static void RunOpenSaveCreateBasics()
        {
            Console.WriteLine("Starting Open/Save/Create Basics Examples");
            //Opening and saving
            SavingtoStream.Run();
            LoadingFromStream.Run();
            ExportImagesinMultiThreadEnv.Run();
            LoadPSDWithReadOnlyMode.Run();
            CreatingbySettingPath.Run();
            UsingDocumentConversionProgressHandler.Run();
            EditMetadataInReadonlyMode.Run();
        }
        
        /// <summary>
        /// Runs the examples that demonstrates work with timeline and other animation data.
        /// </summary>
        private static void RunAnimationExamples()
        {
            Console.WriteLine("Starting Animation Examples");

            SupportOfAnimatedDataSection.Run();
            SupportOfMlstResource.Run();
            SupportOfTimeLine.Run();
            SupportOfLayerStateEffects.Run();
            SupportOfPsdImageTimelineProperty.Run();
            SupportExportToGifImage.Run();
        }
    }
}