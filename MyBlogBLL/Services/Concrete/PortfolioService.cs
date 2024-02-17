using MyBlogDAL.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class PortfolioService 
    {
        private readonly IUnitOfWork unitOfWork;

        public PortfolioService(IUnitOfWork unitOfWork)
        {
            
        }
    }
}
