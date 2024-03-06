using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Abstract
{
    public interface IAboutRepository : IRepository<About>
    {
        Task<About> GetUserAboutByUser(AppUser user,About About);
        Task<About> GetUserAboutByOnlyUser(AppUser user);
        Task<IEnumerable<About>> GetUserAboutsByUser(AppUser user);


    }
}
