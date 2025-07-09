using System;
using System.IO;

namespace Aspose.PSD.Examples
{
    partial class RunExamples
    {
        public static String GetDataDir_Export(string path)
        {
            return Path.GetFullPath(GetDataDir_Data() + "Export/" + path + "/");
        }

        public static String GetDataDir_Files()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Files/");
        }

        public static String GetDataDir_Images(string path)
        {
            return Path.GetFullPath(GetDataDir_Data() + "Images/" + path + "/");
        }

        public static String GetDataDir_PNG()
        {
            return Path.GetFullPath(GetDataDir_Data() + "PNG/");
        }

        public static String GetDataDir_DrawingAndFormattingImages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "DrawingAndFormattingImages/");
        }

        public static String GetDataDir_DICOM()
        {
            return Path.GetFullPath(GetDataDir_Data() + "DICOM/");
        }

        public static String GetDataDir_JPEG()
        {
            return Path.GetFullPath(GetDataDir_Data() + "JPEG/");
        }

        public static String GetDataDir_ModifyingAndConvertingImages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ModifyingAndConvertingImages/");
        }

        public static String GetDataDir_Cache()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Cache/");
        }

        public static String GetDataDir_MetaFiles()
        {
            return Path.GetFullPath(GetDataDir_Data() + "MetaFiles/");
        }

        public static String GetDataDir_PSD()
        {
            return Path.GetFullPath(GetDataDir_Data() + "PSD/");
        }
        public static String GetDataDir_PSB()
        {
            return Path.GetFullPath(GetDataDir_Data() + "PSB/");
        }

        public static String GetDataDir_WebPImages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WebPImage/");
        }

        public static String GetDataDir_DjVu()
        {
            return Path.GetFullPath(GetDataDir_Data() + "DjVu/");
        }

        public static String GetDataDir_AI()
        {
            return Path.GetFullPath(GetDataDir_Data() + "AI/");
        }
        public static String GetDataDir_Opening()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Opening/");
        }
        public static String GetDataDir_Output()
        {
            return Path.GetFullPath(GetDataDir_Data() + "1_Output/");
        }

        public static string GetDataDir_Data()
        {
            string currDir = Directory.GetCurrentDirectory();
            string parentDir = currDir;

            int binDirIndex = currDir.LastIndexOf(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar);
            if (binDirIndex >= 0)
            {
                parentDir = currDir.Substring(0, binDirIndex);
            }

            string startDirectory = Directory.GetParent(parentDir).FullName;

            return System.IO.Path.Combine(startDirectory, "Data" + Path.DirectorySeparatorChar);
        }
    }
}