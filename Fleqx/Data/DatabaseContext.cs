using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Fleqx.Data.DatabaseModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fleqx.Data
{
	public class DatabaseContext : IdentityDbContext<DatabaseModels.User>
	{
		public DatabaseContext()
			: base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|FleqxDatabase.mdf;Integrated Security=True")
		{
			Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
		}
		
		public DbSet<Announcement> Announcements { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<DatabaseModels.User>().ToTable("Users");
			modelBuilder.Entity<IdentityRole>().ToTable("Roles");
			modelBuilder.Entity<IdentityUserRole>().ToTable("LkUserRoles");

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

		}
	}
}