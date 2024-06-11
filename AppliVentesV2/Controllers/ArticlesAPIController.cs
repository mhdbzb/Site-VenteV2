using Microsoft.AspNetCore.Mvc;
using AppliVentesAPI.Services;
using AppliVentesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppliVentesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesApiController : ControllerBase
    {
        private readonly ArticleServices _services;

        public ArticlesApiController(ArticleServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<List<Article>> GetArticles()
        {
            var articles = _services.GetAllArticles();
            return Ok(articles);
        }
    }
}

