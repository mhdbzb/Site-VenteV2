using Microsoft.AspNetCore.Mvc;
using GestionArticles.Services;

namespace GestionArticles.Controllers
{
    [Route("Articles")]
    public class ArticleController : Controller
    {
        private readonly ArticleService _services;
        public ArticleController(ArticleService services)
        {
            _services = services;
        }

        [Route("")]
        public IActionResult List()
        {
            var articles = _services.GetAllArticles();
            return View("IndexArticle", articles);
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateArticlePost()
        {
            string name = Request.Form["name"];
            decimal price = decimal.Parse(Request.Form["price"]);
            int stock = int.Parse(Request.Form["stock"]);
            _services.AddArticle(name, price, stock);

            return RedirectToAction("List");
        }

        [Route("Edit/{id}")]
        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            var articleToEdit = _services.GetArticleById(id);
            return View(articleToEdit);
        }

        [Route("Edit")]
        [HttpPost]
        public IActionResult EditArticlePost()
        {
            int id = int.Parse(Request.Form["id"]);
            string name = Request.Form["name"];
            decimal price = decimal.Parse(Request.Form["price"]);
            int stock = int.Parse(Request.Form["stock"]);
            _services.SaveEditedArticle(id, name, price, stock);


            return RedirectToAction("List");
        }



         
        [Route("Delete/{id}")]
        [HttpGet]
        public IActionResult DeleteArticle(int id) 
        {
            DeleteArticlePost(id);
            return RedirectToAction("List");
        }


        [Route("Delete/{id}")]
        [HttpPost]
        public IActionResult DeleteArticlePost(int id)
        {
            _services.RemoveArticle(id);

            return RedirectToAction("List");
        }
    }
}
