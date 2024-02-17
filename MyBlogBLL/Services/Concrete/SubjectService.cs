using MyBlogBLL.Services.Abstract;
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
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        

        public async Task<bool> CreateSubject(Subject newSubject)
        {
            await unitOfWork.subjectRepository.AddAsync(newSubject);
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            else
                return false;
        }

        public async Task DeleteSubject(Subject subject)
        {
            unitOfWork.subjectRepository.Delete(subject);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsWithArticles()
        {
            return await unitOfWork.subjectRepository.GetAllAsync();
        }

        public async Task<Subject> GetWithArticleById(int id)
        {
            return await unitOfWork.subjectRepository.GetByIdASync(id);
        }

        public Task UpdateSubject(int id, Subject UpdatedSubject)
        {
            throw new NotImplementedException();
        }
    }
}
