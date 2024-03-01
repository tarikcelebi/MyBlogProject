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

        public async Task CreateExperienceWithUserAsync(Experience experience,AppUser user)
        {
            Experience newExperience = new();
            newExperience.AppUserID = user.Id;
            newExperience.Address = experience.Address;
            newExperience.CompanyName = experience.CompanyName;
            newExperience.Title = experience.Title;
            newExperience.StartDate = experience.StartDate;
            newExperience.EndDate = experience.EndDate;
            newExperience.DescriptionOfRole = experience.DescriptionOfRole;
            await unitOfWork.experienceRepository.AddAsync(newExperience);
            await unitOfWork.CommitAsync();

        }

        public async Task<bool> AddingExperienceForUser(AppUser user, Experience experience)
        {
            Experience IsExist = await unitOfWork.experienceRepository.SingleorDefault(e => e.Id == experience.Id && e.AppUserID == user.Id);
            if (IsExist == null)
            {
                await CreateExperienceWithUserAsync(experience,user);
                return true;
            }
            else
            {
                return false;
            }


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

        public async ValueTask<Experience> GetExperienceByIdASync(int id)
        {
            return await unitOfWork.experienceRepository.GetByIdASync(id);
        }

        public async Task<IEnumerable<Experience>> GetUserExperiencesForUser(AppUser user)
        {
            return await unitOfWork.experienceRepository.GetWhereListAsync(x => x.AppUserID==user.Id);
        }

        public Task<IEnumerable<Experience>> GetWhereListAsync(Expression<Func<Experience, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveExperienceForUser(Experience experience, AppUser appUser)
        {
            Experience experience1 = await unitOfWork.experienceRepository.GetExperienceByIdIncludeUserAsync(experience.Id, appUser);
            experience1.AppUser.Experiences.Remove(experience);
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            return false;


        }

        public Task<Experience> SingleorDefault(Expression<Func<Experience, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateExperienceForUser(Experience experienceToBeUpdated, AppUser appUser)
        {
            Experience edittedExperience = await unitOfWork.experienceRepository.SingleorDefault(e=>e.Id==experienceToBeUpdated.Id);

            if(edittedExperience!=null)
            {
                edittedExperience.AppUserID = appUser.Id;
                edittedExperience.Address = experienceToBeUpdated.Address;
                edittedExperience.CompanyName = experienceToBeUpdated.CompanyName;
                edittedExperience.Title = experienceToBeUpdated.Title;
                edittedExperience.StartDate = experienceToBeUpdated.StartDate;
                edittedExperience.EndDate = experienceToBeUpdated.EndDate;
                edittedExperience.DescriptionOfRole = experienceToBeUpdated.DescriptionOfRole;
                if (await unitOfWork.CommitAsync() > 0)
                    return true;
                return false;
            }
            return false;

        }
    }
}
