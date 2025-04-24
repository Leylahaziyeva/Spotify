namespace Spotify.Domain.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Genres { get; set; }    
        public string? ImageUrl { get; set; }  
        public List<Album> Albums { get; set; } = new();
    }
}