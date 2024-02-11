using MyBlogBLL.Services.Abstract;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class ArticleService : GenericService<Article>, IArticleService
    {
        public Task<IEnumerable<Article>> GetArticlesBySubjectId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
