using AzR.Core.Models;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace AzR.Core.Repositories
{
    [Export(typeof(ApplicationDbContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ApplicationDbContext : DbContext, IAppDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
