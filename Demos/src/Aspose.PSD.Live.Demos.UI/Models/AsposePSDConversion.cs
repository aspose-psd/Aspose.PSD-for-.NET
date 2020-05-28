using System.Threading.Tasks;
using Aspose.PSD;
using Aspose.PSD.ImageOptions;
using System.IO;
using System.Diagnostics;

namespace Aspose.PSD.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposePSDConversion class to convert psd file to other format
	///</Summary>
	public class AsposePSDConversion : PSDBase
    {        
		private Response ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip,  bool checkNumberofPages, ActionDelegate action)
		{
			License.SetAsposePSDLicense();
			return  Process(this.GetType().Name, fileName, folderName, outFileExtension, createZip, checkNumberofPages, (new StackTrace()).GetFrame(5).GetMethod().Name,  action);
		}
		///<Summary>
		/// ConvertPSDToTiff method to convert psd to tiff
		///</Summary>
		public Response ConvertPSDToTiff(string fileName, string folderName, string outputType)
        {
			
			TiffOptions tiffOptions = new TiffOptions(Aspose.PSD.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

			return  ProcessTask(fileName, folderName, ".tiff", false,  false, delegate (string inFilePath, string outPath, string zipOutFolder)
            {
                using (Image image = Image.Load(inFilePath))
                {
                    image.Save(outPath, tiffOptions);
                }
            });                        
        }
		///<Summary>
		/// ConvertPSDToImageFiles method to convert psd to image
		///</Summary>
		public Response ConvertPSDToImageFiles(string fileName, string folderName, string outputType)
        {
			if (outputType.Equals("bmp") || outputType.Equals("jpg") || outputType.Equals("png"))
			{
				ImageOptionsBase optionsBase = new BmpOptions();

				if (outputType.Equals("jpg"))
				{
					optionsBase = new JpegOptions();
				}
				else if (outputType.Equals("png"))
				{
					optionsBase = new PngOptions();
				}
				else if (outputType.Equals("gif"))
				{
					optionsBase = new GifOptions();
				}
				

				return  ProcessTask(fileName, folderName, "." + outputType, true,  false, delegate (string inFilePath, string outPath, string zipOutFolder)
				{
					string fileExtension = Path.GetExtension(inFilePath).ToLower();
					
					using (Image image = Image.Load(inFilePath))
					{
						image.Save(outPath, optionsBase);
					}					
                });
            }

            return  new Response
            {
                FileName = null,
                Status = "Output type not found",
                StatusCode = 500
            };
        }
		///<Summary>
		/// ConvertFile
		///</Summary>
		public Response ConvertFile(string fileName, string folderName, string outputType)
        {
            outputType = outputType.ToLower();

           if (outputType.Equals("bmp") || outputType.Equals("jpg") || outputType.Equals("png"))
            {
                return  ConvertPSDToImageFiles(fileName, folderName, outputType);
            }
            else if (outputType.Equals("tiff"))
            {
                return  ConvertPSDToTiff(fileName, folderName, outputType);
            }

            return new Response
            {
                FileName = null,
                Status = "Output type not found",
                StatusCode = 500
            };
        }        
    }
}
