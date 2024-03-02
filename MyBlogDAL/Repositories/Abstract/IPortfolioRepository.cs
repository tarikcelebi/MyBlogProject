using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Abstract
{
    public interface IPortfolioRepository : IRepository<Portfolio>
    {
        Task<Portfolio> GetPortfolioByIdIncludeUserAsync(int id, AppUser appUser);
        Task<IEnumerable<Portfolio>> GetUserPortfoliosByUser(AppUser user);
    }
}
