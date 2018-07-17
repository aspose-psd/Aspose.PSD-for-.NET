using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.PSD.CoreExceptions;
using Aspose.PSD.Multithreading;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    //ExStart:SaveImageWorker
    class SaveImageWorker
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
        private readonly InterruptMonitor monitor;

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
        public SaveImageWorker(string inputPath, string outputPath, ImageOptionsBase saveOptions, InterruptMonitor monitor)
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
                InterruptMonitor.ThreadLocalInstance = this.monitor;

                try
                {
                    image.Save(this.outputPath, this.saveOptions);
                }
                catch (OperationInterruptedException e)
                {
                    Console.WriteLine("The save thread #{0} finishes at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    InterruptMonitor.ThreadLocalInstance = null;
                }
            }
        }
    }
    //ExEnd:SaveImageWorker
}
