using AppliVentes.Models;
using Microsoft.EntityFrameworkCore;

namespace AppliVentes.Models.Repository
{
    public class AppliVentesDbContext : DbContext
    {
        public AppliVentesDbContext(DbContextOptions<AppliVentesDbContext> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Historique> Historiques { get; set; }
        public DbSet<ArticlePanier> ArticlesPaniers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Panier>()
                .HasMany(ap => ap.Articles)
                .WithMany(ap => ap.Paniers)
                .UsingEntity<ArticlePanier>();
        }
    }

}

