using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface IGenericService<T> where T : class
    {

        ValueTask<T> GetByIdASync(int id);
        Task AddAsync(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        IEnumerable<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> SingleorDefault(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetWhereListAsync(Expression<Func<T, bool>> expression);
    }
}
