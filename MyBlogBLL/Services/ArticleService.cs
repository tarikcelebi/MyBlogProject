using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public class ArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        bool AddArticle(Article article)
        {
            return articleRepository.Add(article);
        }

        bool UpdateArticle(Article article)
        {
            return articleRepository.Update(article);   
        }

        bool DeleteArticle(Article article)
        {
            return articleRepository.Delete(article);
        }

        IEnumerable<Article> GetAllArticles()
        {
            return articleRepository.GetAll();
        }

        Article GetArticleById(int id)
        {
            return articleRepository.GetById(id);
        }

        IEnumerable<Article> GetSubjectArticles(Article article)
        {
            return articleRepository.GetWhereList(s => s.SubjectId == article.SubjectId);
        }
    }
}
