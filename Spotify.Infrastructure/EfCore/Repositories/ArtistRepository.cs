using Spotify.Domain.Entities;
using Spotify.Domain.Interfaces;

namespace Spotify.Infrastructure.EfCore.Repositories;

public class ArtistRepository : EfCoreRepository<Artist>, IArtistRepository
{
    public ArtistRepository() : base()
    {
    }
}
