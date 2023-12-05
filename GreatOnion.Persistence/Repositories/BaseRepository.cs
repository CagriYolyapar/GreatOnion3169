using GreatOnion.Domain.Entities.Abstracts;
using GreatOnion.Domain.Entities.Interfaces;
using GreatOnion.Domain.Repositories;
using GreatOnion.Persistence.ContextClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<T> _dbSet;

        protected async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await SaveAsync();

        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _dbSet.AddRangeAsync(list);
            await SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbSet.AnyAsync(exp);
        }

        public async Task DeleteAsync(T item)
        {
            T itemToBePassive = await FindAsync(item.ID);
            _dbSet.Entry(itemToBePassive).CurrentValues.SetValues(item);
            await SaveAsync();
        }

        //BL tarafında yapıldığı icin buradaki sistemden ayrıştırılıp sistem sadeleştirilmesi mümkün olsa da ayrı bir BL sorumlulugu burada olabileceginden dolayı ayrı bir metot şeklinde tutulması sağlıklı olacaktır...
        public async Task DeleteRangeAsync(List<T> list)
        {
            foreach (T item in list)
            {
                await DeleteAsync(item);
            }
        }

        public async Task DestroyAsync(T item)
        {
            _dbSet.Remove(item);
            await SaveAsync();
        }

        public async Task DestroyRangeAsync(List<T> list)
        {
            _dbSet.RemoveRange(list);
            await SaveAsync();
        }

        public async Task<T> FindAsync(params object[] values)
        {
            return await FindAsync(values);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbSet.FirstOrDefaultAsync(exp);
        }

        public async Task<List<T>> GetActivesAsync()
        {
            return await WhereAsync(x => x.Status != Domain.Enums.DataStatus.Deleted);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetModifiedsAsync()
        {
            return await WhereAsync(x => x.Status == Domain.Enums.DataStatus.Updated);
        }

        public async Task<List<T>> GetPassivesAsync()
        {
            return await WhereAsync(x => x.Status == Domain.Enums.DataStatus.Deleted);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return  _dbSet.Select(exp);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _dbSet.Select(exp).ToList();
        }

        public async Task UpdateAsync(T item)
        {

           
            T unmodifiedEntity = await FindAsync(item.ID);
            _dbSet.Entry(unmodifiedEntity).CurrentValues.SetValues(item);
            await SaveAsync();
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            foreach (T item in list)
            {
                await UpdateAsync(item);
            }
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _dbSet.Where(exp).ToListAsync();
        }

        public  IQueryable<T> GetAllAsIQueryableAsync()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> GetActivesAsIQueryableAsync()
        {
            return _dbSet.Where(x => x.Status != Domain.Enums.DataStatus.Deleted);
        }

        public IQueryable<T> GetPassivesAsIQueryableAsync()
        {
            return _dbSet.Where(x => x.Status == Domain.Enums.DataStatus.Deleted);
        }

        public IQueryable<T> GetModifiedsAsIQueryableAsync()
        {
            return _dbSet.Where(x => x.Status == Domain.Enums.DataStatus.Updated);
        }
    }
}
