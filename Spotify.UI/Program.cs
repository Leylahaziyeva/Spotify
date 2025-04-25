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
    Console.WriteLine("7. Update Artist");
    Console.WriteLine("8. Delete Artist");
    Console.WriteLine("9. Update Album");
    Console.WriteLine("10. Delete Album");
    Console.WriteLine("11. Update Music");
    Console.WriteLine("12. Delete Music");
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

        case "7":
            Console.Write("Artist ID to update: ");
            var artistUpdateId = int.Parse(Console.ReadLine());
            var artistToUpdate = artistService.GetById(artistUpdateId);
            if (artistToUpdate == null)
            {
                Console.WriteLine("Artist not found.");
                break;
            }
            Console.Write("New Name: ");
            artistToUpdate.Name = Console.ReadLine();
            Console.Write("New Genres: ");
            artistToUpdate.Genres = Console.ReadLine();
            Console.Write("New Image URL: ");
            artistToUpdate.ImageUrl = Console.ReadLine();
            artistService.Update(artistToUpdate);
            break;

        case "8":
            Console.Write("Artist ID to delete: ");
            var artistDeleteId = int.Parse(Console.ReadLine());
            artistService.Delete(artistDeleteId);
            break;

        case "9":
            Console.Write("Album ID to update: ");
            var albumUpdateId = int.Parse(Console.ReadLine());
            var albumToUpdate = albumService.GetById(albumUpdateId);
            if (albumToUpdate == null)
            {
                Console.WriteLine("Album not found.");
                break;
            }
            Console.Write("New Title: ");
            albumToUpdate.Title = Console.ReadLine();
            Console.Write("New Release Date: ");
            albumToUpdate.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("New Genres: ");
            albumToUpdate.Genres = Console.ReadLine();
            Console.Write("New Cover Image URL: ");
            albumToUpdate.CoverImageUrl = Console.ReadLine();
            Console.Write("New Artist ID: ");
            albumToUpdate.ArtistId = int.Parse(Console.ReadLine());
            albumService.Update(albumToUpdate);
            break;

        case "10":
            Console.Write("Album ID to delete: ");
            var albumDeleteId = int.Parse(Console.ReadLine());
            albumService.Delete(albumDeleteId);
            break;

        case "11":
            Console.Write("Music ID to update: ");
            var musicUpdateId = int.Parse(Console.ReadLine());
            var musicToUpdate = musicService.GetById(musicUpdateId);
            if (musicToUpdate == null)
            {
                Console.WriteLine("Music not found.");
                break;
            }
            Console.Write("New Title: ");
            musicToUpdate.Title = Console.ReadLine();
            Console.Write("New Release Date: ");
            musicToUpdate.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("New Genre: ");
            musicToUpdate.Genre = Console.ReadLine();
            Console.Write("New Album ID: ");
            musicToUpdate.AlbumId = int.Parse(Console.ReadLine());
            musicService.Update(musicToUpdate);
            break;

        case "12":
            Console.Write("Music ID to delete: ");
            var musicDeleteId = int.Parse(Console.ReadLine());
            musicService.Delete(musicDeleteId);
            break;

        case "0":
            return;
    }
}