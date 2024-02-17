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

        public async Task UpdateAbout(About aboutTobeUpdated, About about)
        {
            aboutTobeUpdated.Name = about.Name;
            aboutTobeUpdated.Id = about.Id;
            await unitOfWork.CommitAsync();
        }
    }
}
