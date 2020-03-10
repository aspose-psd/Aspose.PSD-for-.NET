using Aspose.PSD.ImageOptions;
using Aspose.PSD.Multithreading;
using System;
using System.IO;
using System.Threading;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class SupportForInterruptMonitor
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir_PNG();

            //ExStart:SupportForInterruptMonitor

            ImageOptionsBase saveOptions = new PngOptions();
            InterruptMonitor monitor = new InterruptMonitor();
            string source = Path.Combine(dataDir, "big2.psb");
            string output = Path.Combine(dataDir, "big_out.png");
            SaveImageWorker worker = new SaveImageWorker(source, output, saveOptions, monitor);

            Thread thread = new Thread(new ThreadStart(worker.ThreadProc));

            try
            {
                thread.Start();

                // The timeout should be less than the time required for full image conversion (without interruption).
                Thread.Sleep(3000);

                // Interrupt the process
                monitor.Interrupt();
                Console.WriteLine("Interrupting the save thread #{0} at {1}", thread.ManagedThreadId, System.DateTime.Now);

                // Wait for interruption...
                thread.Join();
            }
            finally
            {
                // Delete the output file.
                if (File.Exists(output))
                {
                    File.Delete(output);
                }
            }

            //ExEnd:SupportForInterruptMonitor
        }


    }


}
