﻿using AzR.Core.Models;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace AzR.Core.Repositories
{
    [Export(typeof(IAppContext))]
    // [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ApplicationDbContext : DbContext, IAppContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
