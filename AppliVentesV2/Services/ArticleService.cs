using AppliVentes.Models;
using AppliVentes.Models.Repository;
using System.Text.Json;

namespace GestionArticles.Services
{
    public class ArticleService
    {
        private readonly AppliVentesDbContext _context;
        private readonly HttpClient _httpClient;
        public ArticleService(AppliVentesDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public List<Article> GetAllArticles(int pageNumber = 1, int nbrPerPage = 10)
        {
            var url = "https://localhost:7266/api/articles";
            var response = _httpClient.GetAsync(url).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            List<Article> articles = JsonSerializer.Deserialize<List<Article>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return articles;
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
