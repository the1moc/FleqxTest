using Fleqx.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Fleqx.Data.DatabaseModels;
using Owin;

[assembly: OwinStartup(typeof(Fleqx.Startup))]

namespace Fleqx
{

	public class Startup
	{
		public static UserManager<User> UserManager { get; private set; }

		public void Configuration(IAppBuilder app)
		{
			app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
			{
				AuthenticationType = "ApplicationCookie",
				LoginPath = new PathString("/Security/Login")
			});

			UserManager = new UserManager<User>(new UserStore<User>(new DatabaseContext()));

			UserManager.UserValidator = new UserValidator<User>(UserManager)
				{
					AllowOnlyAlphanumericUserNames = false
				};
		}
	}
}
