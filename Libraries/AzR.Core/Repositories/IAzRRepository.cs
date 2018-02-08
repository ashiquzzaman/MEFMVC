using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzR.Core.Repositories
{
    public interface IAzRRepository<TContext, TEntity> : IDisposable
        where TEntity : class where TContext : IAppDbContext
    {
        #region LINQ QUERY

        /// <summary>
        /// Count all item in a DB table.
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Count all item in a DB table.
        /// </summary>
        long LongCount { get; }

        /// <summary>
        /// add a item in a table. item never be added untill call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be added into corresponding DB table.</param>
        void Add(TEntity item);

        /// <summary>
        /// Remove a item in a table. item never be Removed untill call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be Removed into corresponding DB table.</param>
        void Remove(TEntity item);

        /// <summary>
        /// Modify a item in a table. item never be Modified untill call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be Modified into corresponding DB table.</param>
        void Modify(TEntity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> All();
        int CountFunc(Expression<Func<TEntity, bool>> predicate);
        long LongCountFunc(Expression<Func<TEntity, bool>> predicate);
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        string Max(Expression<Func<TEntity, string>> predicate);
        string MaxFunc(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        TEntity Create(TEntity item);
        int Update(TEntity item);
        int Update(Expression<Func<TEntity, bool>> predicate);
        int Delete(TEntity item);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        string Min(Expression<Func<TEntity, string>> predicate);
        string MinFunc(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where);

        #endregion

        #region LINQ ASYNC

        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity item);
        Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(TEntity t);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();
        Task<long> LongCountAsync();
        Task<int> CountFuncAsync(Expression<Func<TEntity, bool>> predicate);
        Task<long> LongCountFuncAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<string> MaxAsync(Expression<Func<TEntity, string>> predicate);
        Task<string> MaxFuncAsync(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where);
        Task<string> MinAsync(Expression<Func<TEntity, string>> predicate);
        Task<string> MinFuncAsync(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChangesAsync();
        #endregion
    }
}