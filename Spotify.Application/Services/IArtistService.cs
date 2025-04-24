using Spotify.Domain.Entities;

namespace Spotify.Application.Services
{
    public interface IArtistService
    {
        void Add(Artist artist);
        void Update(Artist artist);
        void Delete(int id);
        Artist GetById(int id);
        List<Artist> GetAll();
    }
}