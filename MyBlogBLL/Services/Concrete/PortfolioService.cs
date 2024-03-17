using MyBlogBLL.Services.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork unitOfWork;

        public PortfolioService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;   
        }

        public async Task CreatePortfolioAsync(Portfolio entity)
        {
            await unitOfWork.portfolioRepository.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }

        public Task AddRangePortfolioAsync(IEnumerable<Portfolio> entities)
        {
            throw new NotImplementedException();
        }

        public void DeletePortfolio(Portfolio entity)
        {
            throw new NotImplementedException();
        }

        public void DeletePortfolioRange(IEnumerable<Portfolio> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Portfolio> FindPortfolioAsync(Expression<Func<Portfolio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await unitOfWork.portfolioRepository.GetAllAsync();
        }

        public async ValueTask<Portfolio> GetPortfolioByIdASync(int id)
        {
            return await unitOfWork.portfolioRepository.GetByIdASync(id);
        }

        public async Task<Portfolio> GetPortfolioForUserByIdAsync(int id, AppUser user)
        {
            return await unitOfWork.portfolioRepository.GetPortfolioByIdIncludeUserAsync(id, user);
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosForUserAsync(AppUser user)
        {
            return await unitOfWork.portfolioRepository.GetUserPortfoliosByUser(user);
        }

        public async Task<IEnumerable<Portfolio>> GetWhereListAsync(Expression<Func<Portfolio, bool>> expression)
        {
            return await unitOfWork.portfolioRepository.GetWhereListAsync(expression);
        }

        public Task<Portfolio> SingleorDefault(Expression<Func<Portfolio, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePortfolioForUserAsync(Portfolio UpdatedPortfolio, int PortfolioToBeUpdated)
        {
            Portfolio NewPortfolio = await unitOfWork.portfolioRepository.GetByIdASync(PortfolioToBeUpdated);
            NewPortfolio.Name = UpdatedPortfolio.Name;
            NewPortfolio.ProjectUrl = UpdatedPortfolio.ProjectUrl;
            NewPortfolio.ImageURL = UpdatedPortfolio.ImageURL;
            NewPortfolio.ImageURL2 = UpdatedPortfolio.ImageURL2;
            NewPortfolio.AppUser = UpdatedPortfolio.AppUser;
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> AddPortfolioForUserByEntitiesAsync(Portfolio portfolio, AppUser user)
        {
            //portfolio.AppUser.Id = user.Id;
            await CreatePortfolioAsync(portfolio);
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            return false;
            
        }

        public async Task<bool> UpdatePortfolioForUserAsync(Portfolio portfolioToBeUpdated, AppUser user)
        {
            Portfolio NewPortfolio = await unitOfWork.portfolioRepository.GetByIdASync(portfolioToBeUpdated.Id);
            NewPortfolio.Name = portfolioToBeUpdated.Name;
            NewPortfolio.ProjectUrl = portfolioToBeUpdated.ProjectUrl;
            NewPortfolio.ImageURL = portfolioToBeUpdated.ImageURL;
            NewPortfolio.ImageURL2 = portfolioToBeUpdated.ImageURL2;
            NewPortfolio.AppUser = portfolioToBeUpdated.AppUser;
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            return false;
        }

        public async Task<bool> RemovePortfolioFromUserListByEntitiesAsync(Portfolio portfolioToBeRemoved, AppUser user)
        {
            Portfolio portfolio = await unitOfWork.portfolioRepository.GetPortfolioByIdIncludeUserAsync(portfolioToBeRemoved.Id, user);
            portfolio.AppUser.Portfolios.Remove(portfolioToBeRemoved);
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            return false;
        }
    }
}
