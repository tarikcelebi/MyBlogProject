using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISubjectRepository Subjects => throw new NotImplementedException();

        public ILabelRepository Labels => throw new NotImplementedException();

        public IArticleRepository Articles => throw new NotImplementedException();

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
