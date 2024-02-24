﻿using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;

namespace MyBlogProject.ViewComponents
{
	public class ArticleList : ViewComponent
	{
		private readonly IArticleService articleService;
        public ArticleList(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await articleService.GetAllArticlesAsync();

            return View();
        }
    }
}
