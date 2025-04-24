using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Entities;

namespace Spotify.Infrastructure.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JIHG98N\SQLEXPRESS;Database=ECommerce;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}