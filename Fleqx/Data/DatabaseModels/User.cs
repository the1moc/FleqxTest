using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fleqx.Data.DatabaseModels
{
	public class User : IdentityUser
	{
		// First name of the user.
		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		// Second name of the user.
		[DataType(DataType.Text)]
		public string LastName { get; set; }

		// The group the user is in.
		public string Group { get; set; }

		public virtual ICollection<Announcement> Announcements { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			return userIdentity;
		}
	}
}