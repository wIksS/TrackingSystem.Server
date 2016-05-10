namespace TrackingSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrackingSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrackingSystem.Data.TrackingSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TrackingSystem.Data.TrackingSystemDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleAdmin = new IdentityRole
                {
                    Name = "Admin"
                };

                manager.Create(roleAdmin);
            }


            if (!context.Roles.Any(r => r.Name == "Teacher"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleTeacher = new IdentityRole
                {
                    Name = "Teacher"
                };

                manager.Create(roleTeacher);
            }

            if (!context.Users.Any(u => u.UserName == "Admin@g.c"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new Teacher
                {
                    UserName = "Admin@g.c",
                    Email = "Admin@g.c"
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
