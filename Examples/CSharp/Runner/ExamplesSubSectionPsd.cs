using System;

namespace Aspose.PSD.Examples.Runner
{

    [Flags]
    enum ExamplesSubSectionPsd
    {
        PsdFormatBasics = 1,

        WorkingWithLayerResources = 2,

        WorkingWithGlobalResources = 4,

        BasicLayersOperations = 8,

        WorkingWithTextLayers = 16,

        WorkingWithAdjustmentLayers = 32,

        WorkingWithFillLayers = 64,

        WorkingWithGroupLayers = 128,

        WorkingWithSmartObjectLayers = 256,

        WorkingWithSmartFilters = 512,

        WorkingWithMasks = 1024,

        WorkingWithLayerEffects = 2048,

        WorkingWithAnimationAndTimeLine = 4096,

        SpecificCases = 8192,

        All = WorkingWithLayerResources | WorkingWithGlobalResources
              | BasicLayersOperations | WorkingWithTextLayers | WorkingWithAdjustmentLayers | WorkingWithFillLayers |
            WorkingWithSmartObjectLayers | WorkingWithSmartFilters | WorkingWithMasks | WorkingWithLayerEffects
              | WorkingWithAnimationAndTimeLine
    }
}