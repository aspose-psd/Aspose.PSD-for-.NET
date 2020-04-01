using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;
using System.IO;

namespace Aspose.PSD.Examples.Aspose.ModifyingAndConvertingImages.PSD
{
    class ControllCacheReallocation
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_PSD();

            //ExStart:ControllCacheReallocation

            // By default the cache folder is set to the local temp directory.  You can specify a different cache folder from the default this way:
            Cache.CacheFolder = dataDir;

            // Set cache on disk.
            Cache.CacheType = CacheType.CacheOnDiskOnly;

            // The default cache max value is 0, which means that there is no upper limit
            Cache.MaxDiskSpaceForCache = 1073741824; // 1 gigabyte
            Cache.MaxMemoryForCache = 1073741824; // 1 gigabyte

            // We do not recommend that you change the following property because it may greatly affect performance
            Cache.ExactReallocateOnly = false;

            // At any time you can check how many bytes are currently allocated for the cache in memory or on disk By examining the following properties
            long l1 = Cache.AllocatedDiskBytesCount;
            long l2 = Cache.AllocatedMemoryBytesCount;

            PsdOptions options = new PsdOptions();

            //GifOptions options = new GifOptions();
            options.Palette = new ColorPalette(new[] { Color.Red, Color.Blue, Color.Black, Color.White });
            options.Source = new StreamSource(new MemoryStream(), true);

            using (RasterImage image = (RasterImage)Image.Create(options, 100, 100))
            {
                Color[] pixels = new Color[10000];
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = Color.White;
                }

                image.SavePixels(image.Bounds, pixels);

                // After executing the code above 40000 bytes are allocated to disk.
                long diskBytes = Cache.AllocatedDiskBytesCount;
                long memoryBytes = Cache.AllocatedMemoryBytesCount;
            }

            // The allocation properties may be used to check whether all Aspose.Imaging objects were properly disposed. If you've forgotten to call dispose on an object the cache values will not be 0.
            l1 = Cache.AllocatedDiskBytesCount;
            l2 = Cache.AllocatedMemoryBytesCount;

            //ExEnd:ControllCacheReallocation
        }
    }
}
