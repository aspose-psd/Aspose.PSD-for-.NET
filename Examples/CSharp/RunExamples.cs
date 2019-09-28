using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.Examples.Aspose.Conversion;
using Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages;
using Aspose.PSD.Examples.Aspose.DrawingImages;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.JPEG;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PNG;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.TIFF;
using Aspose.PSD.Examples.Licensing;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSB;
using Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.AI;
using Aspose.PSD.Examples.Aspose.Opening;

namespace Aspose.PSD.Examples
{
    class RunExamples
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");


            // Uncomment the one you want to try out


            //Metered Licensing
            //MeteredLicensing.Run();
            String licPath = GetDataDir_PSD() + @"Aspose.PSD.NET.lic";
            License lic = new License();
     //       lic.SetLicense(licPath);
            lic.SetLicense(@"C:\Aspose Data\Licenses_2019\Aspose.Total.NET.lic");

            //bool isLicensd = lic.IsLicensed;

            //// =====================================================
            //// =====================================================
            ////            Conversion to Rasters Images
            //// =====================================================
            //// =====================================================

            //PSDToRasterImageFormats.Run();
            //CroppingPSDWhenConvertingToPNG.Run();
            //ApplyMedianAndWienerFilters.Run();
            //ApplyGausWienerFilters.Run();
            //ApplyGausWienerFiltersForColorImage.Run();
            //ApplyMotionWienerFilters.Run();
            //BinarizationWithFixedThreshold.Run();
            //BinarizationWithOtsuThreshold.Run();
            //Garysacling.Run();
            //GIFImageLayersToTIFF.Run();
            //CMYKPSDtoCMYKTiff.Run();
            //SettingforReplacingMissingFonts.Run();
            //SavingtoDisk.Run();
            //SavingtoStream.Run();
            //LoadingFromStream.Run();
            //ExportImagesinMultiThreadEnv.Run();
            //LayerCreationDateTime.Run();
            //SheetColorHighlighting.Run();
            //MergeOnePSDlayerToOther.Run();
            //TextLayerBoundBox.Run();
            //AddIopaResource.Run();
            //LayerEffectsForPSD.Run();
            //InterruptMonitorTest.Run();
            //PossibilityToFlattenLayers.Run();
            //FillOpacityOfLayers.Run ();
            //RenderingOfCurvesAdjustmentLayer.Run();
            //AddCurvesAdjustmentLayer.Run();
            //RenderingOfLevelAdjustmentLayer.Run();
            //AddLevelAdjustmentLayer.Run();
            //AddChannelMixerAdjustmentLayer.Run();
            //AddHueSaturationAdjustmentLayer.Run();
            //RenderingExposureAdjustmentLayer.Run();
            //RenderingExportOfChannelMixerAdjusmentLyer.Run();
            //SupportOfClippingMask.Run();
            //SupportOfLayerMask.Run();
            //ManagePhotoFilterAdjustmentLayer.Run();
            //ManageChannelMixerAdjusmentLayer.Run();
            //ManageExposureAdjustmentLayer.Run();
            //ManageBrightnessContrastAdjustmentLayer.Run();
            //SupportOfAdjusmentLayers.Run();
            //AddTextLayerOnRuntime.Run();

            //// =====================================================
            //// =====================================================
            ////            Drawing and Formatting Images
            //// =====================================================
            //// =====================================================
            //CombiningImages.Run();
            //ExpandandCropImages.Run();
            //CreateXMPMetadata.Run();
            //CreatingbySettingPath.Run();
            //RenderingDropShadow.Run();
            //SupportBlendModes.Run();
            //RenderingColorEffect.Run();
            //AddEffectAtRunTime.Run();
            //ColorOverLayEffect.Run();
            //SupportShadowEffect.Run();
            //This one failed
            // CreatingUsingStream.Run();
            //CroppingbyShifts.Run();
            //CroppingbyRectangle.Run();
            //RotatinganImage.Run();
            //RotatinganImageonaSpecificAngle.Run();
            //SimpleResizing.Run();
            //ResizingwithResizeTypeEnumeration.Run();
            //ResizeImageProportionally.Run();
            //DitheringforRasterImages.Run();
            //AdjustingBrightness.Run();
            //AdjustingContrast.Run();
            //AdjustingGamma.Run();
            //BluranImage.Run();
            //VerifyImageTransparency.Run();
            //ImplementLossyGIFCompressor.Run();
            //ForceFontCache.Run();
            //FontReplacement.Run();

            //Drawing Images
            //DrawingLines.Run();
            //DrawingEllipse.Run();
            //DrawingRectangle.Run();
            //DrawingArc.Run();
            //DrawingBezier.Run();
            //CoreDrawingFeatures.Run();
            //DrawingUsingGraphics.Run();
            //DrawingUsingGraphicsPath.Run();
            //AddStrokeLayer_Pattern.Run();
            //AddStrokeLayer_Gradient.Run();
            //AddStrokeLayer_Color.Run();
            //AddGradientEffects.Run();
            //AddPatternEffects.Run();
            //AddNewRegularLayerToPSD.Run();


            //Modifying and Converting Images
            //JPEG
            //ReadAllEXIFTags.Run();
            //ReadSpecificEXIFTagsInformation.Run();
            //WritingAndModifyingEXIFData.Run();
            //ExtractThumbnailFromPSD.Run();
            //ExtractThumbnailFromJFIF.Run();
            //AddThumbnailToJFIFSegment.Run();
            //AddThumbnailToEXIFSegment.Run();
            //ReadandModifyJpegEXIFTags.Run();
            //ReadAllEXIFTagList.Run();
            //AutoCorrectOrientationOfJPEGImages.Run();
            //SupportForJPEG_LSWithCMYK.Run();
            //SupportFor2_7BitsJPEG.Run();
            //ColorTypeAndCompressionType.Run();

            //PSD
            //ExportImageToPSD.Run();
            //ImportImageToPSDLayer.Run();
            //ColorReplacementInPSD.Run();
            //CreateThumbnailsFromPSDFiles.Run();
            //CreateIndexedPSDFiles.Run();
            //ExportPSDLayerToRasterImage.Run();
            //UpdateTextLayerInPSDFile.Run();
            //DetectFlattenedPSD.Run();
            //MergePSDlayers.Run();
            //GrayScaleSupportForAlpha.Run();
            //SupportLayerForPSD.Run();
            //LoadImageToPSD.Run();
            //SupportOfRGBColor.Run();
            //SupportOfRotateLayer.Run();
             //PatternFillLayer.Run();
            //SupportOfPtFlResource.Run();
            //CropPSDFile.Run();
            //SupportOfVsmsResource.Run();
            //PSDToPSB.Run();
            //SetTextLayerPosition.Run();
            //SupportOfLayerVectorMask.Run();
            //ResizePSDFile.Run();
            //PSDToPDF.Run();
            //GradientFillLayers.Run();
            //PSDToPDFWithSelectableText.Run();
            //AddTextLayer.Run();
            //LoadPSDWithReadOnlyMode.Run();
            //ExtractLayerName.Run();
            //SupportOfScaleProperty.Run();
            //CreateLayerGroups.Run();
            //GetTextPropertiesFromTextLayer.Run();

            //PNG
            //SpecifyTransparency.Run();
            //SettingResolution.Run();
            //CompressingFiles.Run();
            //SpecifyBitDepth.Run();
            //ApplyFilterMethod.Run();
            //ChangeBackgroundColor.Run();

            //TIFF
            //ExportToMultiPageTiff.Run();
            //TiffOptionsConfiguration.Run();
            //TIFFwithDeflateCompression.Run();
            //TIFFwithAdobeDeflateCompression.Run();
            //CompressingTiff.Run();



            //Technical Articles
            //UncompressedImageUsingFile.Run();
            //UncompressedImageStreamObject.Run();

            //This example has exception
            //ControllCacheReallocation.Run();

            //AddWatermark.Run();
            //AddDiagnolWatermark.Run();
            //ColorConversionUsingICCProfiles.Run();
            //ColorConversionUsingDefaultProfiles.Run();
            //AddSignatureToImage.Run();
            //SupportForInterruptMonitor.Run();
      
             //PSB
            //PSBToPSD.Run();
           // PSBToJPG.Run();
            //PSBToPDF.Run();
            
            //AI
            //AIToPSD.Run();
            //AIToPNG.Run();
            //AIToJPG.Run();
            //AIToGIF.Run();
            //AIToTIFF.Run();

            //Opening
            //LoadingImageFromStream.Run();
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static String GetDataDir_Export(string path)
        {
            return System.IO.Path.GetFullPath(GetDataDir_Data() + "Export/" + path + "/");
        }

        public static String GetDataDir_Files()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Files/");
        }

        public static String GetDataDir_Images(string path)
        {
            return Path.GetFullPath(GetDataDir_Data() + "Images/" + path + "/");
        }

        public static String GetDataDir_PNG()
        {
            return Path.GetFullPath(GetDataDir_Data() + "PNG/");
        }

        public static String GetDataDir_DrawingAndFormattingImages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "DrawingAndFormattingImages/");
        }

        public static String GetDataDir_DICOM()
        {
            return Path.GetFullPath(GetDataDir_Data() + "DICOM/");
        }

        public static String GetDataDir_JPEG()
        {
            return Path.GetFullPath(GetDataDir_Data() + "JPEG/");
        }

        public static String GetDataDir_ModifyingAndConvertingImages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ModifyingAndConvertingImages/");
        }

        public static String GetDataDir_Cache()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Cache/");
        }

        public static String GetDataDir_MetaFiles()
        {
            return Path.GetFullPath(GetDataDir_Data() + "MetaFiles/");
        }

        public static String GetDataDir_PSD()
        {
            return Path.GetFullPath(GetDataDir_Data() + "PSD/");
        }
        public static String GetDataDir_PSB()
        {
            return Path.GetFullPath(GetDataDir_Data() + "PSB/");
        }

        public static String GetDataDir_WebPImages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WebPImage/");
        }

        public static String GetDataDir_DjVu()
        {
            return Path.GetFullPath(GetDataDir_Data() + "DjVu/");
        }
        
        public static String GetDataDir_AI()
        {
            return Path.GetFullPath(GetDataDir_Data() + "AI/");
        }
        public static String GetDataDir_Opening()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Opening/");
        }

        public static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return System.IO.Path.Combine(startDirectory, "Data\\");
        }
    }
}
