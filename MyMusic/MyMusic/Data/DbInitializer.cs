using MyMusic.Models;

namespace MyMusic.Data
{
    public class DbInitializer
    {

        public static void Initialize(MusicContext context)
        {
            // Look for any students.
            if (context.Albums.Any() || context.Songs.Any() || context.Artists.Any())
            {
                return;   // DB has been seeded
            }

            var albums = new Album[]
            {
                new Album { Title = "The Dark Side of the Moon" },
                new Album { Title = "Greatest Hits" },
                new Album { Title = "Abbey Road" }
            };

            var songs = new Song[]
            {
                new Song { SongName = "Bohemian Rhapsody", AlbumId = 3, ArtistId = 2},
                new Song { SongName = "Hotel California" , AlbumId = 1, ArtistId = 1},
                new Song { SongName = "Smells Like Teen Spirit" , AlbumId = 1, ArtistId = 2},
                new Song { SongName = "Imagine", AlbumId = 3, ArtistId = 1},
            };

            var artists = new Artist[]
            {
                new Artist { Name = "Hardcore Ole Hansen"},
                new Artist { Name = "Beatmore"},
                new Artist { Name ="King Diamond"}
            };

            context.Songs.AddRange(songs);
            context.Albums.AddRange(albums);
            context.Artists.AddRange(artists);
            context.SaveChanges();

        }
    }
}