using Spotify.Domain.Entities;

namespace Spotify.Application.Services
{
    public interface IMusicService
    {
        void Add(Music music);
        void Update(Music music);
        void Delete(int id);
        Music GetById(int id);
        List<Music> GetAll();
    }
}