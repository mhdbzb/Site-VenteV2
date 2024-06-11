using AppliVentes.Models;
using AppliVentes.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Services
{
    public class PanierService
    {
        private readonly AppliVentesDbContext _context;
        private readonly HttpClient _httpClient;

        public PanierService(AppliVentesDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public Panier CreateNewPanier()
        {
            var newPanier = new Panier();
            newPanier.Nom = Environment.MachineName;
            _context.Paniers.Add(newPanier);
            _context.SaveChanges();
            return newPanier;
        }

        public Panier GetPanierById(int id, bool withArticle = false)
        {
            Panier panier = null;
            if (withArticle)
            {
                panier = _context.Paniers.Include(p => p.Articles).FirstOrDefault(a => a.Id == id);
            }
            else
            {
                panier = _context.Paniers.FirstOrDefault(a => a.Id == id);
            }
            return panier;
        }

        public ArticlePanier AddArticleToPanier(int idPanier, int idArticle, int quantiteAjoutee)
        {
            var articlePanier = new ArticlePanier(idPanier, idArticle, quantiteAjoutee);
            _context.ArticlesPaniers.Add(articlePanier);
            _context.SaveChanges();
            return articlePanier;
        }

        public List<Article> GetArticlesFromPanier(Panier panier) 
        {
            List<Article> articlesDuPanier = _context.Articles
                .Join(_context.ArticlesPaniers, article => article.Id,
                articlePanier => articlePanier.ArticleId, 
                (article, articlePanier) => new { Article = article, ArticlePanier = articlePanier })
                .Where(joined => joined.ArticlePanier.PanierId == panier.Id)
                .Select(joined => joined.Article)
                .ToList();
            return articlesDuPanier;

        }
    }
}
