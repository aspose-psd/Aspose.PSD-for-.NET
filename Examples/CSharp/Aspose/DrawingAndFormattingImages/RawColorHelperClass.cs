using System;
using Aspose.PSD.FileFormats.Psd.Core.RawColor;

namespace Aspose.PSD.Examples.Aspose.DrawingAndFormattingImages
{
    public class RawColorHelperClass
    {
        public static void Run()
        {
            //ExStart:RawColorHelperClass
            //ExSummary:The following code demonstrates the using of RawColorHelper class for creating RawColor.

            Argb8BitColor();
            Argb8BitColorSimple();
            Argb16BitColor();
            Cmyk8BitColor();
            Cmyk16Bit();

            // Tests RawColorHelper.CreateArgb8BitColor without parameters and component names
            void Argb8BitColor()
            {
                var color = RawColorHelper.CreateArgb8BitColor(0, 0, 0, 0);

                if (color.GetBitDepth() != 32)
                    throw new Exception($"BitDepth mismatch. Expected: 32, Actual: {color.GetBitDepth()}");

                if (color.GetColorModeName() != "ARGB")
                    throw new Exception($"ColorModeName mismatch. Expected: ARGB, Actual: {color.GetColorModeName()}");

                if (color.Components.Length != 4)
                    throw new Exception($"Components length mismatch. Expected: 4, Actual: {color.Components.Length}");

                string[] expectedNames = { "A Alpha", "R Red", "G Green", "B Blue" };
                for (int i = 0; i < 4; i++)
                {
                    if (color.Components[i].FullName != expectedNames[i])
                        throw new Exception($"Component[{i}] FullName mismatch. Expected: {expectedNames[i]}, Actual: {color.Components[i].FullName}");

                    if ((int)color.Components[i].Value != 0)
                        throw new Exception($"Component[{i}] Value mismatch. Expected: 0, Actual: {(int)color.Components[i].Value}");
                }
            }

            // Tests RawColorHelper.CreateArgb8BitColor with System.Drawing.Color parameter
            void Argb8BitColorSimple()
            {
                var sysColor = Color.FromArgb(15, 25, 35, 45);
                var color = RawColorHelper.CreateArgb8BitColor(sysColor);

                if (color.GetBitDepth() != 32)
                    throw new Exception($"BitDepth mismatch. Expected: 32, Actual: {color.GetBitDepth()}");

                if (color.GetColorModeName() != "ARGB")
                    throw new Exception($"ColorModeName mismatch. Expected: ARGB, Actual: {color.GetColorModeName()}");

                if (color.GetAsInt() != sysColor.ToArgb())
                    throw new Exception($"GetAsInt mismatch. Expected: {sysColor.ToArgb()}, Actual: {color.GetAsInt()}");
            }

            // Tests RawColorHelper.CreateArgb16BitColor
            void Argb16BitColor()
            {
                var color = RawColorHelper.CreateArgb16BitColor(1000, 2000, 3000, 4000);

                if (color.GetBitDepth() != 64)
                    throw new Exception($"BitDepth mismatch. Expected: 64, Actual: {color.GetBitDepth()}");

                if (color.GetColorModeName() != "ARGB")
                    throw new Exception($"ColorModeName mismatch. Expected: ARGB, Actual: {color.GetColorModeName()}");

                if (color.Components.Length != 4)
                    throw new Exception($"Components length mismatch. Expected: 4, Actual: {color.Components.Length}");

                if (color.Components[0].FullName != "A Alpha")
                    throw new Exception($"Component[0] FullName mismatch. Expected: A Alpha, Actual: {color.Components[0].FullName}");

                if ((int)color.Components[0].Value != 1000)
                    throw new Exception($"Component[0] Value mismatch. Expected: 1000, Actual: {(int)color.Components[0].Value}");

                if (color.Components[1].FullName != "R Red")
                    throw new Exception($"Component[1] FullName mismatch. Expected: R Red, Actual: {color.Components[1].FullName}");

                if ((int)color.Components[1].Value != 2000)
                    throw new Exception($"Component[1] Value mismatch. Expected: 2000, Actual: {(int)color.Components[1].Value}");

                if (color.Components[2].FullName != "G Green")
                    throw new Exception($"Component[2] FullName mismatch. Expected: G Green, Actual: {color.Components[2].FullName}");

                if ((int)color.Components[2].Value != 3000)
                    throw new Exception($"Component[2] Value mismatch. Expected: 3000, Actual: {(int)color.Components[2].Value}");

                if (color.Components[3].FullName != "B Blue")
                    throw new Exception($"Component[3] FullName mismatch. Expected: B Blue, Actual: {color.Components[3].FullName}");

                if ((int)color.Components[3].Value != 4000)
                    throw new Exception($"Component[3] Value mismatch. Expected: 4000, Actual: {(int)color.Components[3].Value}");
            }

            // Tests RawColorHelper.CreateCmyk8BitColor
            void Cmyk8BitColor()
            {
                var color = RawColorHelper.CreateCmyk8BitColor(10, 20, 30, 40);

                if (color.GetBitDepth() != 32)
                    throw new Exception($"BitDepth mismatch. Expected: 32, Actual: {color.GetBitDepth()}");

                if (color.GetColorModeName() != "CMYK")
                    throw new Exception($"ColorModeName mismatch. Expected: CMYK, Actual: {color.GetColorModeName()}");

                if (color.Components.Length != 4)
                    throw new Exception($"Components length mismatch. Expected: 4, Actual: {color.Components.Length}");

                if ((int)color.Components[0].Value != 10)
                    throw new Exception($"Component[0] Value mismatch. Expected: 10, Actual: {(int)color.Components[0].Value}");

                if ((int)color.Components[1].Value != 20)
                    throw new Exception($"Component[1] Value mismatch. Expected: 20, Actual: {(int)color.Components[1].Value}");

                if ((int)color.Components[2].Value != 30)
                    throw new Exception($"Component[2] Value mismatch. Expected: 30, Actual: {(int)color.Components[2].Value}");

                if ((int)color.Components[3].Value != 40)
                    throw new Exception($"Component[3] Value mismatch. Expected: 40, Actual: {(int)color.Components[3].Value}");
            }

            // Tests RawColorHelper.CreateCmyk16BitBitColor
            void Cmyk16Bit()
            {
                var color = RawColorHelper.CreateCmyk16BitBitColor(1000, 2000, 3000, 4000);

                if (color.GetBitDepth() != 64)
                    throw new Exception($"BitDepth mismatch. Expected: 64, Actual: {color.GetBitDepth()}");

                if (color.GetColorModeName() != "CMYK")
                    throw new Exception($"ColorModeName mismatch. Expected: CMYK, Actual: {color.GetColorModeName()}");

                if (color.Components.Length != 4)
                    throw new Exception($"Components length mismatch. Expected: 4, Actual: {color.Components.Length}");

                if ((int)color.Components[0].Value != 1000)
                    throw new Exception($"Component[0] Value mismatch. Expected: 1000, Actual: {(int)color.Components[0].Value}");

                if ((int)color.Components[1].Value != 2000)
                    throw new Exception($"Component[1] Value mismatch. Expected: 2000, Actual: {(int)color.Components[1].Value}");

                if ((int)color.Components[2].Value != 3000)
                    throw new Exception($"Component[2] Value mismatch. Expected: 3000, Actual: {(int)color.Components[2].Value}");

                if ((int)color.Components[3].Value != 4000)
                    throw new Exception($"Component[3] Value mismatch. Expected: 4000, Actual: {(int)color.Components[3].Value}");
            }

            //ExEnd:RawColorHelperClass

            Console.WriteLine("RawColorHelperClass executed successfully");
        }
    }
}