using AzR.Core.Models;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace AzR.Core.Repositories
{
    [Export(typeof(IAppDbContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestDbContext : DbContext, IAppDbContext
    {
        public TestDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<EmployeeType> EmployeeTypes { get; set; }


    }
}
