using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliVentes.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public List<Article>? Articles { get; } = [];
        public Panier() { }
    }
}

