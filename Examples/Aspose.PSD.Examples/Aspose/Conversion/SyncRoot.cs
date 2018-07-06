using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.ImageFilters.FilterOptions;
using Aspose.PSD.ImageOptions;

namespace Aspose.PSD.Examples.Aspose.Conversion
{
    class SyncRoot
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:SyncRoot
            
            // Create an instance of Memory stream class.
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                // Create an instance of Stream container class and assign memory stream object.
                using (StreamContainer streamContainer = new StreamContainer(memoryStream))
                {
                    // check if the access to the stream source is synchronized.
                    lock (streamContainer.SyncRoot)
                    {
                        // do work
                        // now access to source MemoryStream is synchronized
                    }
                }
            }

            //ExEnd:SyncRoot

        }
    }
}
