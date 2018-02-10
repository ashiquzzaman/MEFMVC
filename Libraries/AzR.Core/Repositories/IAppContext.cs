using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AzR.Core.Repositories
{
    public interface IAppContext<TContext> : IDisposable where TContext : IAppDbContext
    {
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        dynamic ExecuteProcedrue(string sp, object[] paramaters);
        void Migrate<TDbContext, TConfiguration>() where TDbContext : DbContext where TConfiguration : DbMigrationsConfiguration<TDbContext>, new();

        dynamic ExecuteProcedrue(string sp);
    }
}
