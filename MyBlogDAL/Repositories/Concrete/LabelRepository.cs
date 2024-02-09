
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
    public class LabelRepository : GenericRepository<Label>, ILabelRepository
    {
        public LabelRepository(MyBlogDbContext dbContext) : base(dbContext)
        {

        }

    }
}
