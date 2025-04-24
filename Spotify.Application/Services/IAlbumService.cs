using Spotify.Domain.Entities;

namespace Spotify.Application.Services
{
    public interface IAlbumService
    {
        void Add(Album album);
        void Update(Album album);
        void Delete(int id);
        Album GetById(int id);
        List<Album> GetAll();
    }
}