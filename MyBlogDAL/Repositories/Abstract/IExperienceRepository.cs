using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Abstract
{
    public interface IExperienceRepository : IRepository<Experience>
    {
        Task<Experience> GetExperienceByIdIncludeUserAsync(int id, AppUser appUser);
    }
}
