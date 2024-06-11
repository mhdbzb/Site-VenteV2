using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliVentes.Models
{
    public class Historique
    {
        public int Id { get; set; }
        public decimal? MontantPanier { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateAchat { get; set; }
        public int PanierId { get; set; }
        public Panier? Panier { get; set; }
    }
}
