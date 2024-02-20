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

        public SkillRepository(MyBlogDbContext Context) : base(Context)
        {

        }
    }
}
