using Spotify.Domain.Entities;
using Spotify.Infrastructure.DataContext;
using Spotify.Infrastructure.Repositories;

using var context = new AppDbContext();

var artistService = new ArtistService(context);
var albumService = new AlbumService(context);
var musicService = new MusicService(context);

while (true)
{
    Console.WriteLine("\n---- SPOTIFY DB ----");
    Console.WriteLine("1. Add Artist");
    Console.WriteLine("2. List Artists");
    Console.WriteLine("3. Add Album");
    Console.WriteLine("4. List Albums");
    Console.WriteLine("5. Add Music");
    Console.WriteLine("6. List Musics");
    Console.WriteLine("0. Exit");
    Console.Write("Choice: ");

    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Artist Name: ");
            var name = Console.ReadLine();
            Console.Write("Genres: ");
            var genreArtist = Console.ReadLine();
            Console.Write("Image URL: ");
            var imgUrl = Console.ReadLine();
            artistService.Add(new Artist
            {
               Name = name,
               Genres = genreArtist,
               ImageUrl = imgUrl
            });
            break;
        case "2":
            foreach (var a in artistService.GetAll())
                Console.WriteLine($"{a.Id}: {a.Name}");
            break;
        case "3":
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Release Date: ");
            var date = DateTime.Parse(Console.ReadLine());
            Console.Write("Genres: ");
            var genreAlbum = Console.ReadLine();
            Console.Write("Image URL: ");
            var img = Console.ReadLine();
            Console.Write("Artist ID: ");
            var artistId = int.Parse(Console.ReadLine());

            albumService.Add(new Album
            {
                Title = title,
                ReleaseDate = date,
                Genres = genreAlbum,
                CoverImageUrl = img,
                ArtistId = artistId
            });
            break;
        case "4":
            foreach (var a in albumService.GetAll())
                Console.WriteLine($"{a.Id}: {a.Title}, {a.ReleaseDate:yyyy}, by {a.Artist?.Name}");
            break;
        case "5":
            Console.Write("Title: ");
            var mtitle = Console.ReadLine();
            Console.Write("Release Date: ");
            var mdate = DateTime.Parse(Console.ReadLine());
            Console.Write("Genre: ");
            var genreMusic = Console.ReadLine();
            Console.Write("Album ID: ");
            var albumId = int.Parse(Console.ReadLine());

            musicService.Add(new Music
            {
                Title = mtitle,
                ReleaseDate = mdate,
                Genre = genreMusic,
                AlbumId = albumId
            });
            break;
        case "6":
            foreach (var m in musicService.GetAll())
                Console.WriteLine($"{m.Id}: {m.Title}, {m.Album?.Title}, by {m.Album?.Artist?.Name}");
            break;
        case "0":
            return;
    }
}