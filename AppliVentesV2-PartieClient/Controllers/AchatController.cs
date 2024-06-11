using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GestionAchats.Services;
using AppliVentes.Models;


namespace GestionAchats.Controllers
{
    [Route("Achat")]
    public class AchatController : Controller
    {
        private readonly ArticleService _articleService;
        private readonly PanierService _panierService;

        public AchatController(ArticleService articleService, PanierService panierService)
        {
            _articleService = articleService;
            _panierService = panierService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var articles = _articleService.GetAllArticles();
            return View("IndexAchat", articles);
        }

        [Route("Panier")]
        public IActionResult AfficherPanier(int idPanier)
        {
            idPanier = 8;
            var panier = _panierService.GetPanierById(idPanier);
            var listArticles = _panierService.GetArticlesFromPanier(panier);
            return View("Panier", listArticles);
        }


        [Route("Ajouter/{idArticle}")]
        public IActionResult AjouterArticle(int idArticle)
        {
            var articleAjoute = _articleService.GetArticleById(idArticle);
            int idPanier;
            bool panierExists = int.TryParse(Request.Form["idPanier"], out idPanier);
            if (!panierExists)
            {
                Panier newPanier = _panierService.CreateNewPanier();
                idPanier = newPanier.Id;
                panierExists = true;
            }

            var panier = _panierService.GetPanierById(idPanier);
            int quantite = int.Parse(Request.Form["stock"]);
            _panierService.AddArticleToPanier(idPanier, idArticle, quantite);
            

            return RedirectToAction("Index");
        }
    }
}
