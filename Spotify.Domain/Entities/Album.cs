namespace Spotify.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }       
        public string? CoverImageUrl { get; set; }      
        public string? Genres { get; set; }   
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public List<Music> Musics { get; set; } = new();
    }
}