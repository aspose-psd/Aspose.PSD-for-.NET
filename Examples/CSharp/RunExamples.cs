using System;
using Aspose.PSD.Examples.Runner;

namespace Aspose.PSD.Examples
{
    partial class RunExamples
    {
        static void Main(string[] args)
        {
            // You have to specify License Firstly. Some tests will not work without License
            //String licPath =  @"Aspose.PSD.NET.lic";
            //License lic = new License();
            //lic.SetLicense(licPath);

            // You can use Metered License Also            
            //MeteredLicensing.Run();

            // Running tester of Aspose.PSD features           
            var mainSection = ExamplesRunner.RequestForSections();
            var subSection = ExamplesRunner.RequestForSubSection(mainSection);

            // Selected sections will be run
            ExamplesRunner.RunExamples(mainSection, subSection);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}