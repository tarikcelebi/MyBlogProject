using Microsoft.EntityFrameworkCore;
using MyBlogDAL.Context;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Concrete
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        private readonly MyBlogDbContext Context;

        public AboutRepository(MyBlogDbContext Context) : base(Context)
        {
            this.Context=Context;

        }

        public async Task<IEnumerable<About>> GetUserAboutsByUser(AppUser user)
        {
            return await Context.Abouts.Where(x => x.AppUserID == user.Id).ToListAsync();
        }
    }
}
