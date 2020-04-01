using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    //ExStart:InterruptMonitorTest

    class InterruptMonitorTest
    {
        public static void Run()
        {

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSB();
            InterruptMonitor(dataDir, dataDir);
        }

        public static void InterruptMonitor(string dir, string ouputDir)
        {
            ImageOptionsBase saveOptions = new ImageOptions.PngOptions();
            Multithreading.InterruptMonitor monitor = new Multithreading.InterruptMonitor();
            SaveImageWorker worker = new SaveImageWorker(dir + "big.psb", dir + "big_out.png", saveOptions, monitor);
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(worker.ThreadProc));

            try
            {
                thread.Start();

                // The timeout should be less than the time required for full image conversion (without interruption).
                System.Threading.Thread.Sleep(3000);

                // Interrupt the process
                monitor.Interrupt();
                System.Console.WriteLine("Interrupting the save thread #{0} at {1}", thread.ManagedThreadId, System.DateTime.Now);

                // Wait for interruption...
                thread.Join();
            }
            finally
            {
                // If the file to be deleted does not exist, no exception is thrown.
                System.IO.File.Delete(dir + "big_out.png");
            }
        }
    }
    /// <summary>
    /// Initiates image conversion and waits for its interruption.
    /// </summary>
    public class SaveImageWorker
    {
        /// <summary>
        /// The path to the input image.
        /// </summary>
        private readonly string inputPath;

        /// <summary>
        /// The path to the output image.
        /// </summary>
        private readonly string outputPath;

        /// <summary>
        /// The interrupt monitor.
        /// </summary>
        private readonly Multithreading.InterruptMonitor monitor;

        /// <summary>
        /// The save options.
        /// </summary>
        private readonly ImageOptionsBase saveOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveImageWorker" /> class.
        /// </summary>
        /// <param name="inputPath">The path to the input image.</param>
        /// <param name="outputPath">The path to the output image.</param>
        /// <param name="saveOptions">The save options.</param>
        /// <param name="monitor">The interrupt monitor.</param>
        public SaveImageWorker(string inputPath, string outputPath, ImageOptionsBase saveOptions, Multithreading.InterruptMonitor monitor)
        {
            this.inputPath = inputPath;
            this.outputPath = outputPath;
            this.saveOptions = saveOptions;
            this.monitor = monitor;
        }

        /// <summary>
        /// Tries to convert image from one format to another. Handles interruption. 
        /// </summary>
        public void ThreadProc()
        {
            using (Image image = Image.Load(this.inputPath))
            {
                Multithreading.InterruptMonitor.ThreadLocalInstance = this.monitor;

                try
                {
                    image.Save(this.outputPath, this.saveOptions);
                    Assert.Fail("Expected interruption.");
                }
                catch (CoreExceptions.OperationInterruptedException e)
                {
                    System.Console.WriteLine("The save thread #{0} finishes at {1}", System.Threading.Thread.CurrentThread.ManagedThreadId, System.DateTime.Now);
                    System.Console.WriteLine(e);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e);
                }
                finally
                {
                    Multithreading.InterruptMonitor.ThreadLocalInstance = null;
                }
            }
        }
    }



    //ExEnd:InterruptMonitorTest
}
