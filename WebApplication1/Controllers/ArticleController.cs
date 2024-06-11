using AppliVentesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AppliVentes.Models;

namespace AppliVentesAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ArticleController : ControllerBase
    {
        public readonly ArticleService _articleService;
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [Route("articles")]
        public List<Article> GetAllArticles()
        {
            var articles = _articleService.GetAllArticles(); ;
            return articles;
        }

        [HttpPost]
        [Route("")]
        public Article AddArticle(Article article)
        {
            var newArticle = _articleService.AddArticle(article.Name, article.Price, article.Stock);
            return newArticle;
        }
    }
}
