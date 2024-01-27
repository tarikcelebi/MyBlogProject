using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Concrete
{
    public class AppUserRepository : UserStore<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {

        }
    }
}
