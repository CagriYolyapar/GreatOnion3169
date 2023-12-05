using GreatOnion.Application.DTOClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Application.ServiceInterfaces
{
    public interface IManagerService<T> where T : BaseDTO
    {
        //List Commands
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetActivesAsync();
        Task<List<T>> GetPassivesAsync();
        Task<List<T>> GetModifiedsAsync();
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
        Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
        object Select(Expression<Func<T, object>> exp);
    }
}
