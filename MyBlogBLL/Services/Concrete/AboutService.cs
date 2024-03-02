using Microsoft.EntityFrameworkCore;
using MyBlogBLL.Services.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork unitOfWork;

        public AboutService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAboutByUser(About about)
        {
            await CreateAbout(about);
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            return false;
        }

        public bool checkAbout(AppUser appUser)
        {
            if (appUser.Abouts.Count == 1)
                return true;
            return false;
        }

        public async Task<About> CreateAbout(About about)
        {
            await unitOfWork.aboutRepository.AddAsync(about);
            await unitOfWork.CommitAsync();
            return about;
        }

        public async Task DeleteAbout(About about)
        {
            unitOfWork.aboutRepository.Delete(about);
            await unitOfWork.CommitAsync();

        }

        public async Task<About> GetAboutById(int id)
        {
            return await unitOfWork.aboutRepository.GetByIdASync(id);
        }

        public async Task<IEnumerable<About>> GetAbouts()
        {
            return await unitOfWork.aboutRepository.GetAllAsync();
        }

        public async Task<About> GetUserAboutByUser(AppUser user)
        {
            return await unitOfWork.aboutRepository.SingleorDefault(a => a.AppUserID == user.Id);
        }

        public async Task<IEnumerable<About>> GetUserAboutsByUser(AppUser user)
        {
            return await unitOfWork.aboutRepository.GetWhereListAsync(x => x.AppUserID == user.Id);
        }

        public async Task<bool> RemoveAboutForUser(About about, AppUser appUser)
        {
            About aboutWithUser = await unitOfWork.aboutRepository.GetUserAboutByUser(appUser, about);
            aboutWithUser.AppUser.Abouts.Remove(about);
            unitOfWork.aboutRepository.Delete(aboutWithUser);
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            return false;
        }


        public async Task UpdateAbout(About aboutTobeUpdated, About about)
        {
            aboutTobeUpdated.Name = about.Name;
            aboutTobeUpdated.Title = about.Title;
            aboutTobeUpdated.Id = about.Id;
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateAboutForUser(About edittingAbout, AppUser appUser)
        {
            About AboutToBeupdated = await unitOfWork.aboutRepository.SingleorDefault(e => e.Id == edittingAbout.Id);

            if (AboutToBeupdated != null)
            {
                AboutToBeupdated.AppUserID = appUser.Id;
                AboutToBeupdated.Age = edittingAbout.Age;
                AboutToBeupdated.Description = edittingAbout.Description;
                AboutToBeupdated.Title = edittingAbout.Title;
                AboutToBeupdated.Phone = edittingAbout.Phone;
                AboutToBeupdated.ImageURL = edittingAbout.ImageURL;
                AboutToBeupdated.Name = edittingAbout.Name;
                if (await unitOfWork.CommitAsync() > 0)
                    return true;
                return false;
            }
            return false;
        }
    }
}
