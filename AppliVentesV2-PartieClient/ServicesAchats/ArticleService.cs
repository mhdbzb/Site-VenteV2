using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AppliVentes.Models;
using AppliVentes.Models.Repository;

namespace GestionAchats.Services
{
    public class ArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly AppliVentesDbContext _context;

        public ArticleService(AppliVentesDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }


        public List<Article> GetAllArticles()
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
            var article = _context.Articles.Where(a => a.Id == id).FirstOrDefault();
            return article;
        }
    }
}
