using MyBlogBLL.Services.Abstract;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Label = MyBlogDomain.Entities.Label;

namespace MyBlogBLL.Services.Concrete
{
    public class LabelService : ILabelService
    {
        private readonly IUnitOfWork unitOfWork;

        public LabelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Label>> GetAllLabels()
        {
            throw new NotImplementedException();
        }
    }
}
