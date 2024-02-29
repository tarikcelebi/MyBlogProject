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
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly MyBlogDbContext Context;

        public SkillRepository(MyBlogDbContext Context) : base(Context)
        {
            this.Context = Context;
        }


        public async Task<Skill> GetByIdWithIncludesAsync(int id, AppUser appUser)
        {
            return await Context.Skills
                .Include(x => x.AppUsers)
                .FirstOrDefaultAsync(x => x.Id == id && x.AppUsers.Any(user => user.Id == appUser.Id));

        }

    }
}
