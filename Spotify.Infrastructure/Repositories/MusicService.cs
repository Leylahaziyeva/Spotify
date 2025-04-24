using Microsoft.EntityFrameworkCore;
using Spotify.Application.Services;
using Spotify.Domain.Entities;
using Spotify.Infrastructure.DataContext;

namespace Spotify.Infrastructure.Repositories
{
    public class MusicService : IMusicService
    {
        private readonly AppDbContext _context;

        public MusicService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Music music)
        {
            _context.Musics.Add(music);
            _context.SaveChanges();
        }

        public List<Music> GetAll()
        {
            return _context.Musics.Include(m => m.Album).ThenInclude(a => a.Artist).ToList();
        }

        public Music GetById(int id)
        {
            return _context.Musics.Include(m => m.Album).ThenInclude(a => a.Artist).FirstOrDefault(m => m.Id == id);
        }

        public void Update(Music music)
        {
            var existing = _context.Musics.Find(music.Id);
            if (existing != null)
            {
                existing.Title = music.Title;
                existing.ReleaseDate = music.ReleaseDate;
                existing.Genre = music.Genre;
                existing.AlbumId = music.AlbumId;

                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var music = _context.Musics.Find(id);
            if (music != null)
            {
                _context.Musics.Remove(music);
                _context.SaveChanges();
            }
        }
    }
}