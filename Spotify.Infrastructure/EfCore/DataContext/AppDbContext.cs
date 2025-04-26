using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Entities;

namespace Spotify.Infrastructure.EfCore.DataContext;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Music> Musics { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=SpotifyDbPb403;Trusted_Connection=true;TrustServerCertificate=true");
    }
}
