using MyBlogBLL.Services.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDAL.UnitOfWork.Concrete;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class ExperienceService: IExperienceService
    {
        private readonly IUnitOfWork unitOfWork;

        public ExperienceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task AddExperienceAsync(Experience experience)
        {
            throw new NotImplementedException();
        }

        public Task AddRangExperienceAsync(IEnumerable<Experience> experiences)
        {
            throw new NotImplementedException();
        }

        public void DeleteExperience(Experience experience)
        {
            throw new NotImplementedException();
        }

        public void DeleteRangeExperienceAsync(IEnumerable<Experience> experiences)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Experience> FindAsync(Expression<Func<Experience, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Experience>> GetAllExperienceAsync()
        {
            return await unitOfWork.experienceRepository.GetAllAsync();
        }

        public ValueTask<Experience> GetExperienceByIdASync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Experience>> GetWhereListAsync(Expression<Func<Experience, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Experience> SingleorDefault(Expression<Func<Experience, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
