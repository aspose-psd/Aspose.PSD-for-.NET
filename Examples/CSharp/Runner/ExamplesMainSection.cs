using System;

namespace Aspose.PSD.Examples.Runner
{
    [Flags]
    enum ExamplesMainSection
    {
        OpenSaveBasics = 1,

        ConversionAndExportBasics = 2,

        GraphicOperationsBasics = 4,

        Psd = 8,

        Psb = 16,

        Ai = 32,

        All = OpenSaveBasics | ConversionAndExportBasics | GraphicOperationsBasics | Psd | Psb | Ai
    }
}