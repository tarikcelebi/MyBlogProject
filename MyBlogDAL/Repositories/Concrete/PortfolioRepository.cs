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
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        private readonly MyBlogDbContext Context;

        public PortfolioRepository(MyBlogDbContext Context) : base(Context)
        {
            this.Context = Context;
        }

        public async Task<Portfolio> GetPortfolioByIdIncludeUserAsync(int id, AppUser appUser)
        {
            return await Context.Portfolios.Include(u => u.AppUser)
                .FirstOrDefaultAsync(p => p.Id == id && p.AppUserID == appUser.Id);
        }

        public async Task<IEnumerable<Portfolio>> GetUserPortfoliosByUser(AppUser user)
        {
            return await Context.Portfolios
                .Where(p => p.AppUserID == user.Id)
                .ToListAsync();
        }
    }
}
