using MyBlogDAL.Context;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.Repositories.Concrete;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class SubjectService : GenericService<Subject>, ISubjectRepository
    {
        public Task AddAsync(Subject entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Subject> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Subject entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Subject> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> FindAsync(Expression<Func<Subject, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subject>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Subject> GetByIdASync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subject>> GetWhereListAsync(Expression<Func<Subject, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> SingleorDefault(Expression<Func<Subject, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
