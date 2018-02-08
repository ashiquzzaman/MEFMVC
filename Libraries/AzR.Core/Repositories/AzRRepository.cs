using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzR.Core.Repositories
{
    [Export(typeof(IAzRRepository<,>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AzRRepository<TContext, TEntity> : IAzRRepository<TContext, TEntity>
        where TEntity : class where TContext : IAppDbContext
    {
        #region Members

        private TContext _context;


        private bool _disposed;

        #endregion

        [ImportingConstructor]
        public AzRRepository(TContext context)
        {
            _context = context;
        }




        #region PROPERTY

        // Entity corresponding Database Table
        private DbSet<TEntity> DbSet
        {
            get { return _context.Set<TEntity>(); }
        }

        #endregion

        #region LINQ QUERY

        /// <summary>
        /// add a item in a table. item never be added until call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be added into corresponding DB table.</param>
        public virtual void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            DbSet.Add(item); // add new item in this set
        }

        /// <summary>
        /// Remove a item in a table. item never be Removed until call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be Removed into corresponding DB table.</param>
        public virtual void Remove(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            DbSet.Remove(item); //set as "removed"

        }

        /// <summary>
        /// Modify a item in a table. item never be Modified until call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be Modified into corresponding DB table.</param>
        public virtual void Modify(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            var entry = _context.Entry(item);
            DbSet.Attach(item);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> All()
        {
            return DbSet.AsNoTracking().AsQueryable();
        }

        public TEntity Create(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            DbSet.Add(item);
            _context.SaveChanges();
            return item;
        }

        public int Update(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            var entry = _context.Entry(item);
            DbSet.Attach(item);
            entry.State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Update(Expression<Func<TEntity, bool>> predicate)
        {
            var records = FindAll(predicate);
            if (!records.Any())
            {
                throw new ObjectNotFoundException();
            }
            foreach (var record in records)
            {
                var entry = _context.Entry(record);

                DbSet.Attach(record);

                entry.State = EntityState.Modified;
            }
            return _context.SaveChanges();
        }

        public int Delete(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            DbSet.Remove(item);

            return _context.SaveChanges();
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var records = FindAll(predicate);
            if (!records.Any())
            {
                throw new ObjectNotFoundException();
            }
            foreach (var record in records)
            {
                DbSet.Remove(record);
            }
            return _context.SaveChanges();
        }

        /// <summary>
        /// Count all item in a DB table.
        /// </summary>
        public int Count
        {
            get { return DbSet.Count(); }
        }

        public long LongCount
        {
            get { return DbSet.LongCount(); }
        }

        public int CountFunc(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public long LongCountFunc(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.LongCount(predicate);
        }

        public bool IsExist(Expression<Func<TEntity, bool>> predicate)
        {
            var count = DbSet.Count(predicate);
            return count > 0;
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.First(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().SingleOrDefault(predicate);
        }

        public string Max(Expression<Func<TEntity, string>> predicate)
        {
            return DbSet.Max(predicate);
        }

        public string MaxFunc(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).Max(predicate);
        }

        public string Min(Expression<Func<TEntity, string>> predicate)
        {
            return DbSet.Min(predicate);
        }

        public string MinFunc(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).Min(predicate);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking().AsQueryable();
        }

        #endregion

        #region IDisposable Members

        ~AzRRepository()
        {
            Dispose(false);
        }

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        //  _context = null;
                    }
                }
            }
            _disposed = true;
        }


        #endregion

        #region LINQ ASYNC

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            var entry = _context.Entry(item);
            DbSet.Attach(item);
            entry.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var records = await DbSet.Where(predicate).ToListAsync();
            if (!records.Any())
            {
                throw new ObjectNotFoundException();
            }
            foreach (var record in records)
            {
                var entry = _context.Entry(record);

                DbSet.Attach(record);

                entry.State = EntityState.Modified;
            }
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TEntity t)
        {
            DbSet.Remove(t);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var records = await DbSet.Where(predicate).ToListAsync();
            if (!records.Any())
            {
                throw new ObjectNotFoundException();
            }
            foreach (var record in records)
            {
                DbSet.Remove(record);
            }
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<long> LongCountAsync()
        {
            return await DbSet.LongCountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> CountFuncAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.CountAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<long> LongCountFuncAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.LongCountAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<string> MaxAsync(Expression<Func<TEntity, string>> predicate)
        {
            return await DbSet.MaxAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<string> MaxFuncAsync(Expression<Func<TEntity, string>> predicate,
            Expression<Func<TEntity, bool>> where)
        {
            return await DbSet.Where(where).MaxAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<string> MinAsync(Expression<Func<TEntity, string>> predicate)
        {
            return await DbSet.MinAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<string> MinFuncAsync(Expression<Func<TEntity, string>> predicate,
            Expression<Func<TEntity, bool>> where)
        {
            return await DbSet.Where(where).MinAsync(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var count = await DbSet.CountAsync(predicate);
            return count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}