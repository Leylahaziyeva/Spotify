namespace Spotify.Domain.Entities
{  
    public class Music
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }    
        public string? Genre { get; set; }          
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}