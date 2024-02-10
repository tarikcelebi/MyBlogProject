using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogDAL.Context;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        
        protected readonly DbContext Context;

        public GenericRepository(DbContext Context)
        {
            this.Context = Context;
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public ValueTask<T> GetByIdASync(int id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetWhereListAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> SingleorDefault(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().SingleOrDefaultAsync(expression);
        }
    }
}
