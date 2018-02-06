using AzR.Core.Models;
using AzR.Core.Repositories;

namespace AzR.Core.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Employees.AddOrUpdate(e => e.Id,
                new Employee { Id = 1, Name = "Rajib" },
                new Employee { Id = 1, Name = "Ashiq" },
                new Employee { Id = 1, Name = "Zaman" });
        }
    }
}
