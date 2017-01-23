using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Fleqx.Helper;

namespace Fleqx.Controllers
{
	public abstract class BaseController : Controller
	{
		// The current user.
		public UserClaims CurrentUser
		{
			get { return new UserClaims(this.User as ClaimsPrincipal); }
		}
		
	}
}