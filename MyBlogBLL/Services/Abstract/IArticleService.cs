using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetArticlesBySubjectId(int id);
    }
}
