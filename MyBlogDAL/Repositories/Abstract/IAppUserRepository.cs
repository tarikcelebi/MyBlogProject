﻿using Microsoft.AspNetCore.Identity;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Abstract
{
    public interface IAppUserRepository : IUserStore<AppUser>
    {

    }
}
