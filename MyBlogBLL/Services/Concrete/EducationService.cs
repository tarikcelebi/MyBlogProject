using MyBlogBLL.Services.Abstract;
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
    public class EducationService : IEducationService
    {
        private readonly IUnitOfWork unitOfWork;

        public EducationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddingEducationForUser(AppUser user, Education education)
        {
            Education IsExist = await unitOfWork.EducationRepository.SingleorDefault(e => e.Id == education.Id && e.AppUserID == user.Id);
            if (IsExist == null)
            {
                await CreateEducationWithUserAsync(education, user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task AddRangEducationAsync(IEnumerable<Education> educations)
        {
            throw new NotImplementedException();
        }

        public async Task CreateEducationWithUserAsync(Education education, AppUser user)
        {
            Education newEducation = new();
            newEducation.AppUserID = user.Id;
            newEducation.Department = education.Department;
            newEducation.StartedDate = education.StartedDate;
            newEducation.SchoolName = education.SchoolName;
            newEducation.EndedDate = education.EndedDate;
            newEducation.Degree = education.Degree;
            await unitOfWork.EducationRepository.AddAsync(newEducation);
            await unitOfWork.CommitAsync();
        }

        public void DeleteEducation(Education education)
        {
            throw new NotImplementedException();
        }

        public void DeleteRangeEducationAsync(IEnumerable<Education> education)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Education> FindAsync(Expression<Func<Education, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Education>> GetAllEducationAsync()
        {
            return await unitOfWork.EducationRepository.GetAllAsync();
        }

        public async ValueTask<Education> GetEducationByIdASync(int id)
        {
            return await unitOfWork.EducationRepository.GetByIdASync(id);
        }

        public async Task<IEnumerable<Education>> GetUserEducationsForUser(AppUser user)
        {
            return await unitOfWork.EducationRepository.GetWhereListAsync(x => x.AppUserID == user.Id);
        }

        public Task<IEnumerable<Education>> GetWhereListAsync(Expression<Func<Education, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveEducationForUser(Education education, AppUser appUser)
        {
            Education education1 = await unitOfWork.EducationRepository.GetExperienceByIdIncludeUserAsync(education.Id, appUser);
            education1.AppUser.Educations.Remove(education);
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            return false;
        }

        public Task<Education> SingleorDefault(Expression<Func<Education, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEducationForUser(Education educationToBeUpdated, AppUser appUser)
        {
            Education edittedEducation = await unitOfWork.EducationRepository.SingleorDefault(e => e.Id == educationToBeUpdated.Id);

            if (edittedEducation != null)
            {
                edittedEducation.AppUserID = appUser.Id;
                edittedEducation.Degree = educationToBeUpdated.Degree;
                edittedEducation.SchoolName = educationToBeUpdated.SchoolName;
                edittedEducation.StartedDate = educationToBeUpdated.StartedDate;
                edittedEducation.EndedDate = educationToBeUpdated.EndedDate;
                edittedEducation.Clubs = educationToBeUpdated.Clubs;
                edittedEducation.Department = educationToBeUpdated.Department;
                if (await unitOfWork.CommitAsync() > 0)
                    return true;
                return false;
            }
            return false;
        }
    }
}
