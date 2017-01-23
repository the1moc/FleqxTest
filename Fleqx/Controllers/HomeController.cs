using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Fleqx.Models;

namespace Fleqx.Controllers
{
	
	public class HomeController : BaseController
	{
		public ActionResult Home()
		{
			ViewBag.Name = CurrentUser.Name;
			return View();
		}
	}
}