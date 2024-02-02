using Microsoft.AspNetCore.Identity;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> user;

        public UserService(UserManager<AppUser> user)
        {
            this.user = user;
        }

    }
}
