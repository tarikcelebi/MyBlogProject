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
    public class ExperienceRepository : GenericRepository<Experience>, IExperienceRepository
    {
        private readonly MyBlogDbContext Context;

        public ExperienceRepository(MyBlogDbContext Context) : base(Context)
        {
            this.Context = Context;
        }

        public async Task<Experience> GetExperienceByIdIncludeUserAsync(int id, AppUser appUser)
        {
            return await Context.Experiences.Include(u => u.AppUser)
                .FirstOrDefaultAsync(e => e.Id == id && e.AppUserID==appUser.Id);


                
        }
    }
}
