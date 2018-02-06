using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AzR.Core.Repositories
{
    public interface IAppContext : IDisposable
    {
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        dynamic ExecuteProcedrue(string sp, object[] paramaters);
        void Migrate<TContext, TConfiguration>() where TContext : DbContext where TConfiguration : DbMigrationsConfiguration<TContext>, new();

        dynamic ExecuteProcedrue(string sp);
    }
}
