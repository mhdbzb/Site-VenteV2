using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliVentes.Models
{
    public class ArticlePanier
    {
        public int PanierId { get; set; }
        public int ArticleId { get; set; }
        public int QuantiteArticle { get; set; }
        public ArticlePanier() { }
        public ArticlePanier(int quantiteArticle)
        {
            QuantiteArticle = quantiteArticle;
        }
        public ArticlePanier(int panierId, int articleId, int quantiteArticle)
        {
            PanierId = panierId;
            ArticleId = articleId;
            QuantiteArticle = quantiteArticle;
        }
    }
}
