using AppliVentes.Models;
using AppliVentes.Models.Repository;

namespace AppliVentesAPI.Services
{
    public class ArticleService
    {
        private readonly AppliVentesDbContext _context;
        public ArticleService(AppliVentesDbContext context)
        {
            _context = context;
        }
        public List<Article> GetAllArticles()
        {
            var listeArticles = _context.Articles.ToList();
            return listeArticles;
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.SingleOrDefault(a => a.Id == id);
        }

        public Article AddArticle(string name, decimal price, int stock)
        {
            var newArticle = new Article(name, price, stock);
            _context.Articles.Add(newArticle);
            _context.SaveChanges();

            return newArticle;
        }

        public Article SaveEditedArticle(int id, string name, decimal price, int stock)
        {
            var editedArticle = GetArticleById(id);
            editedArticle.Name = name;
            editedArticle.Price = price;
            editedArticle.Stock = stock;
            _context.SaveChanges();

            return editedArticle;
        }


        public Article RemoveArticle(int id)
        {
            var articleToRemove = GetArticleById(id);
            _context.Articles.Remove(articleToRemove);
            _context.SaveChanges();

            return articleToRemove;
        }
         
    }
}
