using Aspose.PSD.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.PSD.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Create, Edit or Convert PSD &amp; PSB files to PDF &amp; image formats";
			ViewBag.MetaDescription = "Free Apps to edit Photoshop files. Ability to update layer properties, add watermarks, rotate, scale, Flip, Crop, Dithering, Raster Conversion.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
