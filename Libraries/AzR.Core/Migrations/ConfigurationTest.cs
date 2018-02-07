using System.Data.Entity.Migrations;
using AzR.Core.Models;
using AzR.Core.Repositories;

namespace AzR.Core.Migrations
{
    internal sealed class ConfigurationTest : DbMigrationsConfiguration<TestDbContext>
    {
        public ConfigurationTest()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TestDbContext context)
        {
            context.EmployeeTypes.AddOrUpdate(e => e.Id,
                new EmployeeType { Id = 1, Name = "A" },
                new EmployeeType { Id = 1, Name = "B" },
                new EmployeeType { Id = 1, Name = "C" });
        }
    }
}