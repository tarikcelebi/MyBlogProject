using MyBlogDAL.Context;
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
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyBlogDbContext dbContext;

        public GenericRepository(MyBlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;

        }

        public bool Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetWhereList(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);
        }

        public bool Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            if (dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
