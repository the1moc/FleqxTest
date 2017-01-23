using System;
using System.Collections.Generic;
using System.Data.Entity;
using Fleqx.Data.DatabaseModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fleqx.Data
{
	public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{
			PasswordHasher pHasher = new PasswordHasher();
			string hashedPassword  = pHasher.HashPassword("password");
			context.Users.Add(new DatabaseModels.User
			{
				Id            = "1",
				UserName      = "admin",
				FirstName     = "Admin",
				LastName      = "Admin",
				PasswordHash  = hashedPassword,
				SecurityStamp = Guid.NewGuid().ToString()
			});

			context.SaveChanges();

			List<IdentityRole> roles = new List<IdentityRole>
			{
				new IdentityRole {Id="1", Name="Admin"},
				new IdentityRole {Id="2", Name="Standard"},
				new IdentityRole {Id="3", Name="Guest"}
			};

			roles.ForEach(role => context.Roles.Add(role));
			context.SaveChanges();

			List<Announcement> announcements = new List<Announcement>
			{
				new Announcement {AnnouncementID=1, User=context.Users.Find("1"), AnnouncementTitle="Welcome", AnnouncementContent="First Announcement!", AnnouncementImportance=5}
			};

			announcements.ForEach(announcement => context.Announcements.Add(announcement));
			context.SaveChanges();

			Startup.UserManager.AddToRole(context.Users.Find("1").Id, "Admin");
		}
	}
}