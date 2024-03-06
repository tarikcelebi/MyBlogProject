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
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        private readonly MyBlogDbContext Context;

        public EducationRepository(MyBlogDbContext Context) : base(Context)
        {
            this.Context = Context;
        }

        public async Task<Education> GetExperienceByIdIncludeUserAsync(int id, AppUser appUser)
        {
               return await Context.Educations.Include(u => u.AppUser)
                    .FirstOrDefaultAsync(e => e.Id == id && e.AppUserID == appUser.Id);
            
        }
    }
}
