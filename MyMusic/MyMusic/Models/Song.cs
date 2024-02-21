namespace MyMusic.Models;

public class Song
{
    public int Id { get; set; }

    public string? SongName { get; set; }

    public Album Album { get; set; }
    public int AlbumId { get; set;}

    public Artist Artist { get; set; }
    public int ArtistId { get; set;}

}

