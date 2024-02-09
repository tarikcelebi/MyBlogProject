using MyBlogDAL.Context;
using MyBlogDAL.Identity;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Repositories.Concrete
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(MyBlogDbContext dbContext) : base(dbContext)
        {

        }

        private MyBlogDbContext myBlogDbContext => Context as MyBlogDbContext;

    }
}
