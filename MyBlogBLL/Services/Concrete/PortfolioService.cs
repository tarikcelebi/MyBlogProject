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

        public Task AddPortfolioAsync(Portfolio entity)
        {
            throw new NotImplementedException();
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

        public ValueTask<Portfolio> GetPortfolioByIdASync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Portfolio>> GetWhereListAsync(Expression<Func<Portfolio, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio> SingleorDefault(Expression<Func<Portfolio, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePortfolioAsync(Portfolio UpdatedPortfolio, int PortfolioToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
