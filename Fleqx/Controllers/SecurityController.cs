using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Fleqx.Data.DatabaseModels;
using Fleqx.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Fleqx.Controllers
{
	[AllowAnonymous]
	public class SecurityController : Controller
	{
		private readonly UserManager<User> userManager;

		public SecurityController()
			: this(Startup.UserManager)
		{
		}

		public SecurityController(UserManager<User> userManager)
		{
			this.userManager = userManager;
		}

		// When the login screen will be displayed.
		[HttpGet]
		public ActionResult Login(string returnUrl)
		{
			LoginModel model = new LoginModel
			{
				RequestedUrl = returnUrl
			};

			return View("LoginPage", model);
		}

		// A login attempt has been made.
		[HttpPost]
		public async Task<ActionResult> Login(LoginModel loginModel)
		{
			if (!ModelState.IsValid)
			{
				return View("LoginPage");
			}

			var user = await userManager.FindAsync(loginModel.UserName, loginModel.Password);

			if (user != null)
			{
				ClaimsIdentity identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
				
				var context = Request.GetOwinContext();
				context.Authentication.SignIn(identity);

				if (string.IsNullOrEmpty(loginModel.RequestedUrl) || !Url.IsLocalUrl(loginModel.RequestedUrl))
					return Redirect(Url.Action("Home", "Home"));

				ViewBag.Clear();
				return Redirect(loginModel.RequestedUrl);
			}
	
			ViewBag.Error = "Invalid credentials. Try again.";
			return View("LoginPage");
		}

		// A login attempt has been made.
		[HttpPost]
		public async Task<ActionResult> SignUp(SignupModel signupModel)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Error = "Something went wrong during signup";
				return View("Home");
			}

			User user = new User()
			{
				UserName      = signupModel.UserName,
				FirstName     = signupModel.FirstName,
				LastName      = signupModel.LastName,
				SecurityStamp = Guid.NewGuid().ToString()
			};

			userManager.Create(user, signupModel.Password);

			userManager.AddToRole(user.Id, RoleHelper.GetRole(signupModel.Role));
			return View("Home");
		}

		// Logout the user
		[HttpGet]
		public ActionResult Logout()
		{
			IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
			authManager.SignOut();

			return View("LoginPage");
		}
	}
}