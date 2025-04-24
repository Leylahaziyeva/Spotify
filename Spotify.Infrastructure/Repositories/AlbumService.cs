using Microsoft.EntityFrameworkCore;
using Spotify.Application.Services;
using Spotify.Domain.Entities;
using Spotify.Infrastructure.DataContext;

namespace Spotify.Infrastructure.Repositories
{
    public class AlbumService : IAlbumService
    {
        private readonly AppDbContext _context;

        public AlbumService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }
        public List<Album> GetAll()
        {
            return _context.Albums.Include(a => a.Artist).ToList();
        }
        public Album GetById(int id)
        {
            return _context.Albums.Include(a => a.Artist).FirstOrDefault(a => a.Id == id);
        }
        public void Update(Album album)
        {
            var existing = _context.Albums.Find(album.Id);
            if (existing != null)
            {
                existing.Title = album.Title;
                existing.ReleaseDate = album.ReleaseDate;
                existing.CoverImageUrl = album.CoverImageUrl;
                existing.Genres = album.Genres;
                existing.ArtistId = album.ArtistId;

                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var album = _context.Albums.Find(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
        }
    }
}