﻿using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface IAboutService 
    {
        Task<About> CreateAbout(About about);
        Task UpdateAbout(About aboutTobeUpdated,About about);
        Task DeleteAbout(About about);
        Task<IEnumerable<About>> GetAbouts();
        Task<About> GetAboutById(int id);
        Task<About> GetUserAboutByUser(AppUser user);
        Task<bool> AddAboutByUser(About about);
        bool checkAbout(AppUser appUser);
        Task<bool> RemoveAboutForUser(About about, AppUser appUser);
        Task<bool> UpdateAboutForUser(About edittingAbout, AppUser appUser);
        Task<IEnumerable<About>> GetUserAboutsByUser(AppUser user);
        Task<IEnumerable<About>> GetAboutWithOutuser();
    }
}
