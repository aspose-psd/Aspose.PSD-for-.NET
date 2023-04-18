using System;
using Aspose.PSD.FileFormats.Psd.Core.RawColor;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    public class RawColorClass
    {
        public static void Run()
        {
            //ExStart:RawColorClass
            //ExSummary:The following code demonstrates the support of RawColor class instead of obsolete Color struct.

            void AssertAreEqual(object expected, object actual, string message = null)
            {
                if (!object.Equals(expected, actual))
                {
                    throw new Exception(message ?? "Objects are not equal.");
                }
            }

            var color = new RawColor(PixelDataFormat.Rgba32Bpp);
            var oldColor = Color.FromArgb(5, 1, 2, 3);

            var argbValue = oldColor.ToArgb();
            color.SetAsInt(argbValue);

            AssertAreEqual("ARGB", color.GetColorModeName());
            AssertAreEqual(32, color.GetBitDepth());
            AssertAreEqual("A Alpha", color.Components[0].FullName);
            AssertAreEqual(5, (int)color.Components[0].Value);
            AssertAreEqual("R Red", color.Components[1].FullName);
            AssertAreEqual(1, (int)color.Components[1].Value);
            AssertAreEqual("G Green", color.Components[2].FullName);
            AssertAreEqual(2, (int)color.Components[2].Value);
            AssertAreEqual("B Blue", color.Components[3].FullName);
            AssertAreEqual(3, (int)color.Components[3].Value);

            AssertAreEqual(argbValue, color.GetAsInt());


            //ExEnd:RawColorClass

            Console.WriteLine("RawColorClass executed successfully");
        }
    }
}