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
    public class SubjectService : ISubjectRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(Subject entity)
        {
            _unitOfWork.Subjects.add(entity);
            await _unitOfWork.CommitAsync();

        }

        public async Task AddRangeAsync(IEnumerable<Subject> entities)
        {
            _unitOfWork.Subjects.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
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

        public Task<IEnumerable<Subject>> GetAllSubjectsWithArticles()
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

        public Task<Subject> GetWithArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> SingleorDefault(Expression<Func<Subject, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
