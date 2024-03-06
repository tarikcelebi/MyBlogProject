using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface IPortfolioService 
    {
        ValueTask<Portfolio> GetPortfolioByIdASync(int id);
        Task CreatePortfolioAsync(Portfolio entity);
        Task UpdatePortfolioForUserAsync(Portfolio UpdatedPortfolio,int PortfolioToBeUpdated);
        void DeletePortfolio(Portfolio entity);
        void DeletePortfolioRange(IEnumerable<Portfolio> entities);
        Task AddRangePortfolioAsync(IEnumerable<Portfolio> entities);
        IEnumerable<Portfolio> FindPortfolioAsync(Expression<Func<Portfolio, bool>> predicate);
        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task<Portfolio> SingleorDefault(Expression<Func<Portfolio, bool>> expression);
        Task<IEnumerable<Portfolio>> GetWhereListAsync(Expression<Func<Portfolio, bool>> expression);
        Task<Portfolio> GetPortfolioForUserByIdAsync(int id, AppUser user);
        Task<IEnumerable<Portfolio>> GetPortfoliosForUserAsync(AppUser user);
        Task<bool> AddPortfolioForUserByEntitiesAsync(Portfolio portfolio, AppUser user);
        Task<bool> UpdatePortfolioForUserAsync(Portfolio portfolioToBeUpdated, AppUser user);
        Task<bool> RemovePortfolioFromUserListByEntitiesAsync(Portfolio portfolioToBeRemoved,AppUser user);


    }
}
