using MyBlogBLL.Services.Abstract;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;

        }

        public async Task<bool> CreateArticle(Article article)
        {
            try
            {
                await unitOfWork.articleRepository.AddAsync(article);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task DeleteArticle(Article article)
        {
            unitOfWork.articleRepository.Delete(article);
            await unitOfWork.CommitAsync();
        }

		public async Task<IEnumerable<Article>> GetAllArticlesAsync()
		{
            return await unitOfWork.articleRepository.GetAllAsync();
		}

		public Task<Article> GetArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await unitOfWork.articleRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesBySubjectId(int id)
        {
            return await unitOfWork.articleRepository.GetAllAsync();
        }

        public async Task UpdateArticle(Article updatedArticle, Article article)
        {
            updatedArticle.SubjectId = article.SubjectId;
            updatedArticle.Id = article.Id;
            updatedArticle.Header = article.Header;
            updatedArticle.Body = article.Body;

            await unitOfWork.CommitAsync();
        }
    }
}
