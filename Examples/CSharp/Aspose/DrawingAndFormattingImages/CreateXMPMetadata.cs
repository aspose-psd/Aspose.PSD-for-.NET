using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.ImageOptions;
using Aspose.PSD.Sources;
using Aspose.PSD.Xmp;
using Aspose.PSD.Xmp.Schemas.DublinCore;
using Aspose.PSD.Xmp.Schemas.Photoshop;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    class CreateXMPMetadata
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_DrawingAndFormattingImages();

            //ExStart:CreateXMPMetadata

            // Specify the size of image by defining a Rectangle 
            Rectangle rect = new Rectangle(0, 0, 100, 200);

            // Create the brand new image just for sample purposes
            using (var image = new PsdImage(rect.Width, rect.Height))
            {
                // Create an instance of XMP-Header
                XmpHeaderPi xmpHeader = new XmpHeaderPi(Guid.NewGuid().ToString());

                // Create an instance of Xmp-TrailerPi, XMPmeta class to set different attributes
                XmpTrailerPi xmpTrailer = new XmpTrailerPi(true);
                XmpMeta xmpMeta = new XmpMeta();
                xmpMeta.AddAttribute("Author", "Mr Smith");
                xmpMeta.AddAttribute("Description", "The fake metadata value");

                // Create an instance of XmpPacketWrapper that contains all metadata
                XmpPacketWrapper xmpData = new XmpPacketWrapper(xmpHeader, xmpTrailer, xmpMeta);

                // Create an instacne of Photoshop package and set photoshop attributes
                PhotoshopPackage photoshopPackage = new PhotoshopPackage();
                photoshopPackage.SetCity("London");
                photoshopPackage.SetCountry("England");
                photoshopPackage.SetColorMode(ColorMode.Rgb);
                photoshopPackage.SetCreatedDate(DateTime.UtcNow);

                // Add photoshop package into XMP metadata
                xmpData.AddPackage(photoshopPackage);

                // Create an instacne of DublinCore package and set dublinCore attributes
                DublinCorePackage dublinCorePackage = new DublinCorePackage();
                dublinCorePackage.SetAuthor("Mudassir Fayyaz");
                dublinCorePackage.SetTitle("Confessions of a Man Insane Enough to Live With the Beasts");
                dublinCorePackage.AddValue("dc:movie", "Barfly");

                // Add dublinCore Package into XMP metadata
                xmpData.AddPackage(dublinCorePackage);

                using (var ms = new MemoryStream())
                {
                    // Update XMP metadata into image and Save image on the disk or in memory stream
                    image.XmpData = xmpData;
                    image.Save(ms);
                    image.Save(dataDir+"ee.psd");
                    ms.Seek(0, System.IO.SeekOrigin.Begin);

                    // Load the image from memory stream or from disk to read/get the metadata
                    using (var img = (PsdImage)Image.Load(ms))
                    {
                        // Getting the XMP metadata
                        XmpPacketWrapper imgXmpData = img.XmpData;
                        foreach (XmpPackage package in imgXmpData.Packages)
                        {
                            // Use package data ...
                        }
                    }
                }
            }

            //ExEnd:CreateXMPMetadata

        }
    }
}
