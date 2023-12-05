using GreatOnion.Domain.Entities.Abstracts;
using GreatOnion.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Domain.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        //List Commands
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAllAsIQueryableAsync();

        Task<List<T>> GetActivesAsync();
        IQueryable<T> GetActivesAsIQueryableAsync();
        Task<List<T>> GetPassivesAsync();

        IQueryable<T> GetPassivesAsIQueryableAsync();

        Task<List<T>> GetModifiedsAsync();
        IQueryable<T> GetModifiedsAsIQueryableAsync();

        Task<T> FindAsync(params object[] values);

        //Modify Commands
        Task AddAsync(T item);
        Task AddRangeAsync(List<T> list);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> list);
        Task DeleteAsync(T item);
        Task DeleteRangeAsync(List<T> list);
        Task DestroyAsync(T item);
        Task DestroyRangeAsync(List<T> list);

        //Linq Commands
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
        object Select(Expression<Func<T, object>> exp);

    }
}
