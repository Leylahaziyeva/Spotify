using Spotify.Application.Services;
using Spotify.Domain.Entities;
using Spotify.Infrastructure.DataContext;

public class ArtistService : IArtistService
{
    private readonly AppDbContext _context;

    public ArtistService(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Artist artist)
    {
        _context.Artists.Add(artist);
        _context.SaveChanges();
    }

    public List<Artist> GetAll()
    {
        return _context.Artists.ToList();
    }

    public Artist GetById(int id)
    {
        return _context.Artists.FirstOrDefault(a => a.Id == id);
    }

    public void Update(Artist artist)
    {
        var existing = _context.Artists.Find(artist.Id);
        if (existing != null)
        {
            existing.Name = artist.Name;
            existing.Genres = artist.Genres;
            existing.ImageUrl = artist.ImageUrl;
            _context.SaveChanges();
        }
    }
    public void Delete(int id)
    {
        var artist = _context.Artists.Find(id);
        if (artist != null)
        {
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }
    }
}