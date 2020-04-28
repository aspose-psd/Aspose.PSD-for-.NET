using System;

namespace Aspose.PSD.Examples.Runner
{

    [Flags]
    enum ExamplesSubSectionPsd
    {
        WorkingWithLayerResources = 1,

        WorkingWithGlobalResources = 2,

        WorkingWithRegularLayers = 4,

        WorkingWithTextLayers = 8,

        WorkingWithAdjustmentLayers = 16,

        WorkingWithFillLayers = 32,

        WorkingWithSmartObjectLayers = 64,

        WorkingWithSmartFiltersLayers = 128,

        WorkingWithMasks = 256,

        WorkingWithLayerEffects = 512,

        All = WorkingWithLayerResources | WorkingWithGlobalResources
              | WorkingWithRegularLayers | WorkingWithTextLayers | WorkingWithAdjustmentLayers | WorkingWithFillLayers |
            WorkingWithSmartObjectLayers | WorkingWithSmartFiltersLayers | WorkingWithMasks | WorkingWithLayerEffects
    }
}