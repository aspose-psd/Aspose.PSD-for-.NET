using System;

namespace Aspose.PSD.Examples.Runner
{
    [Flags]
    enum ExamplesMainSection
    {
        OpenSaveCreateBasics = 1,

        ConversionAndExportBasics = 2,

        GraphicOperationsBasics = 4,

        Psd = 8,

        Psb = 16,

        Ai = 32,

        CommonAdvancedFeatures = 64,

        All = OpenSaveCreateBasics | ConversionAndExportBasics | GraphicOperationsBasics | Psd | Psb | Ai | CommonAdvancedFeatures
    }
}