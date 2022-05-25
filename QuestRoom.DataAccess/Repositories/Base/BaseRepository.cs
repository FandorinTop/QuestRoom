using Microsoft.EntityFrameworkCore;
using QuestRoom.DataAccess.Helper;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories.Base;
using QuestRoom.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.DataAccess.Repositories.Base
{
    public class GenericRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);

            if (entityToDelete is not null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<ApiResultViewModel<D>> GetApiResponce<D>(Expression<Func<TEntity, D>> selector, int pageIndex, int pageSize, IEnumerable<SortingRequest> sortingRequests = null, IEnumerable<FilterRequest> filterRequests = null)
        {
            var dataQuery = dbSet.AsQueryable();

            var responce = await ApiResult<D>.CreateAsync(selector, dataQuery, pageIndex, pageSize, sortingRequests, filterRequests);

            return responce;
        }

        public Task<bool> IsExistAny(int id)
        {
            return dbSet.AnyAsync(item => item.Id == id);
        }
    }
}
